using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneManager : MonoBehaviour
{
	public DialogueTriggerScript introScript;

	private void Start()
	{
		introScript.TriggerDialogue();
	}
}
