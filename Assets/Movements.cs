using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{
	float SPEED = 2.5f;
	Vector3 _movementToApply;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Start called");
	}
	
	// Update is called once per frame
	void Update ()
	{
		_movementToApply = new Vector3 ();

		if(Input.GetKey(KeyCode.JoystickButton0))
		{
			Debug.Log("A press");
			moveDown();
		}
		if(Input.GetKey (KeyCode.JoystickButton1))
		{
			Debug.Log("B press");
			moveRight();
		}
		if(Input.GetKey (KeyCode.JoystickButton2))
		{
			Debug.Log("X press");
			moveLeft();
		}
		if(Input.GetKey (KeyCode.JoystickButton3))
		{
			Debug.Log("Y press");
			moveUp();
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
}
