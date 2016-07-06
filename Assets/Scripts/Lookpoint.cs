using UnityEngine;
using System.Collections;

/**
 *  This manager will send a raycast at each click.  If the ray hits something,
 *  we check to see if the object is a button.  If so, we click it.
 *  ***************************************************************************/
public class Lookpoint : MonoBehaviour {
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
    public void FlyTo(float milliseconds = 1000.0f) {
        if(activeRoutine != null)
            StopCoroutine(activeRoutine);
        activeCamera = this.Cam;
        activeRoutine = StartCoroutine(FlyToStep(milliseconds / 1000.0f));
    }
    
/*  Private Members
 *  ==========================================================================*/
    private Coroutine activeRoutine;
    private Camera activeCamera;

/*  Private Methods
 *  ==========================================================================*/
    private IEnumerator FlyToStep(float totalTime) {
        Vector3 start = activeCamera.transform.position;
        Vector3 end   = this.transform.position;
        Quaternion rotStart = activeCamera.transform.rotation;
        Quaternion rotEnd   = this.transform.rotation;
        float t = 0.0f;

        while(t < totalTime) {
            t += Time.deltaTime * Time.timeScale;
            activeCamera.transform.position = Vector3.Lerp(start, end, t / totalTime);
            activeCamera.transform.rotation = Quaternion.Lerp(rotStart, rotEnd, t / totalTime);
            yield return 0;
        }
        activeRoutine = null;
    }
}
