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
        var playTime = initLatency;

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
    
}
