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

    void Move()
    {
        //Movement logic for meele ai 
        //How are we path finding???
    }

    void Attack()
    {
        //Logic to attack
    }
}
