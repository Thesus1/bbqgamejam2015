using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	float timeRestart;

	// Use this for initialization
	void Start () {
		timeRestart = -1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timeRestart != -1 && Time.realtimeSinceStartup > timeRestart)
		{
			timeRestart = -1;
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKey (KeyCode.JoystickButton6))
		{
			Application.LoadLevel(Application.loadedLevel);
			Debug.Log("Select press");
		}
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void playerDied()
	{
		Debug.Log ("Player died");
		timeRestart = Time.realtimeSinceStartup + 4;
	}
}
