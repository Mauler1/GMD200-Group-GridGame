using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int damage = 0;
    private GameObject king;
    [SerializeField] private WaveCounter waveCounter;
    [SerializeField] private EnemyPathing enemyPathing;
    public enum enemyType 
    { basic, fast, tanky, stronger, sneaky };
    public enemyType EnemyType;

    void Start()
    {
        king = GameObject.FindGameObjectWithTag("King");
        enemyPathing = this.GetComponent<EnemyPathing>();
        switch(EnemyType)
        {
            case enemyType.basic:
                damage = 1;
                health = 2 + waveCounter.waveCounter;
                break;
            case enemyType.fast:
                damage = 1;
                health = 1 + waveCounter.waveCounter;
                break;
            case enemyType.tanky: 
                damage = 2;
                health = 4 + waveCounter.waveCounter;
                break;
            case enemyType.stronger:
                damage = 3;
                health = 3 + waveCounter.waveCounter;
                break;
            case enemyType.sneaky:
                damage = 2;
                health = 1 + waveCounter.waveCounter;
                break;
            default:
                damage = 2;
                health = 1 + waveCounter.waveCounter;
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
            enemyPathing.PeiceKill();
        }
    }
    public void dealDamage()
    {
        king.GetComponent<King>().subtractHealth(damage);
    }
}
