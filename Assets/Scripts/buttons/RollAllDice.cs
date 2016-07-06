using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RollAllDice : Button {
	public RollDice[] initialDice;

/*  Unity API
 *  ==========================================================================*/
	void Start () {
		initDiceList();
		action = delegate(Button b) {
			RollAll();
		};
	}

/*  Public Methods
 *  ==========================================================================*/
	public void RollAll() {
		foreach(RollDice die in dice)
			die.Roll();
	}

/*  Private Members
 *  ==========================================================================*/
	private List<RollDice> dice;

/*  Private Methods
 *  ==========================================================================*/
	private void initDiceList() {
		dice = new List<RollDice>();
		dice.AddRange(initialDice);
	}
}
