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


	public Weapon (Ship parent)
	{
		_parent = parent;
		_nextFire = 0.0f;
		_projectile = GameObject.Find ("projectile_test");
	}


	public void setFireRate(float fireRate)
	{
		_fireRate = fireRate;
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
			_parent.createProjectile(_projectile);

		}
	}
}
