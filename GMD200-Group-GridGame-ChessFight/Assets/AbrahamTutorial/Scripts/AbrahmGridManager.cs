using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbrahmGridManager : MonoBehaviour
{

    public event Action<AbrahmGridTile> TileSelected;
    public int numRows = 5;
    public int numColumns = 5;
    public float padding = 0.1f;
    [SerializeField] private AbrahmGridTile tilePrefab;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake(){

        InitGrid();

    }

    public void InitGrid(){

        for(int y = 0; y < numRows; y++){

            for(int x = 0; x < numColumns; x++){

                AbrahmGridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding*x), y + (padding*y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{x}_{y}";
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);

            }

        }


    }

    public void OnTileHoverEnter(AbrahmGridTile gridTile){
        text.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(AbrahmGridTile gridTile){
        text.text = "---";
    }

    public void OnTileSelected(AbrahmGridTile gridTile){
        TileSelected?.Invoke(gridTile);
    }

}
