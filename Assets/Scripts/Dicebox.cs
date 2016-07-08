using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public InputField dieEditLabelField;
    public Slider dieEditModifierField;

    public BoundedList<GameObject> Dice;  // NOTE: Another way of doing this is to have 10 dice blocks, but disable ones not being used

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

    public void RemoveDie(GameObject die) {
    //  Param is a GameObject since the bounded list contains game objects
        Dice.Remove(die);
        Destroy(die);
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
        dieBeingEdited = die;

        diePreEditProperties = new DieProperties();
        diePreEditProperties.material = die.GetComponent<Renderer>().material;
        diePreEditProperties.label = die.label;
        diePreEditProperties.modifier = die.modifier;

        InitEditDieFields();

        dieFloatPoint.FlyTo(die.gameObject, editTransitionTime, delegate(GameObject obj) {
            inEditMode = true;
        });
    }

    public void CancelEditDie() {
        RevertEditedDie();
        FinishEditDie();
    }

    public void SubmitEditDie() {
        FinishEditDie();
    }

    public void ChangeDieMaterial(Material material) {
        dieBeingEdited.GetComponent<Renderer>().material = material;
    }

    public void ChangeDieLabel(string label) {
        dieBeingEdited.label = label;
    }

    public void ChangeDieModifier(float modifier) {
        dieBeingEdited.modifier = Mathf.FloorToInt(modifier);
    }

    public void RemoveCurrentDie() {
        if(inEditMode) {
        //  We do not continue unless in Edit mode since unless the dicebox is in edit mode, the dieBeingEdited is undefined
            RemoveDie(dieBeingEdited.gameObject);
            ReturnToBox();
        }
    }

/*  Private Members
 *  ==========================================================================*/
    private bool inEditMode;
    private RollDice dieBeingEdited;
    private DieProperties diePreEditProperties;

/*  Private Methods
 *  ==========================================================================*/
	private void initDice() {
		Dice = new BoundedList<GameObject>(MAX_DICE);
		foreach(GameObject die in initialDice)
			Dice.Add(die);
	}

/**
 *  Makes the edit fields match what the die currently has when an edit action is started.
 */
    private void InitEditDieFields() {
        dieEditLabelField.text = dieBeingEdited.label;
        dieEditModifierField.value = dieBeingEdited.modifier;
    }

    private void RevertEditedDie() {
        ChangeDieMaterial(diePreEditProperties.material);
        ChangeDieLabel(diePreEditProperties.label);
        ChangeDieModifier(diePreEditProperties.modifier);
    }

    private void FinishEditDie() {
        ReturnToBox();
        ReturnDieToBox();
    }

    private void ReturnDieToBox() {
        DieSpawnPoint.GetComponent<Waypoint>().FlyTo(dieBeingEdited.gameObject, editTransitionTime, delegate(GameObject obj) {
            dieBeingEdited.GetComponent<Rigidbody>().useGravity = true;
            dieBeingEdited.GetComponent<Collider>().enabled = true;
            dieBeingEdited.Activate();
        });
    }

    private void ReturnToBox() {
        diceboxLookpoint.Look(editTransitionTime);
        inEditMode = false;
    }

/*  Private Classes
 *  ==========================================================================*/
/**
 *  This is used to memorize die properties.  When cancelling, we invoke
 *  these in order to revert the die back to its original state.
 */
    private class DieProperties {
        public Material material;
        public string label;
        public int modifier;

        public DieProperties() {}
    }
}