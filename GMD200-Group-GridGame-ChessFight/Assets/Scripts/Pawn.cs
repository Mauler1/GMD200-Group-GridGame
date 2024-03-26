using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pawn : Piece
{
    public Pawn()
    {
        towerCost = 100;
        attackTier = 1;
        speedTier = 1;
        damage = 1;
        atkSpeed = 1.0f;
        supportTier = 0;
    }
    [SerializeField] private float padding = 0.1f;
    [SerializeField] private GridTile gridTile;
    [SerializeField] private AttackTile attackPrefab;
    private PieceMenu menu;
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

        //instantiates the four corners of pawn attacking at positions of the transform of this object +/- 1 with padding included, as well as being children of this pawn

        //top left
        Instantiate(attackPrefab, new Vector3(transform.position.x - 1 - padding, transform.position.y + 1 + padding, transform.position.z), Quaternion.identity, transform);
        //top right
        Instantiate(attackPrefab, new Vector3(transform.position.x + 1 + padding, transform.position.y + 1 + padding, transform.position.z), Quaternion.identity, transform);
        //bottom left
        Instantiate(attackPrefab, new Vector3(transform.position.x - 1 - padding, transform.position.y - 1 - padding, transform.position.z), Quaternion.identity, transform);
        //bottom right
        Instantiate(attackPrefab, new Vector3(transform.position.x + 1 + padding, transform.position.y - 1 - padding, transform.position.z), Quaternion.identity, transform);

    }

    // damage return function for the attack tile
    public override int getDamage(){
        return damage;
    }

    // increasing damage for use in piece upgrades
    public override void increaseDamage(int damage){
        this.damage += damage;
        this.attackTier += 1;
    }

    public override void increaseSpeed(float speed)
    {
        this.atkSpeed -= speed;
        if(atkSpeed <= 0)
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
