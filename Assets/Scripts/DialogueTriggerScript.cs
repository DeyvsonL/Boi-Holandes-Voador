using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{

	public DialogueScript Dialogue;
	
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManagerScript>().StartDialogue(Dialogue);
	}
}
