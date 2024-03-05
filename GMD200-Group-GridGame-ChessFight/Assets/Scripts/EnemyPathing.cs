using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AiPathing : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                // make some code here for damage to king
                return;
            }
            else 
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * movespeed;
    }
    //this has been temporaily disabled for now for pathing to work

    /*
    private int pathLength;
    private int counter = 0;
    public int[] levelOnePath;

    [SerializeField] private float movespeed = 5f;
    [SerializeField] private GridManager _gridManager;

    public GridTile[,] enemyTiles;

    void Start()
    {
        LevelOnePath();
        counter = 0;
        Debug.Log(counter);
      
    }


    void Update()
    {
        pathCaller();
    }

    public void LevelOnePath() 
    {
        pathLength = 16;
        enemyTiles = new GridTile[pathLength, pathLength];
        enemyTiles[0, 0] = _gridManager.getTile(0,5);
        enemyTiles[1, 1] = _gridManager.getTile(1, 5);
        enemyTiles[2, 2] = _gridManager.getTile(2, 5);
        enemyTiles[3, 3] = _gridManager.getTile(3, 5);
        enemyTiles[4, 4] = _gridManager.getTile(3, 4);
        enemyTiles[5, 5] = _gridManager.getTile(3, 3);
        enemyTiles[6, 6] = _gridManager.getTile(3, 2);
        enemyTiles[7, 7] = _gridManager.getTile(3, 1);
        enemyTiles[8, 8] = _gridManager.getTile(4, 1);
        enemyTiles[9, 9] = _gridManager.getTile(5, 1);
        enemyTiles[10, 10] = _gridManager.getTile(5, 2);
        enemyTiles[11, 11] = _gridManager.getTile(5, 3);
        enemyTiles[12, 12] = _gridManager.getTile(5, 4);
        enemyTiles[13, 13] = _gridManager.getTile(6, 4);
        enemyTiles[14, 14] = _gridManager.getTile(6, 5);
        enemyTiles[15, 15] = _gridManager.getTile(7, 5);

        levelOnePath = new int[16];


        while (counter < 16)
        {
            enemyTiles[counter, counter].canBeOccupied = false;
            levelOnePath[counter] = counter;
            counter++;
        }
    }

    private void advaceMove(int x, int y) 
    {
        
    }

    private void pathCaller() 
    {
        StopAllCoroutines();
        StartCoroutine(PathingSelected());
    }

    private IEnumerator PathingSelected() 
    {
        while (counter < 16) 
        {
            GridTile currentTile = enemyTiles[counter, counter];
            Vector3 vector3 = new Vector3();
            vector3.x = levelOnePath[counter];
            vector3.y = levelOnePath[counter];
            //Vector3.MoveTowards(vector3.x, vector3.y, movespeed * Time.deltaTime);
            counter++;
            yield return null;
        }
    }

    private IEnumerator EnemyAdvancemnt(Vector3 targetPosition) 
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
    */
}
