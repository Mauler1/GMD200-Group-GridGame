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
    private const int START_COST = 100;
    public TextMeshProUGUI costDisp;
    private int curCost;
    // Start is called before the first frame update
    void Start()
    {
        curCost = START_COST;
    }

    // Update is called once per frame
    void Update()
    {
        costDisp.text = "Current Cost: " + curCost.ToString();
    }
    public void Spawn(int x, int y)
    {
        if(gridManager.getTile(x, y).isOccupied == false && gridManager.getTile(x, y).canBeOccupied == true)
        {
            Transform spawnPos = gridManager.getTile(x, y).transform;
            Piece tempTow = Instantiate(curTower, spawnPos);
            tempTow.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, -1f);
            if(tempTow is Pawn pawn){
                pawn.spawn();
            }
            //in here use any other special script get components I will need
            gridManager.getTile(x, y).isOccupied = true;
            curTower = null;
        }
        else
        {
            Debug.Log("Tile is occupied or is a road");
        }

    }
    public void setCurTower(Piece targTow)
    {
        curTower = targTow;
    }

}
