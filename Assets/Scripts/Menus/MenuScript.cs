using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    Slider mySlider;
    public int lvlNum;

    LoadingScreen Load = new LoadingScreen();

    public void StartGame()
    {
        Load.levelSelect = 2;
        Initiate.Fade("Hub", Color.white, 1.0f);
        StartCoroutine(FadeWait());
    }

    public void ControlsScreen()
    {
        Initiate.Fade("Controls", Color.black, 5.0f);
        StartCoroutine(FadeWait());
    }

    public void CreditsScreen()
    {
        Initiate.Fade("Credits", Color.black, 5.0f);
        StartCoroutine(FadeWait());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Initiate.Fade("MainMenu", Color.black, 5.0f);
        StartCoroutine(FadeWait());
    }

    public void SettingsScreen()
    {
        Initiate.Fade("Settings", Color.black, 5.0f);
        StartCoroutine(FadeWait());
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

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(3);
    }
}
