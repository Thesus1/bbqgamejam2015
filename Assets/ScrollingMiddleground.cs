using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class ScrollingMiddleground : MonoBehaviour
{
	private List<Transform> backgroundPart;
	System.Random rand = new System.Random ();
	
	bool IsVisibleFromCamera(Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
	
	void Start() {
		backgroundPart = new List<Transform>();
		
		//Récupération
		for(int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			if(child.GetComponent<Renderer>() != null) {
				backgroundPart.Add(child);
			}
		}
		
		//Tri
		backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(-1.5f, 0, 0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		Transform firstChild = backgroundPart.FirstOrDefault();
		if(firstChild != null) if(firstChild.position.x < Camera.main.transform.position.x) {
			if(IsVisibleFromCamera(firstChild.GetComponent<Renderer>(), Camera.main) == false) {
				Transform lastChild = backgroundPart.LastOrDefault();
				
				Vector3 lastPosition = lastChild.transform.position;
				Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

				firstChild.position = new Vector3(lastPosition.x + lastSize.x + rand.Next () % 15,
				                                  firstChild.position.y,
				                                  firstChild.position.z);
				
				backgroundPart.Remove(firstChild);
				backgroundPart.Add(firstChild);
			}
		}
	}
}
