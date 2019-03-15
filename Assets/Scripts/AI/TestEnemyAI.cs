using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAI : MeleeEnemy {

    private bool _canMove = true;


	// Use this for initialization
	new void Start ()
    {
        base.Start();

        //Set the stats for Test
        _maxHealth = 150;
        _health = _maxHealth;
        _damage = (20 - (_lightMod * 2));
        _speedMod = 1.5f;
        _critMod = 1;
        _range = 1;
        _cooldown = 0.75f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        LightMod();

        

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

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TakeDamage();
                Debug.Log(health.CurrentHealth);
            }
        }
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
