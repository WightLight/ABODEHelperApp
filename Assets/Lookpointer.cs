using UnityEngine;
using System.Collections;

public class Lookpointer : MonoBehaviour
{
    public Transform tf;
    public Transform[] lookpoints;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

    //Fly the camera to the lookpoint in question.
    public void FlyTo(int PointNumber)
    {
        tf.position = lookpoints[PointNumber].position;
        tf.rotation = lookpoints[PointNumber].rotation;
    }
}
