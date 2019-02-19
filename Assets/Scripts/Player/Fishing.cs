using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fishing : MonoBehaviour {

    public GameObject prompt;

	// Use this for initialization
	void Start () {
        prompt.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pond")
        {

            Destroy(this);
            prompt.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pond")
        {

            Destroy(this);
            prompt.SetActive(true);
        }
    }
}
