using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTile : MonoBehaviour
{
    [SerializeField] private Piece attackPiece;
    private void Awake()
    {
        attackPiece = this.GetComponentInParent<Piece>();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            Debug.Log("hit");
            other.GetComponent<EnemyHealth>().takeDamage(attackPiece.getDamage());
        }
    }
}
