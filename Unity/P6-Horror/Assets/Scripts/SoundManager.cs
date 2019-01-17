using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Header ("Background Music")]
    public AudioClip bgMusic;
    public AudioSource bgmSource;

    [Header ("Set PickUp Sound")]
    public AudioClip clip;

    void Start () {
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            if(g.GetComponent<PickUp>() != null)
            {
                g.GetComponent<PickUp>().clip = clip;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
