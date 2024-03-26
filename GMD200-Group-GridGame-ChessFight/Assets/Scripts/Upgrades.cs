using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Piece selectedTower;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private PieceMenu menu;
    private GridTile tile;
    public GameObject upgradeAttack, upgradeSpeed;
    public TextMeshProUGUI notEnoughCashMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        gridManager.upgrader = this;
    }

    // Update is called once per frame
    void Update()
    {
        selectedTower = menu.curTower;
        if(selectedTower!=null && selectedTower.GetComponent<Bishop>() != null && menu.intent == false)
        {
            upgradeAttack.SetActive(true);
            upgradeAttack.GetComponentInChildren<TextMeshProUGUI>().text = "Attack: " + selectedTower.attackTier + "\nUpgrade Cost: " + selectedTower.attackTier * 50;
            upgradeSpeed.SetActive(true);
            upgradeSpeed.GetComponentInChildren<TextMeshProUGUI>().text = "Radius: " + selectedTower.speedTier + "\nUpgrade Cost: " + selectedTower.speedTier * 50;
        }
        else if (selectedTower != null && menu.intent == false)
        {
            upgradeAttack.SetActive(true);
            upgradeAttack.GetComponentInChildren<TextMeshProUGUI>().text = "Attack: " + selectedTower.attackTier + "\nUpgrade Cost: " + selectedTower.attackTier * 50;
            upgradeSpeed.SetActive(true);
            upgradeSpeed.GetComponentInChildren<TextMeshProUGUI>().text = "Speed: " + selectedTower.speedTier + "\nUpgrade Cost: " + selectedTower.speedTier * 50;
        }
        else
        {
            upgradeAttack.SetActive(false);
            upgradeSpeed.SetActive(false);
        }
    }
    public void IncrementAttack()
    {
        if (menu.getCurCost() >= selectedTower.attackTier * 50)
        {
            selectedTower.increaseDamage(1);
            menu.subtractCost(selectedTower.attackTier * 50 - 50);
        }
        else
        {
            notEnoughCashMessage.enabled = true;
            StartCoroutine(CoErrorMessageWait());
        }
    }
    public void IncrementSpeed()
    {
        if(menu.getCurCost() >= selectedTower.speedTier * 50)
        {
            selectedTower.increaseSpeed(0.1f);
            menu.subtractCost(selectedTower.speedTier * 50 - 50);
        }
        else
        {
            notEnoughCashMessage.enabled = true;
            StartCoroutine(CoErrorMessageWait());
        }
    }
    private IEnumerator CoErrorMessageWait()
    {
        yield return new WaitForSeconds(1);
        notEnoughCashMessage.enabled = false;
    }
}
