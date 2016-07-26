using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceResultPopup : Popup {

	public Animator dieLabelAnimator;
	public Animator rollResultAnimator;
	public float waitTime;

/*  Unity API
 *  ==========================================================================*/
	void Awake() {
		dieLabelText = dieLabelAnimator.GetComponent<Text>();
		rollResultText = rollResultAnimator.GetComponent<Text>();
	}

	void Update() {
	//  Auto-close if the specified time passes
		if (IsOpen ()) {
			curTime += Time.deltaTime * Time.timeScale;
			if (curTime >= waitTime)
				Close ();
		}
	}

/*  Public Methods
 *  ==========================================================================*/
	override public void Open() {
		base.Open();
		StartCloseTimer();
	}

	override public void Close() {
		Destroy(this.gameObject);
	}

	public void SetText(string dieLabel, int dieValue) {
		dieLabelText.text = dieLabel;
		rollResultText.text = dieValue.ToString();
	}

/*  Private Members
 *  ==========================================================================*/
	private Text dieLabelText;
	private Text rollResultText;

	private float curTime;

/*  Private Methods
 *  ==========================================================================*/
	private void StartCloseTimer() {
		curTime = 0;
	}
}
