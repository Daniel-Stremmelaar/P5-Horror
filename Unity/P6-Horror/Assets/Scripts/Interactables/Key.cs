using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp {

    private DoorManager doorManager;
    public int number;
    public int doubleNumber;

	// Use this for initialization
	void Start () {
        doorManager = GameObject.FindGameObjectWithTag("DoorManager").GetComponent<DoorManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        //key effect here
        doorManager.Unlock(number);
        if(doubleNumber >= 0)
        {
            doorManager.Unlock(doubleNumber);
        }

        base.Interact();
    }
}
