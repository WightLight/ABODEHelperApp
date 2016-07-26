using UnityEngine;
using System.Collections;

public class RollDice : Button {
    public const float VERTICAL_ROLL_FACTOR = 2;

	public float maxRollForce = 100;
    public Dicebox dicebox;

//  @TODO refactor to be in its own MonoBehaviour?
    public string label;
    public int modifier = 0;

/*  Accessors
 *  ==========================================================================*/
    public bool Rolling {
		get {  return GetComponent<Die>().rolling; }
	}

    public int Value {
        get {  return GetComponent<Die>().value; }
    }

/*  Unity API
 *  ==========================================================================*/
	void Start () {
		//dice = GetComponent<MyDice>();
		rb = GetComponent<Rigidbody>();
        rolled = false;
		release = delegate(Button b) {
			Roll();
		};
		longPress = delegate(Button b) {
            dicebox.EditDie(this);
		};
	}

    void FixedUpdate() {
        if(rolled && !Rolling) {
            //PopupTextController.CreatePopupText(label, Value, transform);
            PopupManager.instance.ShowPopupText(label, Value, transform.position);
            rolled = false;
        }
    }
	
/*  Public Methods
 *  ==========================================================================*/
    public void Roll() {
        rb.AddForce(new Vector3(Random.Range(-maxRollForce, maxRollForce), VERTICAL_ROLL_FACTOR * maxRollForce, Random.Range(-maxRollForce, maxRollForce)));
        rb.AddTorque(new Vector3(Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce)));
        rolled = true;
    }

/*  Private Members
 *  ==========================================================================*/
	private Rigidbody rb;
    private bool rolled;

}
