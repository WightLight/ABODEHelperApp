using UnityEngine;
using System.Collections;

public class RollDice : Button {
    public const float VERTICAL_ROLL_FACTOR = 2;

	public float maxRollForce = 100;
    public Dicebox dicebox;

//  @TODO refactor to be in its own MonoBehaviour?
    public string label;
    public int modifier = 0;

	public DiceResultPopup resultPopupTemplate;

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
			RectTransform rect = dicebox.diceResultCanvas.GetComponent<RectTransform>();
			Vector2 viewportPosition = Camera.main.WorldToViewportPoint(this.transform.position);
			Vector3 truePosition = new Vector3((viewportPosition.x * rect.sizeDelta.x) - (rect.sizeDelta.x * 0.5f), (viewportPosition.y * rect.sizeDelta.y) - (rect.sizeDelta.y * 0.5f), 0);
			DiceResultPopup p = Popup.ShowNew<DiceResultPopup>(resultPopupTemplate, Camera.main.WorldToScreenPoint(this.transform.position), Quaternion.identity);
			//p.GetComponent<RectTransform>().anchoredPosition = truePosition;
			p.Canvas = dicebox.diceResultCanvas;
			p.SetText("TEST", 7);
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
