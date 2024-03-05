using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class King : MonoBehaviour
{
    private int health;
    private const int START_HEALTH = 20;
    public TextMeshProUGUI healthDisp;
    // Start is called before the first frame update
    void Start()
    {
        health = START_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisp.text = "King's Health: " + health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        health--;
    }
}
