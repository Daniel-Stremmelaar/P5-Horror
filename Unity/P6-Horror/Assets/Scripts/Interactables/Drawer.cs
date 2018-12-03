using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable {

    public Vector3 closed;
    public Vector3 open;
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
        closed = transform.position;
        open = transform.position;
        open.z += 1;
        opened = false;
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            if(opened == false)
            {
                transform.Translate(transform.forward * Time.deltaTime * speed);
                if(transform.position == open)
                {
                    opened = true;
                    moving = false;
                }
            }
            else
            {
                transform.Translate(-transform.forward * Time.deltaTime * speed);
                if (transform.position == closed)
                {
                    opened = false;
                    moving = false;
                }
            }
        }
    }
}
