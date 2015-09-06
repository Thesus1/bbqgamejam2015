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

public class Ship : Movements
{
	public const float DEFAULT_SIZE_VERTICAL_UP = 4.58f;
	public const float DEFAULT_SIZE_VERTICAL_DOWN = 3f;
	public const float DEFAULT_SIZE_HORIZONTAL = 8.55f;
	float _sizeVertical;
	float _sizeHorizontal;
	bool _isLimitedToScreen = false;
	public bool isEnemy;
	public int health = 1;
	public Weapon _weapon;

	public Ship ()
	{
		_sizeVertical = DEFAULT_SIZE_VERTICAL_UP;
		_sizeHorizontal = DEFAULT_SIZE_HORIZONTAL;
		_isLimitedToScreen = false;
	}
	
	public void setLimitedTodScreen(bool limited)
	{
		_isLimitedToScreen = limited;
	}


	public void setSize(float sizeVertical, float sizeHorizontal)
	{
		_sizeVertical = sizeVertical;
		_sizeHorizontal = sizeHorizontal;
	}

	public void damaged (int d)
	{
		health -= d;
		if (health <= 0) {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy(this.gameObject);
		}
	}

	protected void applyMovement()
	{
		if (_isLimitedToScreen)
		{
			Vector3 movementWithSpeed = _movementToApply * SPEED;
			movementWithSpeed *= Time.deltaTime;

			if (_movementToApply.y > 0 && transform.position.y > _sizeVertical) {
				_movementToApply.y = 0;
			} else if (_movementToApply.y < 0 && transform.position.y < -DEFAULT_SIZE_VERTICAL_DOWN) {
				_movementToApply.y = 0;
			}

			if (_movementToApply.x > 0 && transform.position.x > _sizeHorizontal) {
				_movementToApply.x = 0;
			} else if (_movementToApply.x < 0 && transform.position.x < -_sizeHorizontal) {
				_movementToApply.x = 0;
			}
		}
		base.applyMovement();
	}

	
	protected void fire()
	{
		if (_weapon != null)
		{
			_weapon.fire();
		}
		else
		{
			Debug.Log("_weapon is null");
		}
	}

	public void createProjectile(GameObject projectile, int direction)
	{
		Object newBullet = Instantiate (projectile, transform.position, transform.rotation);

		if(newBullet is GameObject)
		{
			Projectile scriptBullet = ((GameObject) newBullet).GetComponent<Projectile>();

			if(scriptBullet != null)
			{
				scriptBullet.isEnemy = isEnemy;
				if(direction != 0)
				{
					scriptBullet.setDirection(direction);
				}

				scriptBullet.startFire();
			}
		}
	}
}