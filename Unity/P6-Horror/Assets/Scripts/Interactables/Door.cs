﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Vector3 closed;
    private Vector3 open;
    public float var;
    public float speed;
    public int direction;
    public bool unlocked;
    private bool moving;
    private bool opened;
    public AudioClip openDoor;
    public AudioClip closeDoor;

    public override void Interact()
    {
        if(unlocked == true)
        {
            base.Interact();
            moving = true;
            clip = openDoor;
            Debug.Log(clip);
        }
        else
        {
            clip = closeDoor;
            source.PlayOneShot(clip);
            clip = null;
            Debug.Log(clip);
        }
    }

    private void Start()
    {
        unlocked = false;
        closed = transform.rotation.eulerAngles;
        if (closed.y == 0)
        {
            closed.y = 1;
        }
        open = transform.rotation.eulerAngles;
        open.y += 90 * direction;
        if(open.y < 0)
        {
            open.y = 360 + open.y;
        }
        opened = false;
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            if (opened == false)
            {
                transform.Rotate(0, 1 * direction * Time.deltaTime * speed,0);
                print(transform.rotation.eulerAngles.y);
                if (transform.rotation.eulerAngles.y >= open.y && transform.rotation.eulerAngles.y <= open.y + var)
                {
                    opened = true;
                    moving = false;
                }
            }
            else
            {
                transform.Rotate(0, -1 * direction * Time.deltaTime * speed, 0);
                print(transform.rotation.eulerAngles.y);
                if (transform.rotation.eulerAngles.y <= closed.y && transform.rotation.eulerAngles.y >= closed.y - var)
                {
                    opened = false;
                    moving = false;
                }
            }
        }
    }
}
