﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp {

    [Header("Key info")]
    private DoorManager doorManager;
    public int number;
    public int doubleNumber;
    public string roomName;

	// Use this for initialization
	void Start () {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
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

        print("Gained key to " + roomName);

        base.Interact();
    }
}
