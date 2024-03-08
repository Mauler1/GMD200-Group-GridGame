using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;
    private int damage = 0;
    private GameObject king;
    public enum enemyType 
    { basic, fast, tanky, stronger, sneaky };

    void Start()
    {
        king = GameObject.FindGameObjectWithTag("King");
       // if(enemyType == enemyType.basic)
        {
            damage = 1;
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
