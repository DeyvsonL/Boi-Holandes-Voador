using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FacebookScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FB.Init();
	}

	public void Share()
	{
		FB.ShareLink( 
			new Uri("https://boivoadorpage-boivoador.wedeploy.io/index.html"),
			callback: ShareCallback
		);
	}

	private void ShareCallback(IShareResult result)
	{
		print("Share completed!");
	}

	// Update is called once per frame
	void Update () {
		
	}
	
}
