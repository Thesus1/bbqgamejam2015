using UnityEngine;
using System.Collections;

public class Player : Ship
{
	int FIRE_KEY_DOWN = 1;
	int FIRE_PRESSED = 2;
	
	float DEADZONE_PAD = 0.8f;
	float MIN_DEADZONE_PAD = 0.7f;

	int _fire_mode;
	Weapon _gun;
	Weapon _shootgun;
	Weapon _minigun;
	Weapon _canon;

	public int level = 3;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Start called");
		_fire_mode = FIRE_PRESSED;
		setLimitedTodScreen (true);
		isEnemy = false;

		_gun = new Weapon (this, 0.4f, "gun");
		_gun.setDirection (Projectile.DIRECTION_RIGHT);
		_shootgun = new Weapon (this, 0.5f, "shootgun");
		_shootgun.setDirection (Projectile.DIRECTION_RIGHT);
		_minigun = new Weapon (this, 0.15f, "minigun");
		_minigun.setDirection (Projectile.DIRECTION_RIGHT);
		_canon = new Weapon (this, 1f, "canon");
		_canon.setDirection (Projectile.DIRECTION_RIGHT);
	}


	// Update is called once per frame
	void Update ()
	{
		initMovement();

		if (Input.GetKey (KeyCode.UpArrow))
			moveUp ();
		else if (Input.GetKey (KeyCode.DownArrow))
			moveDown ();
		if (Input.GetKey (KeyCode.LeftArrow))
			moveLeft ();
		else if (Input.GetKey (KeyCode.RightArrow))
			moveRight ();

		//A
		if(_fire_mode == FIRE_KEY_DOWN)
		{
			if (Input.GetKey (KeyCode.JoystickButton0) || Input.GetKey (KeyCode.A))
			{
				type_weapon = 1;
				if(level < 5) _gun.fire ();
			}
		}
		else if (_fire_mode == FIRE_PRESSED)
		{
			if(Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey (KeyCode.A))
			{
				type_weapon = 1;
				if(level < 5) _gun.fire ();
			}
		}

		//B
		if(Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.Z))
		{
			type_weapon = 5;
			if(level < 4) _shootgun.fire ();
		}

		//X
		if(Input.GetKey (KeyCode.JoystickButton2) || Input.GetKey (KeyCode.E))
		{
			type_weapon = 3;
			if(level < 3) _minigun.fire ();
		}

		//Y
		if(Input.GetKey (KeyCode.JoystickButton3) || Input.GetKey (KeyCode.R))
		{
			type_weapon = 2;
			if(level < 2) _canon.fire ();
		}

		//Osef
		/*if(Input.GetKey (KeyCode.JoystickButton4))
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
		}*/

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
