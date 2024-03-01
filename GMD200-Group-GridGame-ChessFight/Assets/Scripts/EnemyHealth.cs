using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;

    private enum enemyType 
    { basic, fast, tanky, stronger, sneaky };

    // what I am going to do is make a tag for different enemies so they each get a different set of health depending on what it is.

    // make a checkTag statement

    // movement and speed will be covered in other scripts

    // Start is called before the first frame update
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
