using UnityEngine;
using System.Collections;

/**
 *  This manager will send a raycast at each click.  If the ray hits something,
 *  we check to see if the object is a button.  If so, we click it.
 *  ***************************************************************************/
public class ButtonManager : MonoBehaviour {
	public const float longPressThreshold = 1.5f; // in seconds (?)

	public Camera cam;
	
	void Update () {
	//  Using a simple raycast
		if(Input.GetMouseButtonDown(0)) {
			longPressCounter = 0;
			longPressed = false;
			if(Cast(out button))
				button.Press();
		}

		if(Input.GetMouseButtonUp(0)) {
			if(!longPressed && Cast (out button))
				button.Release();
			longPressed = false;
		}

		if(Input.GetMouseButton(0)) {
			Button b;
			if(!longPressed && Cast (out b)) {
				if(b == button)
					longPressCounter += Time.deltaTime / Time.timeScale;
				else
					longPressCounter = 0;
				if(longPressCounter >= longPressThreshold) {
					button.LongPress();
					longPressed = true;
				}
			}
		}

	}

	private Button button;
	private float longPressCounter;
	private bool longPressed;
	private bool Cast(out Button button) {
		RaycastHit hitInfo = new RaycastHit();
		if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo)) {
			Button b = hitInfo.collider.gameObject.GetComponent<Button>();
			if(b != null) {
				button = b;
				return true;
			}
		}

		button = null;
		return false;
	}
}