using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour {

	public void TryAgain()
	{
		SceneManager.LoadScene("BridgeScene");
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

}
