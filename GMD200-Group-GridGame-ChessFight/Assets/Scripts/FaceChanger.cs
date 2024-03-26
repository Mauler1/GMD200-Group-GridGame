using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{

    [SerializeField] private SpriteRenderer face;
    [SerializeField] private Sprite[] faceStates;
    [SerializeField] private WaveCounter waves;
    private Sprite frame1, frame2;
    private int index = 0;
    private bool shoudlCo = false;

    void Start(){
        frame1 = faceStates[index];
        frame2 = faceStates[index+1];
        StartCoroutine(faceSwitch(frame1, frame2));
    }


    // this is the worst code that this project has, however, this is 2 minutes before due date and im tired :)
    void Update()
    {
        if(waves.waveCounter == 5 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 6 && shoudlCo == true){
            shoudlCo = false; 
        }

        if(waves.waveCounter == 10 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 11 && shoudlCo == true){
            shoudlCo = false; 
        }

        if(waves.waveCounter == 15 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 16 && shoudlCo == true){
            shoudlCo = false; 
        }

        if(waves.waveCounter == 20 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 21 && shoudlCo == true){
            shoudlCo = false; 
        }

        if(waves.waveCounter == 25 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 26 && shoudlCo == true){
            shoudlCo = false; 
        }

        if(waves.waveCounter == 30 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 31 && shoudlCo == true){
            shoudlCo = false; 
        }
        if(waves.waveCounter == 35 && shoudlCo == false){
            shoudlCo = true;
            resetCo();   
        }
        if(waves.waveCounter == 36 && shoudlCo == true){
            shoudlCo = false; 
        }

    }

    private IEnumerator faceSwitch(Sprite first, Sprite second){
        while(true){
            face.sprite = first;
            yield return new WaitForSeconds(1);
            face.sprite = second;
            yield return new WaitForSeconds(1);
        }
    }

    private void increaseFaces(){
        index+=2;
        frame1 = faceStates[index];
        frame2 = faceStates[index+1];
    }

    private void resetCo(){
        StopAllCoroutines();
        increaseFaces();
        StartCoroutine(faceSwitch(frame1, frame2));
    }
}
