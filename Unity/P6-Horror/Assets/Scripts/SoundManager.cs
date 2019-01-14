using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Header ("Background Music")]
    public AudioClip bgMusic;
    public AudioSource bgmSource;

    [Header ("Set Interactables")]
    public AudioClip clip;
    public AudioSource source;

    // Use this for initialization
    private void Awake()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            if (g.GetComponent<Interactable>() != null)
            {
                g.GetComponent<Interactable>().source = g.GetComponent<AudioSource>();
            }
        }
    }

    void Start () {
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            if(g.GetComponent<PickUp>() != null)
            {
                g.GetComponent<PickUp>().source = source;
                g.GetComponent<PickUp>().clip = clip;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
