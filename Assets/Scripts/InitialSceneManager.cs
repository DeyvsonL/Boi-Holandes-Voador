using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneManager : MonoBehaviour
{
	//[SerializeField]
	private List<GameObject> historyObjects;
	private int index;
	
	private void Start () {
		
	}
	
	private void Update ()
	{		
		if (!Input.GetButtonDown("Jump")) return;
		if (index >= historyObjects.Count - 1)
		{
			SceneManager.LoadScene("BridgeScene");
			return;
		}

		historyObjects[index++].SetActive(false);
		historyObjects[index].SetActive(true);
	}
}
