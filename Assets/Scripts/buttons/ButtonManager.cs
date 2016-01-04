using UnityEngine;
using System.Collections;

/**
 *  This manager will send a raycast at each click.  If the ray hits something,
 *  we check to see if the object is a button.  If so, we click it.
 *  ***************************************************************************/
public class ButtonManager : MonoBehaviour {
	public Camera cam;
	
	void Update () {
	//  Using a simple raycast
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hitInfo = new RaycastHit();
			if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo)) {
				Button b = hitInfo.collider.gameObject.GetComponent<Button>();
			//  Must check for nullness.  If null, collider is not a button.
				if(b != null)
					b.Press();
			}
		}
	}
}