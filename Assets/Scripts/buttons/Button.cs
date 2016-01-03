using UnityEngine;
using System.Collections;

/**
 *  The callback for the button.
 *  @param b The button calling the callback.  Used if the button changes state.
 */
public delegate void ButtonAction(Button b);

/**
 *  To make a button, extend this class and assign the action as a delegate.
 *  Essentially, make sure you have the following method defined.
 * 
    void Start () {
	    action = delegate(Button b) {
		//  IMPLEMENTATION HERE
	    };
	}
 * 
 *  The parameter is the button itself, in case the button's state changes as
 *  a result of the callback.
 *  ***************************************************************************/
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
