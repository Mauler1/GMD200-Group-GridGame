using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private int pathLength;
    private int counter = 0;
    private Rigidbody2D rb;
    public EnemySpawner spawner;
    private PieceMenu menu;

    private Color defaultColor;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float movespeed = 5f;
    [SerializeField] private GridManager _gridManager;

    public GridTile[] enemyTiles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _gridManager = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridManager>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<PieceMenu>();
    }
    void Start()
    {
        LevelOnePath();
        counter = 0;
    }

    void Update()
    {

    }

    public void LevelOnePath()
    {
        pathLength = 16;
        enemyTiles = new GridTile[pathLength];
        enemyTiles[0] = _gridManager.getTile(0, 5);
        enemyTiles[1] = _gridManager.getTile(1, 5);
        enemyTiles[2] = _gridManager.getTile(2, 5);
        enemyTiles[3] = _gridManager.getTile(3, 5);
        enemyTiles[4] = _gridManager.getTile(3, 4);
        enemyTiles[5] = _gridManager.getTile(3, 3);
        enemyTiles[6] = _gridManager.getTile(3, 2);
        enemyTiles[7] = _gridManager.getTile(3, 1);
        enemyTiles[8] = _gridManager.getTile(4, 1);
        enemyTiles[9] = _gridManager.getTile(5, 1);
        enemyTiles[10] = _gridManager.getTile(5, 2);
        enemyTiles[11] = _gridManager.getTile(5, 3);
        enemyTiles[12] = _gridManager.getTile(5, 4);
        enemyTiles[13] = _gridManager.getTile(6, 4);
        enemyTiles[14] = _gridManager.getTile(6, 5);
        enemyTiles[15] = _gridManager.getTile(7, 5);

        for (int i = 0; i < 16; i++)
        {
            enemyTiles[i].SetColor(Color.green);
        }

        StartCoroutine(CoAdvanceMovement());

    }

    public void setColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    IEnumerator CoAdvanceMovement()
    {
        while (counter < 16)
        {
            transform.DOMove(new Vector2(enemyTiles[counter].transform.position.x, enemyTiles[counter].transform.position.y), 1);
            yield return new WaitForSeconds(movespeed);
            enemyTiles[counter].canBeOccupied = false;
            counter++;
        }
        if (counter >= 16)
        {
            CheckDeath();
            // add a part here for the king to take damage and destroy the game object
        }
    }

    public void CheckDeath()
    {
        spawner.EnemyDestroyed();
        PathEnd(true);
        Destroy(gameObject);
    }

    public void PathEnd(bool death)
    {
        if (death)
        {
            StopCoroutine(CoAdvanceMovement());
        }
    }

    public void PeiceKill()
    {
        StopCoroutine(CoAdvanceMovement());
        menu.addCost(50);
    }
}
