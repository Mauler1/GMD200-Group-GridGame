using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{

    public Rook(){

        towerCost = 250;
        damage = 1;
        atkSpeed = 0.5f;

    }

    [SerializeField] private float padding = 0.1f;
    [SerializeField] private GridTile gridTile;
    [SerializeField] private AttackTile attackPrefab;
    //these will be set when the tower is instantiated so it is dynamic
    public float xPos, yPos;

    public override void spawn(){

        //instantiates the rows of attackTiles
        
        //for(int i = xPos)


    }

    public override int getDamage(){
        return damage;
    }

    public override void increaseDamage(int damage){
        this.damage += damage;
    }
}
