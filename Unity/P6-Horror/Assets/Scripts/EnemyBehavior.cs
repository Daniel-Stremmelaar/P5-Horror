using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private enum action { wander, scan, hunt, search };
    private action current;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (current)
        {
            case action.wander:
                //behavior here
                break;

            case action.scan:
                //behavior here
                break;

            case action.hunt:
                //behavior here
                break;

            case action.search:
                //behavior here
                break;
        }
	}
}
