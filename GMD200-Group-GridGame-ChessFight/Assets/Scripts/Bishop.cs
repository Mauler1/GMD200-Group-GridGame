using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    [SerializeField] private BishopSupportArea supAr;
    public Bishop()
    {
        towerCost = 300;
        attackTier = 1;
        speedTier = 1;
        damage = 1;
        //imagine this is radius instead
        atkSpeed = 1.0f;
        supportTier = 1;
    }

    [SerializeField] private float padding = 0.1f;
    public float sizeAdj = 0.1f;
    public int xPos, yPos;
    private PieceMenu menu;
    private void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<PieceMenu>();
    }

    public override void spawn(int x, int y)
    {
        xPos = x;
        yPos = y;
        supportTier = 1;
        float startPosX = transform.position.x - xPos - (padding * xPos);
        float startPosY = transform.position.y - yPos - (padding * yPos);

        Instantiate(supAr, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);

    }

    public override int getDamage()
    {
        return supportTier;
    }

    public override void increaseDamage(int damage)
    {
        this.supportTier += damage;
        this.attackTier += 1;
    }


    // imagine this is actually attack radius, due to crunch it will remain an overide for now
    public override void increaseSpeed(float speed)
    {
        this.atkSpeed += speed;
        this.speedTier += 1;
        sizeAdj *= atkSpeed;
    }
    public override void decreaseTier(int value)
    {
       //do nothing
    }
    private void OnMouseDown()
    {
        menu.curTower = this;
    }
}
