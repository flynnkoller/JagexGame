using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    //Get the current position + power it need from the players input
    //Fire forwards with the angle of the player to centre of camera ray cast hit
    //use gravity untill it hits a object where it will stick
    //Be able to pick up arrows

    public PlayerCombat playerCombat;

    private float _angle;
    private float _power;
    private bool _stuck;

    private Rigidbody _rb;

    // Use this for initialization
    void Start()
    {
        //Get the player controller to use the needed variables
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

        //Assign the arrows starting power to the power of how long the button was held
        _power = playerCombat.FirePower;

        //Get it's own rigid body
        _rb = GetComponent<Rigidbody>();

        Move();
    }

    void Move()
    {
        //Move using the angle and power from the player
        _rb.AddForce(playerCombat.FireAngle.normalized * (_power / 5), ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision col)
    {
        _stuck = true;

        //Stop the velocity of the rigid body
        _rb.velocity = new Vector3(0, 0, 0);

        //Destroy the rigid body when it hits a wall
        Destroy(_rb);
    }
}
