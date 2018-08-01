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

    [SerializeField]
    private AudioSource hammerOne;

    [SerializeField]
    private AudioSource hammerTwo;

    [SerializeField]
    private AudioSource cowOne;

    [SerializeField]
    private AudioSource cowTwo;

    [SerializeField]
    private Vector2 cowInterval;

    private void Start()
    {
        Debug.Log("Playing intro music!");
        gameMusicIntro.Play();
        secondGameMusicIntro.Play();

        gameMusicLoop.PlayDelayed( gameMusicIntro.clip.length );    
        secondGameMusicLoop.PlayDelayed( secondGameMusicIntro.clip.length );    


        secondGameMusicIntro.mute = true;
        Invoke("UnmuteSecondMusic", 65);
        Invoke("Cow", UnityEngine.Random.Range(cowInterval.x, cowInterval.y));

    }

    void UnmuteSecondMusic()
    {
        secondGameMusicIntro.mute = false;
    }

    public void PlayHammerOne(float pitch = 1.0f)
    {
        hammerOne.pitch = pitch;
        hammerOne.Play();
    }

    public void PlayHammerTwo(float pitch = 1.0f)
    {
        hammerTwo.pitch = pitch;
        hammerTwo.Play();
    }

    private void Cow()
    {
        var firstCow = UnityEngine.Random.value > 0.5 ? true : false;

        if (firstCow) cowOne.Play();
        else cowTwo.Play();

        Invoke("Cow", UnityEngine.Random.Range(cowInterval.x, cowInterval.y));
    }


}
