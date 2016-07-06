using UnityEngine;
using System.Collections;

public class DieActions : MonoBehaviour {
	public const float VERTICAL_ROLL_FACTOR = 2;
	
	public float maxRollForce = 100;
	
	public bool Rolling {
		get {  return !rb.IsSleeping(); }
	}
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	public void Roll() {
		Debug.Log("HELLO");
		rb.AddForce(new Vector3(Random.Range(-maxRollForce, maxRollForce), VERTICAL_ROLL_FACTOR * maxRollForce, Random.Range(-maxRollForce, maxRollForce)));
		rb.AddTorque(new Vector3(Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce)));
	}

	private Rigidbody rb;
}
