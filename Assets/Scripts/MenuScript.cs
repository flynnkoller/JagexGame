using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public void ControlsScreen()
    {
        SceneManager.LoadScene("Controls");
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
