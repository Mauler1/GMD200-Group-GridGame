using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickGridManager1 : MonoBehaviour
{
    public event Action<NickGridTile1> TileSelected1;

    public int numRows = 5;
    public int numColumns = 6;

    public float padding = 0.1f;

    [SerializeField] private NickGridTile1 tilePrefab1;
    [SerializeField] private TextMeshProUGUI text;
    private NickGridTile1[] _tiles1;

    private void Awake()
    {
        InitGrid();
    }

    public void InitGrid()
    {
        _tiles1 = new NickGridTile1[numRows * numColumns];

        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numColumns; x++)
            {
                NickGridTile1 tile = Instantiate(tilePrefab1, transform);
                Vector2 tilePos = new Vector2(x + (padding * x), y + (padding * y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{x}_{y}";
                tile.gridManager1 = this;
                tile.gridCoords = new Vector2Int(x, y);
                _tiles1[y * numColumns + x] = tile;
            }
        }
    }

    public void OnTileHoverEnter(NickGridTile1 gridTile)
    {
        text.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(NickGridTile1 gridTile)
    {
        text.text = "- - -";
    }

   
    public void OnTileSelected(NickGridTile1 gridTile)
    {
        TileSelected1?.Invoke(gridTile);
    }
   

}
