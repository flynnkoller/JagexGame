using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
    

    bool isLoaded;
    public Text waitText;
    public Text mainText;
    int tipPicker;
    public int levelSelect;
    
    public Slider slider;

    AsyncOperation async;

    // Use this for initialization
    void Start () {
        StartCoroutine(Loading(levelSelect));
        isLoaded = false;
        StartCoroutine(TextChange());
        
        tipPicker = Random.Range(1, 5);
        if (tipPicker == 1)
        {
            mainText.text = "Tip 1";
        }
        if (tipPicker == 2)
        {
            mainText.text = "Tip 2";
        }
        if (tipPicker == 3)
        {
            mainText.text = "Tip 3";
        }
        if (tipPicker == 4)
        {
            mainText.text = "Tip 4";
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TextChange() //waiting text w/ moving ellipses
    {
        do
        {
            waitText.text = "Loading";
            yield return new WaitForSeconds(1);
            waitText.text = "Loading.";
            yield return new WaitForSeconds(1);
            waitText.text = "Loading..";
            yield return new WaitForSeconds(1);
            waitText.text = "Loading...";
            yield return new WaitForSeconds(1);

        } while (isLoaded == false);

    }

    public void LoadScreenExample()
    {
        StartCoroutine(Loading(levelSelect));
    }

    IEnumerator Loading(int lvl)
    {
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
                isLoaded = true;
            }
            yield return null;
        }
    }

}
