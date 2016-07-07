using UnityEngine;
using System.Collections;

/**
 *  Waypoints description
 */
public class Waypoint : MonoBehaviour {

/*  Public Methods
 *  ==========================================================================*/
    public void FlyAndRotateTo(GameObject obj, float milliseconds = 1000.0f) {
        FlyTo(obj, milliseconds);
        RotateTo(obj, milliseconds);
    }

    public void FlyTo(GameObject obj, float milliseconds = 1000.0f) {
        StartCoroutine(FlyToStep(obj, milliseconds / 1000.0f));
    }

    public void RotateTo(GameObject obj, float milliseconds = 1000.0f) {
        StartCoroutine(RotateToStep(obj, milliseconds / 1000.0f));
    }

    public void GoToAndFace(GameObject obj) {
        GoTo(obj);
        Face(obj);
    }

    public void GoTo(GameObject obj) {
        obj.transform.position = this.transform.position;
    }

    public void Face(GameObject obj) {
        obj.transform.rotation = this.transform.rotation;
    }
    
/*  Private Methods
 *  ==========================================================================*/
    private IEnumerator FlyToStep(GameObject obj, float totalTime) {
        Vector3 start = obj.transform.position;
        Vector3 end   = this.transform.position;
        float t = 0.0f;
        
        while(t < totalTime) {
            t += Time.deltaTime * Time.timeScale;
            obj.transform.position = Vector3.Lerp(start, end, t / totalTime);
            yield return 0;
        }
    }

    private IEnumerator RotateToStep(GameObject obj, float totalTime) {
        Quaternion start = obj.transform.rotation;
        Quaternion end   = this.transform.rotation;
        float t = 0.0f;
        
        while(t < totalTime) {
            t += Time.deltaTime * Time.timeScale;
            obj.transform.rotation = Quaternion.Lerp(start, end, t / totalTime);
            yield return 0;
        }
    }
}
