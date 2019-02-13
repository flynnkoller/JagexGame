using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase{

	//This layer adds functionality all melee ai will have

    protected void Move()
    {
        //Movement logic for meele ai 
        //How are we path finding???

        //Temporary untill we have a path finding system
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, 0.1f);
    }

    void MeleeAttack()
    {
        //Logic to attack
    }
}
