using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject uiManager;
    public GameObject moveSetPopUp;
    public GameObject openLogBookText;
    public GameObject openLogBook;
    public float waitTime;
    bool b = false;

    private void Start()
    {
        moveSetPopUp.SetActive(false);
        openLogBookText.SetActive(false);
        openLogBook.SetActive(false);
        StartCoroutine(waitTimerTut());
    }

    private void Update()
    {
        TutorialUI();
    }

    IEnumerator waitTimerTut()
    {
        yield return new WaitForSeconds(waitTime);
        moveSetPopUp.SetActive(true);
    }

    public void TutorialUI()
    {
        if (moveSetPopUp == true)
        {
            if (Input .GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {
                moveSetPopUp.SetActive(false);
                openLogBookText.SetActive(true);
                //mis play animtion
                b = true;
            }
        }
        if (b == true && Input.GetButtonDown("OpenLogBook"))
        {
            Debug.Log("Hello");
            openLogBook.SetActive(true);
            openLogBookText.SetActive(false);
        }
    }
}
