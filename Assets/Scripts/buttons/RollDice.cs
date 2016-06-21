using UnityEngine;
using System.Collections;

public class RollDice : Button {
	public const float VERTICAL_ROLL_FACTOR = 2;

	public float maxRollForce = 100;
    
    public bool Rolling {
		get {  return !rb.IsSleeping(); }
	}
    
	void Start () {
		//dice = GetComponent<MyDice>();
		rb = GetComponent<Rigidbody>();
		action = delegate(Button b) {
			Roll();
		};
	}
	
<<<<<<< HEAD
    public void Roll() {
=======
	public void Roll() {
>>>>>>> origin/develop
	    if(!Rolling) {
			rb.AddForce(new Vector3(Random.Range(-maxRollForce, maxRollForce), VERTICAL_ROLL_FACTOR * maxRollForce, Random.Range(-maxRollForce, maxRollForce)));
			rb.AddTorque(new Vector3(Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce)));
		}
	}

	//private MyDice dice;
	private Rigidbody rb;
}
