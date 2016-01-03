using UnityEngine;
using System.Collections;

/**
 *  Use this class to test if clicking action on a button is functioning.
 *  Just attach the script to the object.
 * 
 *  It will display the text when clicked.
 *  ***************************************************************************/
public class TestButton : Button {
	public string text;

/*  Unity API
 *  ==========================================================================*/
	void Start () {
	    action = delegate(Button b) {
	        Debug.Log(text);
	    };
	}
	
}
