using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

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

    protected PlayerCombat _playerCombat;

    protected Health health;

    //Unless decided otherwise all AI should know what the player is
    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerCombat = _player.GetComponent<PlayerCombat>();
        //Will set a health of 100 100 and come with functions to be healed and damaged
        //Unless otherwise stated -- allow certain enemies to be spawned with these inputs complete
        health = new Health(100, 100);
    }
    protected void Update()
    {
        //TEST when q is pressed damage the enemy and check if it's alive
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.Damage();
            health.DeathCheck(health.CurrentHealth);
            if(health.IsDead == true)
            {
                Destroy(gameObject);
            }
        }

        Debug.Log(health.CurrentHealth);
    }

    void Attack()
    {
        //if the enemy is in range of the player run the attack anim aswell as other enemy specific variables as set down the chain
    }
}
