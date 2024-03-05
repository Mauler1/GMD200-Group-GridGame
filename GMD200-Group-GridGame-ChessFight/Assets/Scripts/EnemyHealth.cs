using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;
    private int damage = 0;
    private GameObject king;
    public enum EnemyType 
    { basic, fast, tanky, stronger, sneaky };
    public EnemyType enemyType;

    void Start()
    {
        king = GameObject.FindGameObjectWithTag("King");
        switch(enemyType)
        {
            case EnemyType.basic:
                damage = 1;
                health = 1;
                break;
            case EnemyType.fast:
                damage = 1;
                health = 1;
                break;
            case EnemyType.tanky: 
                damage = 2;
                health = 4;
                break;
            case EnemyType.stronger:
                damage = 3;
                health = 3;
                break;
            case EnemyType.sneaky:
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
            Destroy(gameObject);
        }
    }
    public void dealDamage()
    {
        king.GetComponent<King>().subtractHealth(damage);
    }
}
