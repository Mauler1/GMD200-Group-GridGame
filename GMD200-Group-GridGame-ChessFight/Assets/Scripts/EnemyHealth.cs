using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;
    private int damage = 0;
    private GameObject king;
    private EnemyPathing enemyPathing;
    public enum enemyType 
    { basic, fast, tanky, stronger, sneaky };
    public enemyType EnemyType;

    void Start()
    {
        king = GameObject.FindGameObjectWithTag("King");
        switch(EnemyType)
        {
            case enemyType.basic:
                damage = 1;
                health = 1;
                break;
            case enemyType.fast:
                damage = 1;
                health = 1;
                break;
            case enemyType.tanky: 
                damage = 2;
                health = 4;
                break;
            case enemyType.stronger:
                damage = 3;
                health = 3;
                break;
            case enemyType.sneaky:
                damage = 2;
                health = 1;
                break;
            default:
                damage = 2;
                health = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            enemyPathing.CheckDeath(true);
            Destroy(gameObject);
        }
    }
    public void dealDamage()
    {
        king.GetComponent<King>().subtractHealth(damage);
    }
}
