using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
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


    public int getDamage(){
        return damage;
    }

    public void increaseDamage(int damage){
        this.damage += damage;
    }

}
