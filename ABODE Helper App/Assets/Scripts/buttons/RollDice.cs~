using UnityEngine;
using System.Collections;

public class RollDice : Button {
	void Start () {
		dice = GetComponent<MyDice>();
		action = delegate(Button b) {
			dice.Roll();
		};
	}

	private MyDice dice;
}
