using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject uiManager;
    public GameObject moveSetPopUp;
    public GameObject openLogBookText;
    public float waitTime;
    bool b = false;
    bool bb = true;

    private void Start()
    {
        moveSetPopUp.SetActive(true);
        openLogBookText.SetActive(false);
    }

    private void Update()
    {
        TutorialUI();
    }

    public void TutorialUI()
    {
        if (moveSetPopUp == true)
        {
            if (bb == true && Input.GetButtonDown("Horizontal") || bb == true && Input.GetButtonDown("Vertical"))
            {
                moveSetPopUp.SetActive(false);
                openLogBookText.SetActive(true);
                //mis play animtion
                b = true;
                bb = false;
            }
        }
        if (b == true && Input.GetButtonDown("OpenLogBook"))
        {
            Debug.Log("Hello");
            openLogBookText.SetActive(false);
        }
    }
}
