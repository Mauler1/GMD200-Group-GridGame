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
            StartCoroutine(Co_AttackEnemy(attackPiece.atkSpeed, other));
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        StopCoroutine(Co_AttackEnemy(attackPiece.atkSpeed, other));
    }

    private IEnumerator Co_AttackEnemy(float cooldown, Collider2D other){
        while(other != null){
            if(other.GetComponent<EnemyHealth>() != null){
                other.GetComponent<EnemyHealth>().takeDamage(attackPiece.getDamage());
                yield return new WaitForSeconds(cooldown);
            }
        }  
    }
}
