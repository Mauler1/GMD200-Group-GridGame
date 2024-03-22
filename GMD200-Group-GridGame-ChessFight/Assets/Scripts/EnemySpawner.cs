using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // possibly dont use this (located with !!!)

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")] //!!!
    public static UnityEvent onEnemyDestroy; //!!!

    private int currentWave = 1; 
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
       // (needs to be commeted out! do not uncomment) onEnemyDestroy.AddListener(EnemyDestroyed); //!!!
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn = Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) 
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0;
        }
    }

    private void EnemyDestroyed() 
    { 
        enemiesAlive--; //!!!
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;
    }

    private void SpawnEnemy() 
    {
        Debug.Log("Spawn Enemy");
        // putting this in comment mode due to not being ready yet.
        /*
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startpoint.position, Quanternion.identity);
         */
    }
    private int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    // this will need to have to hold multiple enemy types 
}
