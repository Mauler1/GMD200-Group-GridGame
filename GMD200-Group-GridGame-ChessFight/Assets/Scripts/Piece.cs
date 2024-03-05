using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    private int damage;
    private int cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void spawn();

    public abstract int getDamage();

    public abstract void increaseDamage(int damage);

}
