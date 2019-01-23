using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button menu;
    public Button game;
    public Button options;
    public Button exit;
    public GameObject pauseMenu;
    public GameObject soundMenu;

	// Use this for initialization
	void Start () {
        if(menu != null)
        {
            menu.onClick.AddListener(delegate { SceneManager.LoadScene(0); });
        }
        
        if(game != null)
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                game.onClick.AddListener(Continue);
            }
            else
            {
                game.onClick.AddListener(delegate { SceneManager.LoadScene(1); });
            }
        }
        
        if(options != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                options.onClick.AddListener(SoundOptions);
            }
            else
            {
                options.onClick.AddListener(delegate { SceneManager.LoadScene(2); });
            }
        }
        
        if(exit != null)
        {
            exit.onClick.AddListener(delegate { Application.Quit(); });
        }
    }

    void Continue()
    {
        Time.timeScale = 1;
        soundMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void SoundOptions()
    {
        soundMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ExternalCall(int i)
    {
        if(i == 0)
        {
            SceneManager.LoadScene(0);
        }
        if(i == 1)
        {
            SceneManager.LoadScene(1);
        }
        if(i == 2)
        {
            SceneManager.LoadScene(2);
        }
        if(i == 3)
        {
            Application.Quit();
        }
    }
}
