using UnityEngine;
using System.Collections;

public class DiceD6 : Dice {

	override protected int ValueFromRotation() {
		return 1;
	}
}
