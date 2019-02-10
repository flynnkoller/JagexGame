using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLights : MonoBehaviour {

    [SerializeField]
    List<Light> _lights = new List<Light>();

    void Start()
    {
        //Find all lights in the scene, only run once as is an expensive function
        foreach (Light l in FindObjectsOfType(typeof(Light)))
        {
            _lights.Add(l);
        }
    }

    //Allow the list to be acceced but read only
    public List<Light> Lights
    {
        get { return _lights; }
    }
}
