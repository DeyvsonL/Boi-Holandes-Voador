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

	public bool Finished = true;

	public string SceneToLoadWhenFinished;

	public AudioSource AudioSource;
	
	void Awake()
	{
		DialogueQueue = new Queue<DialogueElement>();
	}

	void Start()
	{
		
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.fixedTime > 1)
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
		Finished = false;
		
		Animator.SetTrigger("IniciarDialogo");
		
		DialogueQueue.Clear();

		foreach (var element in dialogue.dialogueElements)
		{
			DialogueQueue.Enqueue(element);
		}

		StartCoroutine(DialogueAfterDelay());
	}

	IEnumerator DialogueAfterDelay()
	{
		yield return new WaitForSeconds(1);
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

		AudioSource.clip = dialogElement.audioClip;
		AudioSource.Play();
		print(dialogElement.name);
		if (dialogElement.name == "Narrador" || dialogElement.name == "Nassau")
		{
			if (dialogElement.name == "Nassau")
			{
				Nassau.color = new Color(Nassau.color.r, Nassau.color.g, Nassau.color.b, 1f);
			}
			Guilherme.color = new Color(Guilherme.color.r, Guilherme.color.g, Guilherme.color.b, 0f);
			Cristina.color = new Color(Cristina.color.r, Cristina.color.g, Cristina.color.b, 0f);
		}
		else if (dialogElement.name == "Cristina")
		{
			print("Entrou no if");
			Nassau.color = new Color(Nassau.color.r, Nassau.color.g, Nassau.color.b, 0f);
			Guilherme.color = new Color(Guilherme.color.r, Guilherme.color.g, Guilherme.color.b, 0f);
			Cristina.color = new Color(Cristina.color.r, Cristina.color.g, Cristina.color.b, 1f);
			print(Cristina.color);
		}
		else if (dialogElement.name == "Guilherme")
		{
			Nassau.color = new Color(Nassau.color.r, Nassau.color.g, Nassau.color.b, 0f);
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
		Finished = true;
		StartCoroutine(SceneLoadAfterDelay());
		StartCoroutine(FadeTo(Cristina, 0f, 1f));
	}

	IEnumerator SceneLoadAfterDelay()
	{
		yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneToLoadWhenFinished);
	}
	
	IEnumerator FadeTo(Image image, float targetOpacity, float duration) {

		// Cache the current color of the material, and its initiql opacity.
		Color color = image.color;
		float startOpacity = color.a;

		// Track how many seconds we've been fading.
		float t = 0;

		while(t < duration) {
			// Step the fade forward one frame.
			t += Time.deltaTime;
			// Turn the time into an interpolation factor between 0 and 1.
			float blend = Mathf.Clamp01(t / duration);

			// Blend to the corresponding opacity between start & target.
			color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

			// Apply the resulting color to the material.
			image.color = color;

			// Wait one frame, and repeat.
			yield return null;
		}
	}

}
