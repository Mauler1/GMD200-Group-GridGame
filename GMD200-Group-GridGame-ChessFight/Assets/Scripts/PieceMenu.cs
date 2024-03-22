using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PieceMenu : MonoBehaviour
{
    //public Pawn pawn;
    public Piece curTower, pawn;
    [SerializeField] private GridManager gridManager;
    private const int START_COST = 300;
    public TextMeshProUGUI costDisp;
    private int curCost;
    //intent is whether or not the current tower is something that will be placed onto the board, true means it will, false means it wont and already exists
    public bool intent = true;
    // Start is called before the first frame update
    void Start()
    {
        curCost = START_COST;
    }

    // Update is called once per frame
    void Update()
    {
        costDisp.text = "Current Cost: " + curCost.ToString();
        if(Input.GetMouseButtonDown(1))
        {
            curTower = null;
        }
    }
    public void Spawn(int x, int y)
    {
        if(gridManager.getTile(x, y).isOccupied == false && gridManager.getTile(x, y).canBeOccupied == true && curTower.towerCost <= curCost)
        {
            curCost -= curTower.towerCost;
            Transform spawnPos = gridManager.getTile(x, y).transform;
            Piece tempTow = Instantiate(curTower, spawnPos);
            tempTow.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, -1f);
            tempTow.spawn();
            //in here use any other special script get components I will need
            gridManager.getTile(x, y).isOccupied = true;
            gridManager.getTile(x, y).occupant = tempTow.gameObject;
            curTower = null;
            intent = false;
        }
        else
        {
            if(curTower.towerCost > curCost)
            {
                Debug.Log("Not enough cost exists");
            }
            else
            {
                Debug.Log("Tile is occupied or is a road");
            }
            
        }

    }
    public void setCurTower(Piece targTow)
    {
        curTower = targTow;
        intent = true;
    }
    public int getCurCost()
    {
        return curCost;
    }
    public void addCost(int costChange)
    {
        curCost += costChange;
        Debug.Log("Added cost: " + costChange);
    }
    public void subtractCost(int costChange)
    { 
        curCost -= costChange;
        Debug.Log("Subtracted cost: " + costChange);
    }
}
