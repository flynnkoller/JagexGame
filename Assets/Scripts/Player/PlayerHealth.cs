using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private int _maxHealth;
    private int _currentHealth;
    private float _damageMod;
    private float _healMod;

    //This wants to be called in a player manager so that the max and current health can be saved aswell as keep variables private
    public PlayerHealth(int MaxHealth, int CurrentHealth)
    {
        _maxHealth = MaxHealth;
        _currentHealth = CurrentHealth;
    }

    //If there was a problem with the save or just no input start with a default of 100, 100
    public PlayerHealth()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
    //Change values to be more modular
    void Heal()
    {
        //If the player has lost health allow this to run -- Maybe change to a bool check???
        if(_currentHealth < _maxHealth)
        {
            //if the player has only lost up to 10 health current health is = to max to stop over healing
            if(_maxHealth - _currentHealth <= 10)
            {
                _currentHealth = _maxHealth;
            }
            else
            {
                _currentHealth += 10;
            }
        }
    }
}
