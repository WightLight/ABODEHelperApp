using UnityEngine;
using System.Collections;

public class RemoveDie : Button {
    public Dicebox dicebox;
    
/*  Accessors
 *  ==========================================================================*/
    
/*  Unity API
 *  ==========================================================================*/
    void Start () {
        longPress = delegate(Button b) {
            dicebox.RemoveCurrentDie();
        };
    }
    
/*  Public Methods
 *  ==========================================================================*/

    
/*  Private Members
 *  ==========================================================================*/

}
