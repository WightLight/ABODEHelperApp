using UnityEngine;
using System.Collections;

/**
 *  The callback for the button.
 *  @param b The button calling the callback.  Used if the button changes state.
 */
public delegate void ButtonAction(Button b);

public class Button : MonoBehaviour {
    public bool active;

/*  Unity API
 *  ==========================================================================*/
	void Update() {
	    if(active && Input.GetMouseButtonDown(0))
	        action(this);
	}
	
/*  Private Members
 *  ==========================================================================*/
    protected ButtonAction action;
}
