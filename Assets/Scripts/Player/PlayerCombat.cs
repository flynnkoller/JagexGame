using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCombat : TestEnemyAI {

    private Health _health;
    public Text playerHealth;

    TestEnemyAI enemy = new TestEnemyAI();
    EnemyBase enemyBase = new EnemyBase();

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
        _health.CurrentHealth = 150;
        playerHealth.text = _health.CurrentHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {

        playerHealth.text = _health.CurrentHealth.ToString();
        if (_health.CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
