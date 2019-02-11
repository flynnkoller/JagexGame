using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    private int _damageMod;

    Health health;

    // Use this for initialization
    void Start()
    {
        //Give our player health of 100 100 unless otherwise stated
        health = new Health();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            health.Damage();
        }

        DeathCheck();
    }

    //Allow ai to access the players current health to damage it
    public Health PlayerHealth
    {
        get { return health; }
        set { health = value; }
    }

    void Attack()
    {

    }

    void DeathCheck()
    {
        health.DeathCheck(health.CurrentHealth);
        if (health.IsDead == true)
        {
            Debug.Log("PLAYER IS DEAD");
        }
    }
}
