using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickPlayerUnit : MonoBehaviour
{
    [SerializeField] private NickGridManager _gridManager;
    [SerializeField] private float movespeed = 5;

    private void OnEnable()
    {
        _gridManager.TileSelected += OnTileSelected;
    }

    private void OnDisable()
    {
        _gridManager.TileSelected -= OnTileSelected;

    }

    private void OnTileSelected(NickGridTile obj) 
    { 
        StopAllCoroutines();
        StartCoroutine(Co_MoveTo(obj.transform.position));
    }

    private IEnumerator Co_MoveTo(Vector3 targetPosition) 
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
    }
}
