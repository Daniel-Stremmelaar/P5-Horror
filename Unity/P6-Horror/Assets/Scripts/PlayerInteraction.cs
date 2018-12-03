using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    private RaycastHit hit;
    public int interactDistance;
    public GameObject interactDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * interactDistance);
		if(Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            if(hit.transform.gameObject.tag == "Interactable")
            {
                interactDisplay.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    hit.transform.gameObject.GetComponent<Interactable>().Interact();
                }
            }
            else
            {
                interactDisplay.SetActive(false);
            }
        }
        else
        {
            interactDisplay.SetActive(false);
        }
	}
}
