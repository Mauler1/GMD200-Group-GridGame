using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickGridManager : MonoBehaviour
{
    public event Action<NickGridTile> TileSelected;

    public int numRows = 5;
    public int numColumns = 6;

    public float padding = 0.1f;

    [SerializeField] private NickGridTile tilePrefab;
    [SerializeField] private TextMeshProUGUI text;
    private NickGridTile[] _tiles;

    private void Awake()
    {
        InitGrid();
    }

    public void InitGrid() 
    {
        _tiles = new NickGridTile[numRows * numColumns];

        for (int y = 0; y < numRows; y++) 
        {
            for (int x = 0; x < numColumns; x++)
            {
                NickGridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding*x), y + (padding*y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{x}_{y}";
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
                _tiles[y * numColumns + x] = tile;
            }
        }
    }

    public void OnTileHoverEnter(NickGridTile gridTile) 
    { 
        text.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(NickGridTile gridTile)
    {
        text.text = "- - -";
    }

    public void OnTileSelected(NickGridTile gridTile) 
    {
        TileSelected?.Invoke(gridTile);
    }

    internal NickGridTile GetTile(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= numColumns || pos.y < 0 || pos.y >= numRows) 
        {
            Debug.LogError($"Invalid Coordinate{pos}");
            return null;
        }
        return _tiles[pos.y * numColumns + pos.x]; 
    }
}
