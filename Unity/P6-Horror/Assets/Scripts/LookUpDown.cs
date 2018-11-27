using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpDown : MonoBehaviour {
    private Vector3 r;
    public float rotSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotation look
        r.x += -Input.GetAxis("Mouse Y") * rotSpeed;
        r.x = Mathf.Clamp(r.x, -50.0f, 50.0f);
        transform.eulerAngles = (new Vector3(r.x, transform.eulerAngles.y, 0.0f));
    }
}
