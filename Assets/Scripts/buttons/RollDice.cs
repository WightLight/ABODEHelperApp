using UnityEngine;
using System.Collections;

public class RollDice : Button {
	void Start () {
		dice = GetComponent<Dice>();
		action = delegate(Button b) {
			dice.Roll();
		};
	}

	private Dice dice;
}
