using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public MeshRenderer[] meshRenderers;
    public float transitionValue;
    public float targetValue;
    public bool oldTimes;

    public float transitionSpeed = 1;

    public RoomManager roomManager;

    public void Switcheroo()
    {
        if (oldTimes)
        {
            BecomeOld();
        }
        else
        {
            BecomeNew();
        }
    }

    public void Update()
    {
        if(transitionValue == targetValue)
        {
            return;
        }
        else
        {
            if (transitionValue > targetValue)
            {
                transitionValue -= transitionSpeed*Time.deltaTime;
            }
            else
            {
                if (transitionValue < targetValue)
                {
                    transitionValue += transitionSpeed * Time.deltaTime;
                }
            }
        }

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.SetFloat("_Progress", transitionValue);
        }
    }

    public void BecomeOld()
    {
        oldTimes = true;
        targetValue = 2;
    }

    public void BecomeNew()
    {
        oldTimes = false;
        targetValue = 0;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Switcheroo();
            roomManager.RemoveFromList();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
