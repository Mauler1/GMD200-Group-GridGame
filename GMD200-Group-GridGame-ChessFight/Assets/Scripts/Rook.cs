using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{

    public Rook(){

        towerCost = 250;
        damage = 1;
        atkSpeed = 1.5f;
        supportTier = 0;
        attackTier = 1;
        speedTier = 1;
    }

    [SerializeField] private float padding = 0.1f;
    [SerializeField] private GridTile gridTile;
    [SerializeField] private AttackTile attackPrefab;
    private PieceMenu menu;

    [SerializeField] private AttackTile[,] atkTiles;
    //these will be set when the tower is instantiated so it is dynamic
    public int xPos, yPos;

    private void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<PieceMenu>();
        attackTier = 1;
        speedTier = 1;
    }

    public override void spawn(int x, int y){

        xPos = x;
        yPos = y;

        float startPosX = transform.position.x - xPos - (padding*xPos);
        float startPosY = transform.position.y - yPos - (padding*yPos);

        //instantiates the rows of attackTiles
        
        for(int i = 0; i < 8; i++){
            Instantiate(attackPrefab, new Vector3(startPosX + i + padding*i, transform.position.y, transform.position.z), Quaternion.identity, transform);
        }
        for(int j = 0; j < 8; j++){
            Instantiate(attackPrefab, new Vector3(transform.position.x, startPosY + j + padding*j, transform.position.z), Quaternion.identity, transform);
        }
        
    }

    public override int getDamage(){
        return damage;
    }

    public override void increaseDamage(int damage){
        this.damage += damage;
        this.attackTier += 1;
    }

    public override void increaseSpeed(float speed)
    {
        this.atkSpeed -= speed;
        if (atkSpeed < 0)
        {
            this.atkSpeed = 0.1f;
        }
        this.speedTier += 1;
    }

    public override void decreaseTier(int value)
    {
        attackTier -= value;
        speedTier -= value;
    }
    private void OnMouseDown()
    {
        menu.curTower = this;
    }
}
