using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    //Functions and variables all enemies will follow
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected int _damage;
    [SerializeField]
    protected int _range;
    [SerializeField]
    protected float _speedMod;
    [SerializeField]
    protected float _critMod;
    [SerializeField]
    protected bool _canBeDamaged;
    [SerializeField]
    protected GameObject _player;

    //Unless decided otherwise all AI should know what the player is
    protected void Start()
    {
        _canBeDamaged = true;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void TakeDamage()
    {
        if(_canBeDamaged == true)
        {
            //take the player damage away from health
            //check if dead here
        }
    }

    void Attack()
    {
        //if the enemy is in range of the player run the attack anim aswell as other enemy specific variables as set down the chain
    }
}
