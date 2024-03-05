using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;

    private enum enemyType 
    { basic, fast, tanky, stronger, sneaky };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        { 
            Destroy(gameObject);
        }
    }
}
