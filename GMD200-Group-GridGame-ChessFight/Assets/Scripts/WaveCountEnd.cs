using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveCountEnd : MonoBehaviour
{

    public WaveCounter waveKeeper;
    public TextMeshProUGUI dispWaves;
    // Start is called before the first frame update
    void Start()
    {
        dispWaves.text = "Waves: " + waveKeeper.waveCounter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
