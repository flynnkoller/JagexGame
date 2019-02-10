using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Button resume;
    public Button menu;
    public Button quit;
    public bool pauseMenuOpen;

    private void Start()
    {
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuOpen == false)
            {
                pauseMenuOpen = true;
                resume.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenuOpen = false;
                resume.gameObject.SetActive(false);
                menu.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
            }
        }

    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pauseMenuOpen = false;
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
