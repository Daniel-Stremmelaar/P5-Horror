using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleGet : PickUp {

    public GameObject candle;
    public float wax;

    public override void Interact()
    {
        if(candle.active == false)
        {
            candle.SetActive(true);
        }
        candle.GetComponent<Candle>().wax += wax;
        base.Interact();
    }
}
