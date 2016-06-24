using UnityEngine;
using System.Collections;

public class DiceD6 : MyDice {

	override protected int ValueFromRotation() {
		return 1;
	}
}
