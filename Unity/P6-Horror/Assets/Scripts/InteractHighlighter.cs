using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHighlighter : MonoBehaviour {

    public float glowDistance;
    public float glowAngle;
    public List<GameObject> interactables = new List<GameObject>();
    private Vector3 objectDirection;
    private float objectDistance;
    private float objectAngle;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SphereCollider>().radius = glowDistance;
	}
	
	// Update is called once per frame
	void Update () {
        Vision();
	}

    private void Vision()
    {
        foreach(GameObject g in interactables)
        {
            objectDirection = g.transform.position - transform.position;
            objectDistance = Mathf.Sqrt(Mathf.Pow((g.transform.position.z - transform.position.z), 2) + Mathf.Pow((g.transform.position.x - transform.position.x), 2));
            objectAngle = Vector3.Angle(objectDirection, GetComponentInParent<Transform>().forward);
            //print(objectAngle.ToString());
            if(objectDistance <= glowDistance && objectAngle <= glowAngle)
            {
                print("see");
                g.GetComponent<Interactable>().seen = true;
            }
            else
            {
                g.GetComponent<Interactable>().seen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
            interactables.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            interactables.Remove(other.gameObject);
        }
    }

    public void RemoveFromList(GameObject g)
    {
        interactables.Remove(g);
    }
}
