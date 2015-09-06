using UnityEngine;
using System.Collections;

public class Ennemi : Ship {
	bool _moveUp = false;
	bool _back = false;
	bool _wait = false;
	float timeToGo;
	public float boundTop;
	public float boundDown;
	public float timeToAttack;
	protected float _horizontal_pos;
	protected bool _onlyHorizontal;

	protected void Start(){
		_onlyHorizontal = false;
		boundTop = 5f;
		boundDown = -3f;
		timeToAttack = 5f;
		isEnemy = true;
		_horizontal_pos = 5.0f;
		switch (type_weapon) {
		case 1:
			_weapon = new Weapon (this, 0.4f, "gun");
			break;
		
		case 2:
			_weapon = new Weapon (this, 1f, "canon");
			break;
			
		case 3:
			_weapon = new Weapon (this, 0.15f, "minigun");
			break;
			
		case 4:
			_weapon = new Weapon (this, 2f, "mine");
			break;
			
		case 5:
			_weapon = new Weapon (this, 0.5f, "shootgun");
			break;
		}
	}

	// Update is called once per frame
	protected void Update () {
		_movementToApply = new Vector3 ();

		if (transform.position.x > _horizontal_pos) {
			moveLeft ();
		}
		else if(_wait == false) {
			_wait = true;
			timeToGo = Time.time + timeToAttack;
		}

		if (_onlyHorizontal == false)
		{
		if(_back == false) {
			if(_moveUp == false && transform.position.y < boundDown) _moveUp = true; 
			else if(_moveUp == true && transform.position.y > boundTop) _moveUp = false;
		}

		if (_wait == true && Time.time > timeToGo) {
			_back = true;
			Destroy(this.gameObject, 20);
		} else if (_wait == true && Time.time < timeToGo) {
			fire ();
		}

		if (_back == true) moveLeft ();
		if (_moveUp == true) moveUp ();
		else moveDown ();
		}

		applyMovement ();
	}
}
