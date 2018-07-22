using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		UpdateBridgeHealth();
		_maxHealth = _health;
		HealthBar.fillAmount = _health / _maxHealth;
	}

	private void UpdateBridgeHealth()
	{
		_health = 0;
		
		foreach(var segment in _bridgeRoadSegments)
		{
			_health += (int)segment.SegmentStatus;
		}
		
		foreach(var segment in _bridgePierSegments)
		{
			print(segment.SegmentStatus);
			_health += (int)segment.SegmentStatus;
		}
		
		print("Current health:" + _health);
		
		if (_health <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		print("Game Over!");
		PauseGame();
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
		print("fill amount: " + HealthBar.fillAmount);
	}
}
