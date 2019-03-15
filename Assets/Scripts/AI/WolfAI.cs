using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfAI : MeleeEnemy {

    public Text healthText;
    private bool _canMove = true;

	// Use this for initialization
	new void Start ()
    {
        base.Start();

        //Set the stats for a wolf
        _maxHealth = 150;
        _health = _maxHealth;
        _damage = (20 - (_lightMod * 2));
        _speedMod = 1.5f;
        _critMod = 1;
        _range = 1;
        _cooldown = 0.75f;

        healthText.text = health.CurrentHealth.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = health.CurrentHealth.ToString();
        LightMod();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage();
            Debug.Log(health.CurrentHealth);
        }

        Look();

        if(_canMove == true)
        Move();

        Debug.Log(health.IsDead);
    }


    //Probably don't want so many collision checks at this level
    private void OnCollisionStay(Collision collision)
    {
        Attack(_damage- (_lightMod *2));
        Debug.Log(_playerHealth.PlayerHealth.CurrentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _canMove = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _canMove = true;
    }
}
