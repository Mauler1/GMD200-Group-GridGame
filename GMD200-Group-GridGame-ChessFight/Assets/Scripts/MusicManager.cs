using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] musicCollection;
    private AudioClip prevTrack;
    private AudioClip currentTrack;
    [SerializeField] private AudioSource player;


    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying == false){
            PlayMusic();
        }
    }

    private void PlayMusic(){
        int trackIndex = Random.Range(0,musicCollection.Length);
        currentTrack = musicCollection[trackIndex];
        if(currentTrack == prevTrack){
            trackIndex = Random.Range(0,musicCollection.Length);
            currentTrack = musicCollection[trackIndex];
        }
        else{
            player.PlayOneShot(currentTrack,0.8f);
        }
        
    }
}
