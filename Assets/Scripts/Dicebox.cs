using UnityEngine;
using System.Collections;

public class Dicebox : MonoBehaviour
{
	public const int MAX_DICE = 10;

    public Transform DieSpawnPoint;
    public GameObject D10Prefab;
	public GameObject[] initialDice;

	public BoundedList<GameObject> Dice;

/*  Unity API
 *  ==========================================================================*/
	void Start ()
    {
		initDice();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

/*  Public Methods
 *  ==========================================================================*/
    //If there's an empty space in the Dicebox, add a new d10.
    public void NewD10()
    {
		if(Dice.Count < Dice.Capacity) {
			GameObject newDie = Instantiate(D10Prefab, DieSpawnPoint.position, DieSpawnPoint.rotation) as GameObject;
			newDie.transform.parent = DieSpawnPoint;
            newDie.GetComponent<RollDice>().camera = (Lookpointer) FindObjectOfType(typeof(Lookpointer));
			Dice.Add(newDie);
		}
    }

    //Rolls every die in the Dicebox's Dice array.
    //Better than Timothy's version! :3
    public void RollAll()
    {
        foreach(GameObject die in Dice)
        {
            die.GetComponent<RollDice>().Roll();
        }
    }

/*  Private Methods
 *  ==========================================================================*/
	private void initDice() {
		Dice = new BoundedList<GameObject>(MAX_DICE);
		foreach(GameObject die in initialDice)
			Dice.Add(die);
	}
}