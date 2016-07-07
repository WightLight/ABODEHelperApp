using UnityEngine;
using System.Collections;

/**
 *  Lookpoint
 */
public class Lookpoint : Waypoint {
    [SerializeField] private Camera cam;

/*  Accessors
 *  ==========================================================================*/
    public Camera Cam {
        get {
            if(this.cam == null)
                return Camera.main;
            else
                return this.cam;
        }
        set {
            this.cam = value;
        }
    }

/*  Public Methods
 *  ==========================================================================*/
    public void Look(float milliseconds = 1000.0f) {
        FlyAndRotateTo(this.Cam.gameObject, milliseconds);
    }
}
