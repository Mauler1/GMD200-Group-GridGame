using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // this coding is for the pathing for the enemies
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }
}
