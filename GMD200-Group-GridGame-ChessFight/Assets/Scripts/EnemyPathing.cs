using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPathing : MonoBehaviour
{
    private int pathLength;
    private int counter = 0;
    public int[,] levelOnePath;

    [SerializeField] private float movespeed = 5;
    [SerializeField] private GridManager _gridManager;

    public GridTile[,] enemyTiles;
    // What this will do is this will be going through each path once the path is created and move to every tile
    // this is in order from the starting place to the ending place

    // first the grid will need to be set up for this 
    private void Awake()
    {
        LevelOnePath();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        // pathLength needs to get the coordinates for the pathing
        // this will set up the dynamic array
    }

    // Update is called once per frame
    void Update()
    {
        
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

        while (counter < 16)
        {
            Debug.Log(enemyTiles[counter, counter]);
            counter++;
        }
    }

    private void PathingSelected(GridManager place) 
    { 
        StopAllCoroutines();
        Debug.Log("GRID GAME " + place);
        StartCoroutine(EnemyAdvancemnt(place.transform.position));
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
}
