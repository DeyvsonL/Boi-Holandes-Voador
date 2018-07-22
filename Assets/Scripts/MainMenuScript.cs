using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	
	public GameObject TutorialPergaminho;
	public GameObject Boi;

	public GameObject StartButton;
	public GameObject TutorialButton;
	public GameObject CreditsButton;

	public GameObject VoltarCreditsButton;
	public GameObject VoltarTutorialButton;

	public GameObject CreditsPergaminho;

	private GameObject _previouslySelectedButton;

	public void Start()
	{
		_previouslySelectedButton = StartButton;
		
		TutorialPergaminho.SetActive(false);
		CreditsPergaminho.SetActive(false);
		Boi.SetActive(true);
		
		VoltarTutorialButton.SetActive(false);
		VoltarCreditsButton.SetActive(false);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("InitialScene");
	}

	public void Tutorial()
	{
		_previouslySelectedButton = TutorialButton;
		
		TutorialPergaminho.SetActive(true);
		Boi.SetActive(false);
		
		StartButton.SetActive(false);
		TutorialButton.SetActive(false);
		CreditsButton.SetActive(false);
		
		VoltarTutorialButton.SetActive(true);
		VoltarTutorialButton.GetComponent<Button>().Select ();
		VoltarTutorialButton.GetComponent<Button>().OnSelect (null);
	}

	public void VoltarTutorial()
	{
		TutorialPergaminho.SetActive(false);
		Boi.SetActive(true);
		
		StartButton.SetActive(true);
		TutorialButton.SetActive(true);
		CreditsButton.SetActive(true);
		
		VoltarTutorialButton.SetActive(false);
		
		_previouslySelectedButton.GetComponent<Button>().Select ();
		_previouslySelectedButton.GetComponent<Button>().OnSelect (null);
	}

	public void Credits()
	{
		_previouslySelectedButton = CreditsButton;
		
		CreditsPergaminho.SetActive(true);
		Boi.SetActive(false);
		
		StartButton.SetActive(false);
		TutorialButton.SetActive(false);
		CreditsButton.SetActive(false);
		
		VoltarCreditsButton.SetActive(true);
		
		VoltarCreditsButton.GetComponent<Button>().Select ();
		VoltarCreditsButton.GetComponent<Button>().OnSelect (null);
	}

	public void VoltarCredits()
	{
		
		CreditsPergaminho.SetActive(false);
		Boi.SetActive(true);
		
		StartButton.SetActive(true);
		TutorialButton.SetActive(true);
		CreditsButton.SetActive(true);
		
		VoltarCreditsButton.SetActive(false);
		
		_previouslySelectedButton.GetComponent<Button>().Select ();
		_previouslySelectedButton.GetComponent<Button>().OnSelect (null);
	}

	public void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
	}
	
}
