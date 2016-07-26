using UnityEngine;
using System.Collections;
using System;

/**
 *  Singleton class
 */
public class PopupManager : MonoBehaviour {
    public static PopupManager instance;

    public Canvas canvas;

    public PopupText popupTextToInstantiate;

/*  Unity API
 *  ==========================================================================*/
    void Start() {
        if(instance == null)
            instance = this;
        else
            throw new Exception("Attempted to instantiate two PopupManagers, but PopupManager is a singleton.");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

/*  Class Methods
 *  ==========================================================================*/
    public void ShowPopupText(string label, int dieNum, Vector3 position) {
        PopupText popup = Instantiate(popupTextToInstantiate) as PopupText;
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(position);
        
        instance.transform.SetParent(canvas.transform, false);
        popup.transform.position = screenPosition;
        popup.SetText(label, dieNum);
    }
}
