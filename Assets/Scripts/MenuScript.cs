using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Slider mySlider;
    public int lvlNum;

    public void StartGame()
    {
        lvlNum = 6;
        SceneManager.LoadScene("LoadingScreen");
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

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsScreen()
    {
        SceneManager.LoadScene("Settings");
    }

    public void FullScreen()
    {
        Screen.fullScreen = Screen.fullScreen;
    }

    public void Windowed()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void OnValueChanged()
    {
        
        AudioListener.volume = mySlider.value;
    }
}
