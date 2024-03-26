using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTile : MonoBehaviour
{
    [SerializeField] private Piece attackPiece;
    private bool shouldDamage = false;

    private void Awake()
    {
        attackPiece = this.GetComponentInParent<Piece>();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            shouldDamage = true;
            StartCoroutine(Co_AttackEnemy(attackPiece.atkSpeed, other));
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        Debug.Log("stop");
        shouldDamage = false;
        StopCoroutine("Co_AttackEnemy");
    }

    private IEnumerator Co_AttackEnemy(float cooldown, Collider2D other){
        while(shouldDamage == true){
            if(other.GetComponent<EnemyHealth>() != null){
                other.GetComponent<EnemyHealth>().takeDamage(attackPiece.getDamage());
                yield return new WaitForSeconds(cooldown);
            }
        }  
    }
}
