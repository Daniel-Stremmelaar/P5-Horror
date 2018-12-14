using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private RaycastHit hit;
    public float interactDistance;
    public GameObject interactDisplay;
    public float stalkTimer;
    public bool stalked;
    private float timeStalked;
    private int jumpScare;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(stalked == true)
        {
            Stalked();
        }
        else
        {
            Lost();
        }
        Debug.DrawRay(transform.position, transform.forward * interactDistance);
		if(Physics.Raycast(transform.position, transform.forward, out hit, interactDistance) && Time.timeScale != 0)
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

    public void Lost()
    {
        if(timeStalked > 0)
        {
            timeStalked -= Time.deltaTime;
        }
        if (timeStalked < 0)
        {
            timeStalked = 0;
        }
    }

    public void Stalked()
    {
        timeStalked += Time.deltaTime;
        if(timeStalked >= stalkTimer)
        {
            jumpScare = Random.Range(0, 2);
            Time.timeScale = 0;
            print("game over " + jumpScare.ToString());
        }
    }
}
