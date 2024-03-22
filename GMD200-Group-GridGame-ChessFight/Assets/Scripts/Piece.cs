using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public int towerCost;
<<<<<<< HEAD
    public int attackTier, speedTier;
=======
    public int damage;
    public float atkSpeed;
>>>>>>> 1e3488090579fdccba4bf6cb39874042ed156255

    public abstract void spawn();

    public abstract int getDamage();

    public abstract void increaseDamage(int damage);

}
