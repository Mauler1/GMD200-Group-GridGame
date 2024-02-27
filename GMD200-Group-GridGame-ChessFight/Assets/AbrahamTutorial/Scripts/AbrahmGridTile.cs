using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrahmGridTile : MonoBehaviour
{
    public AbrahmGridManager gridManager;
    public Vector2Int gridCoords;
    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor =_spriteRenderer.color; 
    }

    private void OnMouseOver(){

        gridManager.OnTileHoverEnter(this);
        //SetColor(Color.green);

    }

    private void OnMouseExit(){

        gridManager.OnTileHoverExit(this);
        //ResetColor();

    }

    private void OnMouseDown(){
        gridManager.OnTileSelected(this);
    }

    public void SetColor(Color color){
        _spriteRenderer.color = color;
    }

    public void ResetColor(){
        _spriteRenderer.color = _defaultColor;
    }
}
