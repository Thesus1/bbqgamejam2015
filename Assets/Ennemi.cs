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
	public int type_weapon;
	
	void Start(){
		boundTop = 5f;
		boundDown = -3f;
		timeToAttack = 5f;
		isEnemy = true;
		switch (type_weapon) {
		case 1:
			_weapon = new Weapon (this, 5);
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		_movementToApply = new Vector3 ();

		if (transform.position.x > 5) moveLeft ();
		else if(_wait == false) {
			_wait = true;
			timeToGo = Time.time + timeToAttack;
		}

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

		applyMovement ();
	}
}
