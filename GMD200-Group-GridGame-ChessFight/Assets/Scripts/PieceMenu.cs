using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMenu : MonoBehaviour
{
    //public Pawn pawn;
    public GameObject curTower, pawn;
    [SerializeField] private GridManager gridManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnPawn(int x, int y)
    {
        if(gridManager.getTile(x, y).isOccupied == false && gridManager.getTile(x, y).canBeOccupied == true)
        {
            Transform spawnPos = gridManager.getTile(x, y).transform;
            GameObject tempPawn = Instantiate(pawn, spawnPos);
            tempPawn.GetComponent<Pawn>().xPos = x;
            tempPawn.GetComponent <Pawn>().yPos = y;
            gridManager.getTile(x, y).isOccupied = true;
            curTower = null;
        }
        else
        {
            Debug.Log("Tile is occupied or is a road");
        }

    }
    public void setCurTower(GameObject targTow)
    {
        curTower = targTow;
    }

}
