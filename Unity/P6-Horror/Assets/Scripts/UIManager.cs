using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("DeathScreen")]
    public GameObject fadeToBlackOBJ;
    public GameObject deathScreenOBJ;
    public float FadeToBlackAmount;
    public Color fateToBlackColor;
    public Animator deathPopUp;
    bool deathBool;
    //moet de Depyh of field aanpassen in PP //jorrit
    public GameObject mainCamera;

    [Header("PauseMeneu")]
    public GameObject pauseMenu;
    [Header("NoteBook")]
    public GameObject noteBook;


    // Use this for initialization
    void Start()
    {
        deathScreenOBJ.SetActive(false);
        fadeToBlackOBJ.SetActive(false);
        fateToBlackColor.a = 0f;
        noteBook.SetActive(false);
        //DeathUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        
        if (deathBool == true)
        {
            FateToBlack();
            fadeToBlackOBJ.SetActive(true);
        }
        OpenNoteBook();
    }

    public void DeathUI()
    {
        deathBool = true;
    }
    public void FateToBlack()
    {
        fadeToBlackOBJ.GetComponent<Image>().color = fateToBlackColor;
        fateToBlackColor.a += FadeToBlackAmount * Time.deltaTime;
        if (fateToBlackColor.a >= 1.2f)
        {
            deathScreenOBJ.SetActive(true);
            deathPopUp.Play("TextAnimation");
        }
    }

    public void OpenNoteBook()
    {
        //Debug.Log(noteBook.activeSelf);
        if (Input.GetButtonDown("OpenLogBook") && noteBook.activeSelf == false)
        {
            noteBook.SetActive(true);
        }
        else if (Input.GetButtonDown("OpenLogBook") && noteBook.activeSelf == true)
        {
            noteBook.SetActive(false);
        }
    }
}
