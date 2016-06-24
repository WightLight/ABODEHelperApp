using UnityEngine;
using System.Collections;

public class Dicebox : MonoBehaviour
{
    public Transform DieSpawnPoint;
    public GameObject D10Prefab;
    public GameObject[] Dice = new GameObject[10];

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    //If there's an empty space in the Dicebox, add a new d10.
    public void NewD10()
    {
        for(int i = 0; i < Dice.Length; i++)
        {
            if(Dice[i] == null)
            {
                GameObject D10Clone = Instantiate(D10Prefab, DieSpawnPoint.position, DieSpawnPoint.rotation) as GameObject;
                D10Clone.transform.parent = DieSpawnPoint;
                Dice[i] = D10Clone;
                break;
            }
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
}