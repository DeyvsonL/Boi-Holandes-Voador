﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
	public Text NameText;
	public Text DialogueText;

	public Queue<DialogueElement> DialogueQueue;

	private string currentText;

	public Animator Animator;

	public Image Nassau;
	public Image Guilherme;
	public Image Cristina;
	
	void Awake()
	{
		DialogueQueue = new Queue<DialogueElement>();
	}

	void Start()
	{
		Animator.SetTrigger("IniciarDialogo");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (DialogueText.text != currentText)
			{
				StopAllCoroutines();
				DialogueText.text = currentText;
			}
			else
			{
				DisplayNextSentence();
			}
		}
	}

	public void StartDialogue(DialogueScript dialogue)
	{
		//Animator.SetBool("IsOpen", true);
		
		DialogueQueue.Clear();

		foreach (var element in dialogue.dialogueElements)
		{
			DialogueQueue.Enqueue(element);
		}

		DisplayNextSentence();
	}

	private void DisplayNextSentence()
	{
		if (DialogueQueue.Count == 0)
		{
			EndDialogue();
			return;
		}

		var dialogElement = DialogueQueue.Dequeue();
		NameText.text = dialogElement.name;

		if (dialogElement.name == "Narrador")
		{
			Guilherme.color = new Color(Guilherme.color.r, Guilherme.color.g, Guilherme.color.b, 0f);
			Cristina.color = new Color(Cristina.color.r, Cristina.color.g, Cristina.color.b, 0f);
		}
		else if (dialogElement.name == "Cristina")
		{
			Guilherme.color = new Color(Guilherme.color.r, Guilherme.color.g, Guilherme.color.b, 0f);
			Cristina.color = new Color(Cristina.color.r, Cristina.color.g, Cristina.color.b, 1f);
		}
		else if (dialogElement.name == "Guilherme")
		{
			Guilherme.color = new Color(Guilherme.color.r, Guilherme.color.g, Guilherme.color.b, 1f);
			Cristina.color = new Color(Cristina.color.r, Cristina.color.g, Cristina.color.b, 0f);	
		}

		var sentence = dialogElement.sentence;
		currentText = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		DialogueText.text = "";
		foreach (var letter in sentence.ToCharArray())
		{
			DialogueText.text += letter;
			yield return null;
		}
	}

	private void EndDialogue()
	{
		Animator.SetTrigger("TerminarDialogo");
		//SceneManager.LoadScene("Tela2");
	}

}
