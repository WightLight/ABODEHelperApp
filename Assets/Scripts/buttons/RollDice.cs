using UnityEngine;
using System.Collections;

public class RollDice : Button {
    public const float VERTICAL_ROLL_FACTOR = 2;

	public float maxRollForce = 100;
    public Dicebox dicebox;

/*  Accessors
 *  ==========================================================================*/
    public bool Rolling {
		get {  return !rb.IsSleeping(); }
	}

/*  Unity API
 *  ==========================================================================*/
	void Start () {
		//dice = GetComponent<MyDice>();
		rb = GetComponent<Rigidbody>();
		release = delegate(Button b) {
			Roll();
		};
		longPress = delegate(Button b) {
            dicebox.EditDie(this);
		};
	}
	
/*  Public Methods
 *  ==========================================================================*/
    public void Roll() {
        rb.AddForce(new Vector3(Random.Range(-maxRollForce, maxRollForce), VERTICAL_ROLL_FACTOR * maxRollForce, Random.Range(-maxRollForce, maxRollForce)));
        rb.AddTorque(new Vector3(Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce)));
    }

/*  Private Members
 *  ==========================================================================*/
	private Rigidbody rb;

}
