using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    private Vector3 closed;
    private Vector3 open;
    public float var;
    public float speed;
    private bool moving;
    private bool opened;

    public override void Interact()
    {
        base.Interact();
        moving = true;
    }

    private void Start()
    {
        closed = transform.rotation.eulerAngles;
        if (closed.y == 0)
        {
            closed.y = 359;
        }
        open = transform.rotation.eulerAngles;
        open.y += 90;
        opened = false;
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            if (opened == false)
            {
                transform.Rotate(0,1 * Time.deltaTime * speed,0);
                print(transform.rotation.eulerAngles.y);
                if (transform.rotation.eulerAngles.y >= open.y && transform.rotation.eulerAngles.y <= transform.rotation.eulerAngles.y + var)
                {
                    opened = true;
                    moving = false;
                }
            }
            else
            {
                transform.Rotate(0, -1 * Time.deltaTime * speed, 0);
                print(transform.rotation.eulerAngles.y);
                if (transform.rotation.eulerAngles.y <= closed.y && transform.rotation.eulerAngles.y >= transform.rotation.eulerAngles.y - var)
                {
                    opened = false;
                    moving = false;
                }
            }
        }
    }
}
