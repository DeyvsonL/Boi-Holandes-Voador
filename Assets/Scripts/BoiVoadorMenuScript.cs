using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiVoadorMenuScript : MonoBehaviour {

	public float Frequency;  // Speed of sine movement
	public float Magnitude;   // Size of sine movement
	
	// Use this for initialization
	void Start () {
		Frequency = 1.0f;
		Magnitude = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + transform.up * Mathf.Sin (Time.time * Frequency) * Magnitude;
	}
}
