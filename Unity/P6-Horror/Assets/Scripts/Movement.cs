using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float depth;
    public float depthSpeed;
    private float horizontal;
    public float horizontalSpeed;
    public float moveSpeedMultiplier;
    public float rotationSpeed;
    private Vector3 translation;
    private Vector3 rotation;
    public bool airborne;

    //public float jumpV;
    //private Rigidbody r;

	// Use this for initialization
	void Start () {
        //r = gameObject.GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            horizontalSpeed *= moveSpeedMultiplier;
            depthSpeed *= moveSpeedMultiplier;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            horizontalSpeed /= moveSpeedMultiplier;
            depthSpeed /= moveSpeedMultiplier;
        }
    }

    // Update is called thirty times per second
    void FixedUpdate () {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || airborne == true)
        {
            Move();
        }
        /*if (airborne == false && Input.GetButtonDown("Jump"))
        {
            Jump();
        }*/
        if(Input.GetAxis("Mouse X") != 0)
        {
            Turn();
        }
	}

    private void Move()
    {
        if(airborne == false)
        {
            depth = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            translation.z = depth * Time.deltaTime * depthSpeed;
            translation.x = horizontal * Time.deltaTime * horizontalSpeed;
        }
        transform.Translate(translation);
    }

    private void Turn()
    {
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation.y, 0.0f);
    }

    /*
    private void Jump()
    {
        translation.y = jumpV;
        airborne = true;
        r.velocity = translation;
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            airborne = false;
            translation.y = 0;
        }
    }
}
