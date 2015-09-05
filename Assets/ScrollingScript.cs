using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ScrollingScript : MonoBehaviour
{
	private List<Transform> backgroundPart;

	bool IsVisibleFromCamera(Renderer renderer, Camera camera)
	{
		float x_r = renderer.transform.position.x;
		float x_c = camera.transform.position.x;
		float diff = (x_c - x_r);
		if(diff > (float)19.8) {
			return false;
		} else return true;
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
		Vector3 movement = new Vector3(-2, 0, 0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		Transform firstChild = backgroundPart.FirstOrDefault();
		if(firstChild != null) if(firstChild.position.x < Camera.main.transform.position.x) {
			if(IsVisibleFromCamera(firstChild.GetComponent<Renderer>(), Camera.main) == false) {
				Transform lastChild = backgroundPart.LastOrDefault();
				
				Vector3 lastPosition = lastChild.transform.position;
				Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);
				
				firstChild.position = new Vector3(lastPosition.x + lastSize.x,
												  firstChild.position.y,
												  firstChild.position.z);
				
				backgroundPart.Remove(firstChild);
				backgroundPart.Add(firstChild);
			}
		}
	}
}
