using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveCountManager : MonoBehaviour
{
    public WaveCounter waveKeeper;
    public EnemySpawner spawner;
    public TextMeshProUGUI dispWaves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveKeeper.waveCounter = spawner.currentWave;
        dispWaves.text = "Waves: " + waveKeeper.waveCounter;
    }
}
