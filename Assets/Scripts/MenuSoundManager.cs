using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource menuMusicIntro;

    [SerializeField]
    private AudioSource menuMusicLoop;

    private void Start()
    {

        menuMusicIntro.Play();
        menuMusicLoop.PlayDelayed(menuMusicIntro.clip.length);
    }

}
