using UnityEngine;
using System.Collections;

/**
 *  Represents a single die block.  This is an abstract class and ought to be
 *  overriden with classes representing dX, where X is the number of sides.
 * 
 *  Override the ValueFromRotation method for each dX.  The idea is to extract
 *  the numerical value from rotation.  This is a complex operation, so we
 *  cache the result and reset the cache every time the die is rolled.
 *  ***************************************************************************/
abstract public class MyDice : MonoBehaviour {
	public const float VERTICAL_ROLL_FACTOR = 2;

	public float maxRollForce = 100;

	public bool Rolling {
		get {  return !rb.IsSleeping(); }
	}

/*  To Override
 *  ==========================================================================*/
/**
 *  Gets the value of the block given rotation values.  This needs to be overridden.
 */
	abstract protected int ValueFromRotation();

/*  Unity API
 *  ==========================================================================*/
	void Start () {
		rb = GetComponent<Rigidbody>();
		ResetCache();
	}

/*  Public Methods
 *  ==========================================================================*/
/**
 *  Roll the die block.  Uses physics.
 */
	public void Roll() {
		if(!Rolling) {
			ResetCache();
			rb.AddForce(new Vector3(Random.Range(-maxRollForce, maxRollForce), VERTICAL_ROLL_FACTOR * maxRollForce, Random.Range(-maxRollForce, maxRollForce)));
			rb.AddTorque(new Vector3(Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce), Random.Range(-maxRollForce, maxRollForce)));
		}
	}

/**
 *  Returns the value of the die.  Caches the result.
 */
	public int Value() {
		if(!IsCacheSet())
			SetCache(ValueFromRotation());
		return cachedValue;
	}

/*  Private Members
 *  ==========================================================================*/
	private Rigidbody rb;
	private int cachedValue;

/*  Private Methods
 *  ==========================================================================*/
	private void ResetCache() {
		cachedValue = -1;
	}

	private void SetCache(int n) {
		cachedValue = n;
	}

	private bool IsCacheSet() {
		return cachedValue >= 0;
	}
}