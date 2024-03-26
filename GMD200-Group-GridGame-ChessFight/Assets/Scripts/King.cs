using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class King : MonoBehaviour
{
    private int health;
    private const int START_HEALTH = 20;
    public TextMeshProUGUI healthDisp;
    public string gameOverScene;
    public EnemySpawner spawner;   

    // Start is called before the first frame update
    void Start()
    {
        health = START_HEALTH;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisp.text = "King's Health: \n" + health;
        if(health <= 0 )
        {
            LossScene();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyHealth>().dealDamage();
        spawner.EnemyDestroyed();
        Destroy(collision.gameObject);
    }
    public void subtractHealth(int damage)
    {
        health -= damage;
    }
    private void LossScene()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
