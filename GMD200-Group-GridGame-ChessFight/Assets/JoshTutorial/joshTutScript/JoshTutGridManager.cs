using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoshTutGridManager : MonoBehaviour
{
    public int numRows = 5;
    public int numColumns = 5;
    [SerializeField] private JoshTutGridTile tilePrefab;
    public float padding = 0.1f;

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
            }
        }
    }
}
