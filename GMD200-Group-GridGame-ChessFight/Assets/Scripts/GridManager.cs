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
    [SerializeField] private TextMeshProUGUI text;
    public event Action<GridTile> TileSelected;
    [SerializeField] private PieceSpawn pieceSelector;
    [SerializeField] private GridTile[][] tiles;
    //try making a 2d array for the pathways, it would be manually set but it could work.
    private void Awake()
    {
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
                tiles[x][y] = tile;
            }
        }
    }

    public void OnTileHoverEnter(GridTile gridTile)
    {
        text.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(GridTile gridTile)
    {
        text.text = "--";
    }
    public void OnTileSelected(GridTile gridTile)
    {
        TileSelected?.Invoke(gridTile);
    }
    public GridTile getTile(int x, int y)
    {
        return tiles[x][y];
    }

}
