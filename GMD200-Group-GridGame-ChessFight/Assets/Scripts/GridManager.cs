using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridManager : MonoBehaviour
{
    public int numRows = 5;
    public int numColumns = 5;
    [SerializeField] private GridTile tilePrefab;
    public float padding = 0.1f;
    public event Action<GridTile> TileSelected;
    [SerializeField] public GridTile[,] tiles;
    [SerializeField] private PieceMenu menu;
    public Upgrades upgrader;


    //try making a 2d array for the pathways, it would be manually set but it could work.
    private void Awake()
    {
        
        tiles = new GridTile[numColumns, numRows];
        InitGrid();
    }
    public void InitGrid()
    {
        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numColumns; x++)
            {
                GridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding * x), y + (padding * y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile{x}_{y}";
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
                tile.isOccupied = false;
                tile.canBeOccupied = true;
                tiles[x, y] = tile;
            }
        }
    }

    public void OnTileHoverEnter(GridTile gridTile)
    {
        
    }

    public void OnTileHoverExit(GridTile gridTile)
    {
        
    }
    public void OnTileSelected(GridTile gridTile)
    {
        TileSelected?.Invoke(gridTile);
        if(menu.curTower != null && menu.intent == true)
        {
            //adjust this once we get the pieces figured out
            if(gridTile.isOccupied == false && gridTile.canBeOccupied == true)
            {
                menu.Spawn(gridTile.gridCoords.x, gridTile.gridCoords.y);
            }
            /*else if(gridTile.isOccupied == true)
            {
                upgrader.selectedTower = gridTile.occupant.GetComponent<Piece>();
            }*/
        }
        else if(menu.curTower == null)
        {
            menu.curTower = gridTile.occupant.GetComponent<Piece>();
            menu.intent = false;
        }
    }
    public GridTile getTile(int x, int y)
    {
        return tiles[x, y];
    }

}
