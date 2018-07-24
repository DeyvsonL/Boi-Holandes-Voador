using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
	public DialogueElement[] dialogueElements;
}

[System.Serializable]
public class DialogueElement
{
	public string name;
	[TextArea(3, 10)] 
	public string sentence;

	public AudioClip audioClip;
}

