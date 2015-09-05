using UnityEngine;
using System.Collections;

public class movement_IA : MonoBehaviour {
	float SPEED = 3.0f;
	Vector3 _movementToApply;
	bool goUp = true;
	float wait_time = 3f;
	bool goAhead = true;
	bool back = false;

	bool IsVisibleFromCamera(Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_movementToApply = new Vector3 ();

		if (goUp == true && back == false && transform.position.y > 5f) {
			goUp = false;
		} else if (goUp == false && back == false && transform.position.y < -5f) {
			goUp = true;
		}

		if (!IsVisibleFromCamera (GetComponent<Renderer> (), Camera.main) || transform.position.x > 7) {
			goAhead = true;
			wait_time = Time.time + 3f;
		} else if (!(transform.position.y > 7) && Time.time >= wait_time) {
			goAhead = true;
			back = true;
		} else goAhead = false;

		if(goAhead == true) moveLeft ();
		if (goUp == true) {
			moveUp ();
		} else {
			moveDown ();
		}

		applyMovement(_movementToApply);
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
