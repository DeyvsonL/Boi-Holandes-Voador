using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Lang;

public class FacebookScript : MonoBehaviour
{
	public GameObject ShareButton;
	
	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.Android ||
		    Application.platform == RuntimePlatform.IPhonePlayer)
		{
			FB.Init();
		}
		else
		{
			ShareButton.SetActive(false);
		}
	}

	public void Share()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.Android ||
		    Application.platform == RuntimePlatform.IPhonePlayer)
		{
			FB.ShareLink( 
				new Uri("https://boivoadorpage-boivoador.wedeploy.io/index.html"),
				callback: ShareCallback
			);
		}
	}

	private void ShareCallback(IShareResult result)
	{
		print("Share completed!");
	}

	// Update is called once per frame
	void Update () {
		
	}
	
}
