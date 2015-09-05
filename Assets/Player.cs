using UnityEngine;
using System.Collections;

public class Player : Ship
{
	int FIRE_KEY_DOWN = 1;
	int FIRE_PRESSED = 2;
	
	float DEADZONE_PAD = 0.8f;
	float MIN_DEADZONE_PAD = 0.7f;

	int _fire_mode;


	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Start called");
		_fire_mode = FIRE_PRESSED;
		_weapon = new Weapon (this);
		setLimitedTodScreen (true);
	}


	// Update is called once per frame
	void Update ()
	{
		initMovement();

		if(_fire_mode == FIRE_KEY_DOWN)
		{
			if (Input.GetKeyDown (KeyCode.JoystickButton0))
			{
				fire();
			}
		}
		else if (_fire_mode == FIRE_PRESSED)
		{
			if(Input.GetKey(KeyCode.JoystickButton0))
			{
				fire();
			}
		}

		if(Input.GetKey (KeyCode.JoystickButton1))
		{
			Debug.Log("B press");
		}
		if(Input.GetKey (KeyCode.JoystickButton2))
		{
			Debug.Log("X press");
		}
		if(Input.GetKey (KeyCode.JoystickButton3))
		{
			Debug.Log("Y press");
		}
		if(Input.GetKey (KeyCode.JoystickButton4))
		{
			Debug.Log("LB press");
		}
		if(Input.GetKey (KeyCode.JoystickButton5))
		{
			Debug.Log("RB press");
		}
		if(Input.GetKey (KeyCode.JoystickButton6))
		{
			Debug.Log("Select press");
		}
		if(Input.GetKey (KeyCode.JoystickButton7))
		{
			Debug.Log("Start press");
		}
		if(Input.GetKey (KeyCode.JoystickButton8))
		{
			Debug.Log("R Stick press");
		}
		if(Input.GetKey (KeyCode.JoystickButton9))
		{
			Debug.Log("L Stick press");
		}

		/// Sticks
		float axisVertical = Input.GetAxis ("Vertical");
		float axisHorizontal = Input.GetAxis ("Horizontal");

		if(Mathf.Abs(axisVertical) > DEADZONE_PAD || Mathf.Abs(axisHorizontal) > DEADZONE_PAD)
		{
			if(Mathf.Abs(axisVertical) > MIN_DEADZONE_PAD)
			{
				moveVertical(axisVertical);
			}

			if(Mathf.Abs(axisHorizontal) > MIN_DEADZONE_PAD)
			{
				moveHorizontal(axisHorizontal);
			}
		}

		applyMovement();
	}
}
