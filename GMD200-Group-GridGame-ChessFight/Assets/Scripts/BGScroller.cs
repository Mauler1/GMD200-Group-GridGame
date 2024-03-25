using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private float xMove;
    [SerializeField] private float yMove;

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(xMove, yMove) * Time.deltaTime, image.uvRect.size);
    }
}
