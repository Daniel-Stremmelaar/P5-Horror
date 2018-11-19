using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {

    public Material current;
    public Material past;
    public Material present;

	// Use this for initialization
	void Start () {
        current = gameObject.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            ChangeMaterial();
        }
    }

    public void ChangeMaterial()
    {
        //check current material
        if (current == past)
        {
            //change material to modern day
            current = present;
        }
        else
        {
            //change material to old house
            current = past;
        }
        //set material to object
        gameObject.GetComponent<Renderer>().material = current;
    }
}
