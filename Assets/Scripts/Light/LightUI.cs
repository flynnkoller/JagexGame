using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightUI : MonoBehaviour {

    LightFinder lightFinder;
    public Slider slider;

	// Use this for initialization
	void Start ()
    {
        lightFinder = GetComponent<LightFinder>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SliderEffect();
	}

    void SliderEffect()
    {
        if(lightFinder.CurrentLight == null)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = lightFinder.CurrentLight.intensity;
        }
    }

    //Also have an effect for screen visual feedback -- blacken around edges
}
