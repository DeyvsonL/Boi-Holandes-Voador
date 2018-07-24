using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScript : MonoBehaviour {
	

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}
	
}
