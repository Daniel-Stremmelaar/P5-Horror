using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("DeathScreen")]
    public GameObject fadeToBlack;
    public float FadeToBlackAmount;
    public GameObject deathScreenOBJ;

    [Header("PauseMeneu")]
    public GameObject pauseMenu;


	// Use this for initialization
	void Start ()
    {
        deathScreenOBJ.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
	}

    public void DeathUI()
    {
        //fadeToBlack.GetComponent<Image>().color.a += FadeToBlackAmount * Time.deltaTime;
        if (FadeToBlackAmount == 225f)
        {
            deathScreenOBJ.SetActive(true);
        }
    }
}
