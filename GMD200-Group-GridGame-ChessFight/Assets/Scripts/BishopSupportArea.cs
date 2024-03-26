using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopSupportArea : MonoBehaviour
{
    private Bishop bishop;
    private const float START_AREA_SIZE = 3.8f;
    private void Awake()
    {
        bishop = GetComponentInParent<Bishop>();
    }
    public void Update()
    {
        transform.localScale = new Vector3(START_AREA_SIZE + bishop.sizeAdj, START_AREA_SIZE + bishop.sizeAdj, 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        if(collision.gameObject.GetComponent<Rook>() != null &&  collision.gameObject.GetComponent<Rook>().supportTier < bishop.supportTier)
        {
            collision.gameObject.GetComponent<Rook>().increaseDamage(bishop.supportTier - collision.gameObject.GetComponent<Rook>().supportTier);
            collision.gameObject.GetComponent<Rook>().increaseSpeed(0.1f);
            collision.gameObject.GetComponent<Rook>().decreaseTier(bishop.supportTier - collision.gameObject.GetComponent<Rook>().supportTier);
            collision.gameObject.GetComponent<Rook>().supportTier += 1;
        }
        else if (collision.gameObject.GetComponent<Pawn>() != null && collision.gameObject.GetComponent<Pawn>().supportTier < bishop.supportTier)
        {
            collision.gameObject.GetComponent<Pawn>().increaseDamage(bishop.supportTier - collision.gameObject.GetComponent<Pawn>().supportTier);
            collision.gameObject.GetComponent<Pawn>().increaseSpeed(0.1f);
            collision.gameObject.GetComponent<Pawn>().decreaseTier(bishop.supportTier - collision.gameObject.GetComponent<Pawn>().supportTier);
            collision.gameObject.GetComponent<Pawn>().supportTier += 1;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        if (collision.gameObject.GetComponent<Rook>() != null && collision.gameObject.GetComponent<Rook>().supportTier < bishop.supportTier)
        {
            collision.gameObject.GetComponent<Rook>().increaseDamage(bishop.supportTier - collision.gameObject.GetComponent<Rook>().supportTier);
            collision.gameObject.GetComponent<Rook>().increaseSpeed(bishop.supportTier - collision.gameObject.GetComponent<Rook>().supportTier);
            collision.gameObject.GetComponent<Rook>().decreaseTier(bishop.supportTier - collision.gameObject.GetComponent<Rook>().supportTier);
        }
        else if (collision.gameObject.GetComponent<Pawn>() != null && collision.gameObject.GetComponent<Pawn>().supportTier < bishop.supportTier)
        {
            collision.gameObject.GetComponent<Pawn>().increaseDamage(bishop.supportTier - collision.gameObject.GetComponent<Pawn>().supportTier);
            collision.gameObject.GetComponent<Pawn>().increaseSpeed(bishop.supportTier - collision.gameObject.GetComponent<Pawn>().supportTier);
            collision.gameObject.GetComponent<Pawn>().decreaseTier(bishop.supportTier - collision.gameObject.GetComponent<Pawn>().supportTier);
        }
    }*/
}
