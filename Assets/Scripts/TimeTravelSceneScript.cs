using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravelSceneScript : MonoBehaviour
{

	[SerializeField]
	private AudioSource _audioSource;
	// Use this for initialization
	void Start () {
		Debug.Log(_audioSource.clip.length);
		Invoke("LoadNextScene", _audioSource.clip.length);
	}

	private void LoadNextScene()
	{
		Debug.Log("Bye");
		SceneManager.LoadScene("LunetaScene");
	}
}
