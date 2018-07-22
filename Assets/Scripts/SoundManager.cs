using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioSource gameMusic;

    [SerializeField]
    private AudioSource secondGameMusic;

    private void Awake()
    {
        gameMusic.Play();
        Invoke("StartSecondMusic", 5);
    }

    void StartSecondMusic()
    {
        secondGameMusic.Play();
    }

	
}
