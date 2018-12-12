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
	
	void Update ()
    {
        if (IsHighlighted(bED))
        {
            selected = true;
        }
        if (selected)
        {
            i.material = selectedMat;
            selected = false;
        }
        else
        {
            i.material = normalMat;
        }
	}

}
