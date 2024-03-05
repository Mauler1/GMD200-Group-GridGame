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
    public string vicScene, gameOverScene, startScene;

    // Start is called before the first frame update
    void Start()
    {
        health = START_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisp.text = "King's Health: " + health;
        if(health <= 0 )
        {
            LossScene();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyHealth>().dealDamage();
        Destroy(collision.gameObject);
    }
    public void subtractHealth(int damage)
    {
        health -= damage;
    }
    private void VictoryScene()
    {
        SceneManager.LoadScene(vicScene);
    }
    private void LossScene()
    {
        SceneManager.LoadScene(gameOverScene);
    }
    private void StartScene()
    {
        SceneManager.LoadScene(startScene);
    }
}
