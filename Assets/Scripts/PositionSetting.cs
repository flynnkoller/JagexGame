using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSetting : MonoBehaviour {

    void Awake()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
    }
}
