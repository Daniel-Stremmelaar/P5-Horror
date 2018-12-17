using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public Light light;
    public float flickerMin;
    public float flickerMax;
    public bool burning;
    public float wax;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            burning = !burning;
        }

        if(wax > 0 && burning == true)
        {
            Flicker();
            wax -= Time.deltaTime;
        }
        else
        {
            light.intensity = 0;
        }

        if(wax <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    void Flicker()
    {
        light.intensity = Random.Range(flickerMin, flickerMax);
    }
}
