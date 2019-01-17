using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [Header ("Interact Highlight")]
    private float timer;
    public float activateTime;
    public bool seen;

    [Header ("Audio")]
    public AudioClip clip;
    public AudioSource source;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    public virtual void Interact()
    {
        print("interact");
        source.PlayOneShot(clip);
    }

    private void Update()
    {
        if(timer > 0 && seen == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                print("shader off");
                //shader off
                timer = 0;
            }
        }

        if(seen == true)
        {
            Highlight();
        }
    }

    public void Highlight()
    {
        timer += Time.deltaTime;
        if(timer >= activateTime)
        {
            timer = activateTime;
            print("shader on");
            //shader on
        }
    }
}
