using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickGridTile1 : MonoBehaviour
{
    public NickGridManager1 gridManager1;

    public Vector2Int gridCoords;

    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    private void OnMouseOver()
    {
        gridManager1.OnTileHoverEnter(this);
        setColor(Color.green);
    }

    private void OnMouseExit()
    {
        gridManager1.OnTileHoverExit(this);
        resetColor();
    }

    public void setColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void resetColor()
    {
        _spriteRenderer.color = _defaultColor;
    }

    
    private void OnMouseDown()
    {
        gridManager1.OnTileSelected(this);
    }
    
}
