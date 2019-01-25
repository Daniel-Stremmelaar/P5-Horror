using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : PickUp {

    public int number;
    public NotebookManager notebooks;

    public override void Interact()
    {
        notebooks.found[number] = true;
        base.Interact();
    }
}
