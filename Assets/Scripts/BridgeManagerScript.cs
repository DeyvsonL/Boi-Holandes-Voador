using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BridgeManagerScript : MonoBehaviour
{
	[SerializeField] private List<BridgeSegmentScript> _bridgeRoadSegments = new List<BridgeSegmentScript>();
	[SerializeField] private List<BridgeSegmentScript> _bridgePierSegments = new List<BridgeSegmentScript>();
	
	private float _health;
	private float _maxHealth;
	public Image HealthBar;

	public bool Paused;

	// Use this for initialization
	private void Start ()
	{
		GetMaxHealth();
		UpdateBridgeHealth();
		HealthBar.fillAmount = _health / _maxHealth;
	}

	private void GetMaxHealth()
	{
		foreach(var segment in _bridgeRoadSegments)
		{
			_maxHealth += (int)BridgeSegmentScript.SegmentStatusEnum.Destroyed;
		}

		foreach(var segment in _bridgePierSegments)
		{
			_maxHealth += (int)BridgeSegmentScript.SegmentStatusEnum.Destroyed;
		}

		_maxHealth = _maxHealth/2 - 1;
	}

	private void UpdateBridgeHealth()
	{
		_health = _maxHealth;
		
		foreach(var segment in _bridgeRoadSegments)
		{
			_health -= (int)segment.SegmentStatus;
		}

		foreach(var segment in _bridgePierSegments)
		{
			_health -= (int)segment.SegmentStatus;
		}
		
		if (_health <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		//PauseGame();
		SceneManager.LoadScene("GameOverScene");
	}

	private void PauseGame()
	{
		Paused = !Paused;
				
		BoiVoadorScript.Paused = Paused;
		PlayerScript.Paused = Paused;
		BridgeSegmentScript.Paused = Paused;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
		
		if (Paused) return;
		
		UpdateBridgeHealth();
		HealthBar.fillAmount = _health / _maxHealth;
	//	print("fill amount: " + HealthBar.fillAmount);
	}
}
