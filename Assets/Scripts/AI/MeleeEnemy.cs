using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase{

	//This layer adds functionality all melee ai will have

	void Start ()
    {
        base.Start();

        //Should do these on the specific enemy level
        //TEST
        _damage = 2;
        _speedMod = 1;
        _critMod = 1;
        _range = 1;
	}

    void Update()
    {
        base.Update();

        Move();
        Attack();
        Look();
    }

    void Move()
    {
        //Movement logic for meele ai 
        //How are we path finding???
    }

    void Attack()
    {
        //Logic to attack
    }

    void Look()
    {
        transform.LookAt(_player.transform);
    }

    //TEST if the player collides with the AI deal hella damage
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.Damage(_playerCombat.PlayerHealth, _damage);
        }
    }
}
