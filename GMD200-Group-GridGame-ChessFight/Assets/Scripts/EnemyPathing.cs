using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPathing : MonoBehaviour
{
    private int pathLength;
    private int counter = 0;

    [SerializeField] private float movespeed = 5;
    [SerializeField] private GridManager _gridManager;

    public GridTile[] enemyTiles;
    // What this will do is this will be going through each path once the path is created and move to every tile
    // this is in order from the starting place to the ending place

    // first the grid will need to be set up for this 
    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        pathLength = 6;
        enemyTiles = new GridTile[pathLength];
        enemyTiles[0] = _gridManager.getTile(0,0);
        Debug.Log(enemyTiles[0]);
        // pathLength needs to get the coordinates for the pathing
        // this will set up the dynamic array
    }

    // Update is called once per frame
    void Update()
    {
        while (counter < 6) 
        {
            Debug.Log(enemyTiles[counter]);
            counter++;
            enemyTiles[counter] = _gridManager.getTile(counter, counter);
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
