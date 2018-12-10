using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("DeathScreen")]
    public GameObject fadeToBlackOBJ;
    public Color fateToBlackColor;
    public float FadeToBlackAmount;
    public GameObject deathScreenOBJ;
    bool deathBool;
    public Animator deathPopUp;

    [Header("PauseMeneu")]
    public GameObject pauseMenu;


    // Use this for initialization
    void Start()
    {
        deathScreenOBJ.SetActive(false);
        fateToBlackColor.a = 0f;
        DeathUI();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        
        if (deathBool == true)
        {
            FateToBlack();
        }
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
}
