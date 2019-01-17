using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        
        Destroy(gameObject);
    }
}
