using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    private Vector3 closed;
    private Vector3 open;
    public float moveDistance;
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
        open.z += moveDistance;
        opened = false;
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            if(opened == false)
            {
                transform.Translate(transform.forward * Time.deltaTime * speed);
                if(transform.position.z >= open.z)
                {
                    opened = true;
                    moving = false;
                }
            }
            else
            {
                transform.Translate(-transform.forward * Time.deltaTime * speed);
                if (transform.position.z <= closed.z)
                {
                    opened = false;
                    moving = false;
                }
            }
        }
    }
}
