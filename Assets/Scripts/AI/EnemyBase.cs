using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    //Functions and variables all enemies will follow
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected int _maxHealth;
    [SerializeField]
    protected int _damage;
    [SerializeField]
    protected int _range;
    [SerializeField]
    protected float _speedMod;
    [SerializeField]
    protected float _critMod;
    [SerializeField]
    protected GameObject _player;

    Health health;

    //Unless decided otherwise all AI should know what the player is
    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //Will set a health of 100 100 and come with functions to be healed and damaged
        //Unless otherwise stated -- allow certain enemies to be spawned with these inputs complete
        health = new Health();
        _health = health.CurrentHealth;
        _maxHealth = health.MaxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        _health -= 10;
    }

    void Attack()
    {
        //if the enemy is in range of the player run the attack anim aswell as other enemy specific variables as set down the chain
    }
}
