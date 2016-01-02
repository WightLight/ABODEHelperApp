using UnityEngine;
using System.Collections;

public class MenuBook : MonoBehaviour
{
	// Int for the last numbered page, used to count how many book states there are.
	public int pageCount = 3;

	// Int for which page of the book is open. 0 is closed, 1 is first page, etc.
	public int currentOpenPage = 0;

	// Animators for each moving part of the book.
	public Animator frontCoverAnimator;

	// Use this for initialization
	void Start ()
	{
		frontCoverAnimator = GameObject.Find("Front Cover").GetComponent<Animator>();
		frontCoverAnimator.SetInteger("Page Open",0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Manually go to page 1.
		if (Input.GetKeyDown(KeyCode.Return))
		{
			currentOpenPage = 1;
		}
		// Manually close book.
		if (Input.GetKeyDown(KeyCode.Space))
		{
			currentOpenPage = 0;
		}

		// Tell the book's pieces animators to reflect the current page to go to.
		switch(currentOpenPage)
		{
			case 0:
				frontCoverAnimator.SetInteger("Page Open",0);
				break;
			case 1:
				frontCoverAnimator.SetInteger("Page Open",1);
				break;
			case 2:
				frontCoverAnimator.SetInteger("Page Open",2);
				break;
			case 3:
				frontCoverAnimator.SetInteger("Page Open",3);
				break;
		}
	}

	// Move to the next page if we're not at the end of the book.
	void NextPage ()
	{
		if(currentOpenPage < pageCount)
		{
			currentOpenPage++;
		}
	}

	// Move to the previous page if we're not at the front cover.
	void PreviousPage ()
	{
		if(currentOpenPage > 0)
		{
			currentOpenPage--;
		}
	}
}
