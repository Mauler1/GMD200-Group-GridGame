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
    public Button upgradeAttack, upgradeSpeed;
    private int attackTier = 1, speedTier = 1;
    public TextMeshProUGUI notEnoughCashMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        gridManager.upgrader = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedTower != null)
        {
            upgradeAttack.enabled = true;
            upgradeSpeed.enabled = true;
        }
        else
        {
            upgradeAttack.enabled = false;
            upgradeSpeed.enabled = false;
        }
    }
    public void IncrementAttack()
    {
        if (menu.getCurCost() <= attackTier * 50)
        {
            selectedTower.increaseDamage(1);
        }
        else
        {
            notEnoughCashMessage.enabled = true;
            StartCoroutine(CoErrorMessageWait());
        }
    }
    public void IncrementSpeed()
    {
        if(menu.getCurCost() <= speedTier * 50)
        {
            //selectedTower.increaseSpeed(1);
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
