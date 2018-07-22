using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
    private bool _isNight;

	[SerializeField] private GameObject particlePrefab;
	[SerializeField] private List<Transform> positions; 
	
	// Use this for initialization
	void Start () {
		Invoke("ActivateNight", 80);
	}
	
	private void ActivateNight(){
		foreach(var position in positions)
		{
			Instantiate(particlePrefab, position.position, position.rotation);
		}
	}
	
}
