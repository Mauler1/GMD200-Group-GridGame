using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridCoords;
    private SpriteRenderer spriteRenderer;
    private Color defaultColor;
    public bool isOccupied, canBeOccupied;
    public GameObject occupant;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        isOccupied = false;
    }

    private void OnMouseOver()
    {
        gridManager.OnTileHoverEnter(this);
        SetColor(Color.green);
    }
    private void OnMouseExit()
    {
        gridManager.OnTileHoverExit(this);
        ResetColor();
    }
    private void OnMouseDown()
    {
        gridManager.OnTileSelected(this);
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
    public void ResetColor()
    {
        spriteRenderer.color = defaultColor;
    }
}
