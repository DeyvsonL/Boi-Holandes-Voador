using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

	public Button StartButton;
	public Button TutorialButton;
	public Button CreditsButton;

	public void Start()
	{
		var newComecarSprite = Resources.Load<Sprite>("Sprites/COMEÇAR_ativo");
		var comecarST = new SpriteState();
		comecarST.disabledSprite = newComecarSprite;
		comecarST.highlightedSprite = newComecarSprite;
		comecarST.pressedSprite = newComecarSprite;
		StartButton.spriteState = comecarST; 
		
		var newTutorialSprite = Resources.Load<Sprite>("Sprites/TUTORIAL_ativo");
		var tutorialST = new SpriteState();
		tutorialST.disabledSprite = newTutorialSprite;
		tutorialST.highlightedSprite = newTutorialSprite;
		tutorialST.pressedSprite = newTutorialSprite;
		TutorialButton.spriteState = tutorialST; 
		
		var newSprite = Resources.Load<Sprite>("Sprites/CREDITOS_ativo");
		var creditosSt = new SpriteState();
		creditosSt.disabledSprite = newSprite;
		creditosSt.highlightedSprite = newSprite;
		creditosSt.pressedSprite = newSprite;
		CreditsButton.spriteState = creditosSt; 
	}

	public void StartGame()
	{
		SceneManager.LoadScene("InitialScene");
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
