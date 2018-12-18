using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    public List<Door> Doors = new List<Door>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Unlock(int i)
    {
        Doors[i].unlocked = true;
    }
}
