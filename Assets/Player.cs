using UnityEngine;
using System.Collections;
using Ship;

public class Movements : Ship
{
	int FIRE_KEY_DOWN = 1;
	int FIRE_PRESSED = 2;

	float SPEED = 3.0f;
	float DEADZONE_PAD = 0.8f;
	float MIN_DEADZONE_PAD = 0.6f;

	Vector3 _movementToApply;

	int _fire_mode;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Start called");
		_fire_mode = FIRE_KEY_DOWN;
	}


	// Update is called once per frame
	void Update ()
	{
		_movementToApply = new Vector3 ();

		if(_fire_mode == FIRE_KEY_DOWN)
		{
			if (Input.GetKeyDown (KeyCode.JoystickButton0))
			{
				fire ();
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
				_movementToApply.y = -axisVertical;
			}

			if(Mathf.Abs(axisHorizontal) > MIN_DEADZONE_PAD)
			{
				_movementToApply.x = axisHorizontal;
			}
		}

		applyMovement (_movementToApply);
	}

	void moveUp()
	{
		_movementToApply.y += 1;
	}

	void moveDown()
	{
		_movementToApply.y += -1;
	}

	void moveLeft()
	{
		_movementToApply.x += -1;
	}

	void moveRight()
	{
		_movementToApply.x += 1;
	}


	void applyMovement(Vector3 axis)
	{
		Vector3 movementWithSpeed = axis * SPEED;
		movementWithSpeed *= Time.deltaTime;
		transform.Translate (movementWithSpeed);
	}


	void fire()
	{
		Debug.Log ("Fire !");
	}
}
