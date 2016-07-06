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
    public bool active = true;

/**
 *  Safe accessor for active state.
 */
	public bool Active {
		get {  return active; }
	}

	public bool HasAction {
		get {  return action != null; }
	}

	public bool HasRelease {
		get {  return release != null; }
	}

	public bool HasLongPress {
		get {  return longPress != null; }
	}

/*  Public Members
 *  ==========================================================================*/
/**
 *  Presses the button if it is able to be pressed.
 *  @param force Specify whether to force the button to be pressed.
 */
	public void Press(bool force = false) {
		if(HasAction && (active || force))
			action(this);
	}

/**
 *  Releases the button if it is able to be released
 *  @param force Specify whether to force the button to be released.
 */
	public void Release(bool force = false) {
		if(HasRelease && (active || force))
			release(this);
	}

/**
 *  When the button is pressed and held for a bit, this triggers
 *  @param force Specify whether to force the button to be long pressed
 */
	public void LongPress(bool force = false) {
		if(HasLongPress && (active || force))
			longPress(this);
	}

/**
 *  Activate the button.  Can be overridden if other side effects should be manifest.
 */
	public void Activate() {
		active = true;
	}

/**
 *  Deactivate the button.  Can be overridden if other side effects should be manifest.
 */
	public void Deactivate() {
		active = false;
	}

/**
 *  Toggle the active state.  Activate if inactive, deactivate if active.
 */
	public void Toggle() {
		if(active)
			Deactivate();
		else
			Activate ();
	}

/*  Private Members
 *  ==========================================================================*/
    protected ButtonAction action;
	protected ButtonAction release;
	protected ButtonAction longPress;
}
