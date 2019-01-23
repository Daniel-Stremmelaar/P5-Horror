using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {

    public GameObject g;

    private void Start()
    {
        //g = GameObject.FindGameObjectWithTag("MainCamera");
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        g.GetComponent<InteractHighlighter>().RemoveFromList(this.gameObject);
        Destroy(gameObject);
    }
}
