using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    private Health _health;

    private float _firePower;
    private Vector3 _fireAngle;

    public GameObject arrow;
    public GameObject firePoint;

    public NewCamera camController;
    public Camera cam;


    public Health PlayerHealth
    {
        get { return _health; }
        set { _health = value; }
    }

	// Use this for initialization
	void Start ()
    {
        //Give the player a default health
        _health = new Health();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Archery();
	}

    void Archery()
    {
        GetFireAngle();
        FireArrow();
    }

    void FireArrow()
    {
        //Then the button is first pressed reset the power
        if (Input.GetMouseButtonDown(0))
        {
            FirePower = 0;
        }
        //If the mouse is held down up the fire power 
        if (Input.GetMouseButton(0))
        {
            FirePower += 2;
        }
        //When released instanciate the arrow
        if (Input.GetButtonUp("Fire1"))
        {
            Instantiate(arrow, firePoint.transform.position, transform.rotation * Quaternion.Euler(FireAngle.x, FireAngle.y, FireAngle.z));

            Debug.Log("firePower " + FirePower);
        }
    }

    void GetFireAngle()
    {
        FireAngle = camController.Dir;
    }

    void RotatePlayer()
    {
        //Rotates the player based on the camera
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
    }

    #region CONSTRUCTORS

    public float FirePower
    {
        //Let the fire power be accessed externally
        get
        {
            return _firePower;
        }
        //Only allow the power to be set internally
        private set
        {
            if (_firePower <= 100)
            {
                _firePower = value;
            }
            else
            {
                _firePower = 100;
            }

        }
    }

    public Vector3 FireAngle
    {
        get
        {
            return _fireAngle;
        }
        private set
        {
            _fireAngle = value;
        }
    }

    #endregion
}
