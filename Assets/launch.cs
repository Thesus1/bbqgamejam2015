﻿using UnityEngine;
using System.Collections;

public class launch : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit();
			return;
		}

		if(Input.GetKey ("enter") || Input.GetKey (KeyCode.Space))
		{
			Application.LoadLevel("scene");
		}
	}
}
