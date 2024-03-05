using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickPlayerUnit1 : MonoBehaviour
{
    [SerializeField] private NickGridManager1 _gridManager1;
    [SerializeField] private float movespeed = 5;

    private void OnEnable()
    {
        _gridManager1.TileSelected1 += OnTileSelected;
    }

    private void OnDisable()
    {
        _gridManager1.TileSelected1 -= OnTileSelected;
    }

    private void OnTileSelected(NickGridTile1 obj)
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
