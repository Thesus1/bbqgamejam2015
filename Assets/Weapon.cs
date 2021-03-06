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

public class Weapon
{
	float _nextFire;
	float _fireRate = 0.25f;
	GameObject _projectile;
	Ship _parent;
	int _projectileDirection;
	public int damage;

	public Weapon (Ship parent, float fireRate, string name)
	{
		_fireRate = fireRate;
		_parent = parent;
		_nextFire = 0.0f;
		_projectile = GameObject.Find (name);
		_projectileDirection = 0;
	}


	public void setFireRate(float fireRate)
	{
		_fireRate = fireRate;
	}

	public void setDirection(int direction)
	{
		_projectileDirection = direction;
	}


	protected void setProjectile(GameObject projectile)
	{
		_projectile = projectile;
	}


	public void fire()
	{
		if (Time.time > _nextFire)
		{
			_nextFire = Time.time + _fireRate;
			_parent.createProjectile(_projectile, _projectileDirection);
		}
	}
}

