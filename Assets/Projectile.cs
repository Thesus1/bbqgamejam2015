//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public const int DIRECTION_LEFT = 1;
	public const int DIRECTION_RIGHT = 2;

	float SPEED = 20f;
	public float _speed;
	bool _isfire;
	int _direction;
	public int damage;
	public bool isEnemy;
	public int health;


	public Projectile ()
	{
		_isfire = false;
		_direction = DIRECTION_LEFT;
		_speed = SPEED;
	}


	public void setSpeed(float speed)
	{
		_speed = speed;
	}


	public void setDirection(int direction)
	{
		_direction = direction;
	}


	public void startFire()
	{
		_isfire = true;

		if (_direction == DIRECTION_RIGHT)
		{
			transform.Translate(new Vector3(0.8f, 0, 0));
		}
		else transform.Translate(new Vector3(-0.8f, 0, 0));
		Destroy (this.gameObject, 10);
	}


	void Update()
	{
		if (_isfire)
		{
			float realDirection = _speed;

			if(_direction == DIRECTION_LEFT)
			{
				realDirection = -_speed;
			}

			Vector3 movementWithSpeed = new Vector3(realDirection, 0, 0);
			movementWithSpeed *= Time.deltaTime;
			transform.Translate (movementWithSpeed);
		}
	}

	bool damaged(int d)
	{
		health -= d;
		if (health <= 0)
			return true;
		else
			return false;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Ship ship = collider.gameObject.GetComponent<Ship> ();
		if(ship != null)
		{
			if(ship.isEnemy != isEnemy){
				ship.damaged(damage);
				Destroy (this.gameObject);
			}
		}

		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		if (projectile != null) {
			if(damaged (projectile.damage)) {
				if(damage >= 15) SpecialEffectsHelper.Instance.Explosion(transform.position);
				Destroy (this.gameObject);
			}
		}
	}
}
