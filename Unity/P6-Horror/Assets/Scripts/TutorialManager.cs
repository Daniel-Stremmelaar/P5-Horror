using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject moveSetPopUp;
    public GameObject openLogBook;
    public float waitTime;

    private void Start()
    {
        moveSetPopUp.SetActive(false);
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
            if (Input .GetButtonDown("Horizontal")&&Input.GetButtonDown("Vertical"))
            {
                Debug.Log("PLISBAAS0102");
                moveSetPopUp.SetActive(false);
                openLogBook.SetActive(true);
                //mis play animtion
            }
        }
    }
}
