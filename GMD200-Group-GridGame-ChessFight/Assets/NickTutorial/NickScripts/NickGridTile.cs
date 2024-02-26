using System.Collections;
using System.Collections.Generic;
// using System.Drawing;
using UnityEngine;

public class NickGridTile : MonoBehaviour
{
    public NickGridManager gridManager;

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
        gridManager.OnTileHoverEnter(this);
        setColor(Color.green);
    }

    private void OnMouseExit()
    {
        gridManager.OnTileHoverExit(this);
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
}
