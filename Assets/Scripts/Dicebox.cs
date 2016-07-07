using UnityEngine;
using System.Collections;

public class Dicebox : MonoBehaviour
{
	public const int MAX_DICE = 10;

    public Transform DieSpawnPoint;
    public GameObject D10Prefab;
	public GameObject[] initialDice;

    public float editTransitionTime = 500.0f;
    public Lookpoint diceboxLookpoint;
	public Lookpoint editMenuPoint;
    public Waypoint dieFloatPoint;

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
        if(inEditMode) {
            dieFloatPoint.GoTo(dieBeingEdited.gameObject);
        }
	}

/*  Public Methods
 *  ==========================================================================*/
    //If there's an empty space in the Dicebox, add a new d10.
    public void NewD10()
    {
		if(Dice.Count < Dice.Capacity) {
			GameObject newDie = Instantiate(D10Prefab, DieSpawnPoint.position, DieSpawnPoint.rotation) as GameObject;
			newDie.transform.parent = DieSpawnPoint;
            newDie.GetComponent<RollDice>().dicebox = this;
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

    public void EditDie(RollDice die) {
        editMenuPoint.Look(editTransitionTime);
        die.GetComponent<Rigidbody>().useGravity = false;
        die.GetComponent<Collider>().enabled = false;
        die.Deactivate();

        dieFloatPoint.FlyTo(die.gameObject, editTransitionTime, delegate(GameObject obj) {
            inEditMode = true;
            dieBeingEdited = die;
        });
    }

    public void CancelEditDie() {
        FinishEditDie();
    }

    public void SubmitEditDie() {

    }

/*  Private Members
 *  ==========================================================================*/
    private bool inEditMode;
    private RollDice dieBeingEdited;

/*  Private Methods
 *  ==========================================================================*/
	private void initDice() {
		Dice = new BoundedList<GameObject>(MAX_DICE);
		foreach(GameObject die in initialDice)
			Dice.Add(die);
	}

    private void FinishEditDie() {
        diceboxLookpoint.Look(editTransitionTime);
        inEditMode = false;

        DieSpawnPoint.GetComponent<Waypoint>().FlyTo(dieBeingEdited.gameObject, editTransitionTime, delegate(GameObject obj) {
            dieBeingEdited.GetComponent<Rigidbody>().useGravity = true;
            dieBeingEdited.GetComponent<Collider>().enabled = true;
            dieBeingEdited.Activate();
        });
    }
}