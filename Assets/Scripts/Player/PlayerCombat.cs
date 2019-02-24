using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    private Health _health;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
