using DG.Tweening;
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
    public void Spawn(int x, int y)
    {
        if(gridManager.getTile(x, y).isOccupied == false && gridManager.getTile(x, y).canBeOccupied == true)
        {
            Transform spawnPos = gridManager.getTile(x, y).transform;
            GameObject tempTow = Instantiate(curTower, spawnPos);
            tempTow.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, -1f);
            //in here use any other special script get components I will need
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
