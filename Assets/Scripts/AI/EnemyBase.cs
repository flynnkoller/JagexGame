using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    //Functions and variables all enemies will follow - but not type specific ones <- they are done a layer down
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
    protected bool _canAttack = true;
    [SerializeField]
    protected float _cooldown;
    [SerializeField]
    protected int _lightMod;

    protected LightFinder _lightFinder;
    protected GameObject _player;
    protected PlayerCombat _playerHealth;

    protected Health health;

    //Unless decided otherwise all AI should know what the player is
    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<PlayerCombat>();

        //Get the light finder script
        _lightFinder = gameObject.GetComponent<LightFinder>();

        //Will set a health of 100 100 and come with functions to be healed and damaged
        //Unless otherwise stated -- allow certain enemies to be spawned with these inputs complete
        //Have it so damage functions can be stored in the health class, so we can simply pass in the private max + current health here
        health = new Health(_maxHealth, _health);
        _health = health.CurrentHealth;
        _maxHealth = health.MaxHealth;
    }

    protected void TakeDamage()
    {
        //Take damage
        health.Damage();
        //Check if the ai is still alive
        health.DeathCheck();

        if(health.IsDead == true)
        {
            Destroy(gameObject);
        }
    }

    protected void Attack(int damage)
    {
        //if the enemy can attack then do
        if(_canAttack == true)
        {
            //Using the targeted damage overload target the players health and damage it
            health.Damage(_playerHealth.PlayerHealth, damage);

            //Start the cool down
            _canAttack = false;
            StartCoroutine(AttackCD(_cooldown));
        }
    }

    protected void LightMod()
    {
        //If there is a light set the light mod to the intensity
        if(_lightFinder.CurrentLight != null)
        {
            _lightMod = Mathf.FloorToInt(_lightFinder.CurrentLight.intensity);
        }
        else
        {
            _lightMod = 0;
        }
    }

    IEnumerator AttackCD(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _canAttack = true;
    }

    protected void Look()
    {
        transform.LookAt(_player.transform);
    }
}
