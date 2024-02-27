using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public int towerCost;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridTile gridTile;
    //these will be set when the tower is instantiated so it is dynamic
    public int xPos, yPos;

    // Update is called once per frame
    void Update()
    {
        
    }
}
