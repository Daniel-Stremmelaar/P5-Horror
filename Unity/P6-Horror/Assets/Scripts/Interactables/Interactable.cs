using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private float timer;
    public float activateTime;
    public bool seen;

	public virtual void Interact()
    {
        print("interact");
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
