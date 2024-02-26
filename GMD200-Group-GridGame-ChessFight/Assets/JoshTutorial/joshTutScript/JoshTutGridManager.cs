using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoshTutGridManager : MonoBehaviour
{
    public int numRows = 5;
    public int numColumns = 5;
    [SerializeField] private JoshTutGridTile tilePrefab;
    public float padding = 0.1f;
    [SerializeField] private TextMeshProUGUI text;
    public event Action<JoshTutGridTile> TileSelected;

    private void Awake()
    {
        InitGrid();
    }
    public void InitGrid()
    {
        for(int y = 0; y < numRows; y++)
        {
            for(int x = 0; x < numColumns; x++)
            {
                JoshTutGridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding*x), y + (padding*y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile{x}_{y}";
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
            }
        }
    }

    public void OnTileHoverEnter(JoshTutGridTile gridTile)
    {
        text.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(JoshTutGridTile gridTile)
    {
        text.text = "--";
    }
    public void OnTileSelected(JoshTutGridTile gridTile)
    {
        TileSelected?.Invoke(gridTile);
    }
}
