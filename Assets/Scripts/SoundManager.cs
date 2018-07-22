using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioSource gameMusicIntro;

    [SerializeField]
    private AudioSource secondGameMusicIntro;
    
    [SerializeField]
    private AudioSource gameMusicLoop;

    [SerializeField]
    private AudioSource secondGameMusicLoop;
    
    private double initLatency = .1d;

    private void Start()
    {
        var playTime = AudioSettings.dspTime + initLatency;
        gameMusicIntro.PlayDelayed( ( float )playTime );
        secondGameMusicIntro.PlayDelayed( ( float )playTime );
        playTime += ( double )gameMusicIntro.clip.length;
        gameMusicLoop.PlayDelayed( ( float )playTime );    
        secondGameMusicLoop.PlayDelayed( ( float )playTime );    


        secondGameMusicIntro.mute = true;
        Invoke("UnmuteSecondMusic", 65);
    }

    void UnmuteSecondMusic()
    {
        secondGameMusicIntro.mute = false;
    }

    private void Update()
    {
        Debug.Log(string.Format("Playing inital {0} {1}", gameMusicIntro.isPlaying, gameMusicIntro.mute));
        Debug.Log(string.Format("Playing inital {0} {1}", secondGameMusicIntro.isPlaying, secondGameMusicIntro.mute));
        Debug.Log(string.Format("Playing inital {0} {1}", gameMusicLoop, gameMusicLoop.mute));
        Debug.Log(string.Format("Playing inital {0} {1}", secondGameMusicLoop.isPlaying, secondGameMusicLoop.mute));
    }
    
}
