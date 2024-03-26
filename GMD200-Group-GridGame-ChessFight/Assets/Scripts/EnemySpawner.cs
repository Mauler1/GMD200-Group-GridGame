using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]

    [Header("Wave Parts")]

    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private int currentWave = 1;
    [SerializeField] private bool waveDone = false;

    [Header("Events")]

    public float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    public int spawnNext = 3;
    public GameObject[] typeOfEnemy;
    public GameObject enemyPrefab;

    private void Awake()
    {
        StartWave();
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;
        enemiesAlive = 0;
    }

    private void Update()
    {
        timeSinceLastSpawn = Time.time;

        if (timeSinceLastSpawn > spawnNext) 
        {
            isSpawning = true;
            spawnNext += 3;
        }

        if (enemiesLeftToSpawn <= 0) 
        {
            isSpawning = false;
        }

        if(isSpawning)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            isSpawning = false;
        }
        CheckWave();
    }

    private void CheckWave()
    {
        if (enemiesLeftToSpawn == 0 && enemiesAlive == 0) 
        {
            waveDone = true;
        }

        if (waveDone) 
        {
            Debug.Log("Wave done");
            currentWave++;
            enemiesLeftToSpawn = EnemiesPerWave();
            waveDone = false;
        }
    }
    public void EnemyDestroyed() 
    { 
        enemiesAlive--;
    }

    private void SpawnEnemy() 
    {
        enemyPrefab = typeOfEnemy[Random.Range(1, 4)];
        Vector3 spawnPosition = new Vector3(-4.4f, 1.8f, 0f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(enemyPrefab, spawnPosition, spawnRotation);      
    }
    private int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    // this will need to have to hold multiple enemy types 
}
