using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public int towerCost = 100;
    [SerializeField] private int damage = 2;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridTile gridTile;
    [SerializeField] private AttackTile attackPrefab;
    //these will be set when the tower is instantiated so it is dynamic
    public float xPos, yPos;

    public void spawnPawn(){

        //instantiates the four corners of pawn attacking at positions of the transform of this object +/- 1 with padding included, as well as being children of this pawn

        AttackTile topLeft = Instantiate(attackPrefab, new Vector3(transform.position.x - 1 - gridManager.padding, transform.position.y + 1 + gridManager.padding, transform.position.z), Quaternion.identity, transform);
        AttackTile topRight = Instantiate(attackPrefab, new Vector3(transform.position.x + 1 + gridManager.padding, transform.position.y + 1 + gridManager.padding, transform.position.z), Quaternion.identity, transform);
        AttackTile bottomLeft = Instantiate(attackPrefab, new Vector3(transform.position.x - 1 - gridManager.padding, transform.position.y - 1 - gridManager.padding, transform.position.z), Quaternion.identity, transform);
        AttackTile bottomRight = Instantiate(attackPrefab, new Vector3(transform.position.x + 1 + gridManager.padding, transform.position.y - 1 - gridManager.padding, transform.position.z), Quaternion.identity, transform);

    }

    // damage return function for the attack tile
    public int getDamage(){
        return damage;
    }

    // increasing damage for use in piece upgrades
    public void increaseDamage(int damage){
        this.damage += damage;
    }
}
