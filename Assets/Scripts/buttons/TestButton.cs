using UnityEngine;
using System.Collections;

public class TestButton : Button {
    
	void Start () {
	    action = delegate(Button b) {
	        Debug.Log("TEST");
	    };
	}
	
}
