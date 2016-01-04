using UnityEngine;
using System.Collections;

public class BookFrontButton : Button {
	public MenuBook menuBook;

/*  Unity API
 *  ==========================================================================*/
	void Start () {
		action = delegate(Button b) {
			if(menuBook.currentOpenPage == 0)
				menuBook.currentOpenPage = 1;
			else
				menuBook.currentOpenPage = 0;
		};
	}
}
