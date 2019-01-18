using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMatChanger : Selectable {

    public Material normalMat;
    public Material selectedMat;
    public Button b;
    public Image i;
    private bool selected;
    BaseEventData bED;
    public Menu menu;
    public int number;
	
	void Update ()
    {
        if (IsHighlighted(bED)) //true if mouse is over ui element
        {
            selected = true;
            i.material = selectedMat;
        }
        if (selected && Input.GetButtonDown("Fire1"))
        {
            print("external call");
            menu.ExternalCall(number);
            /*i.material = selectedMat;
            selected = false;*/
        }
        if(!IsHighlighted(bED))
        {
            selected = false;
            i.material = normalMat;
        }
	}

}
