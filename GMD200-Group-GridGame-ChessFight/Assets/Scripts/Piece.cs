using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public abstract void spawn();

    public abstract int getDamage();

    public abstract void increaseDamage(int damage);

}
