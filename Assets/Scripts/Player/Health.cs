using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private int _maxHealth;
    private int _currentHealth;
    private float _damageMod;
    private float _healMod;

    //This wants to be called in a player manager so that the max and current health can be saved aswell as keep variables private
    public Health(int MaxHealth, int CurrentHealth)
    {
        _maxHealth = MaxHealth;
        _currentHealth = CurrentHealth;
    }

    //If there was a problem with the save or just no input start with a default of 100, 100
    public Health()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }

    //Allow current health to be accesed and changed without effecting the variable
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    //Allow the max health to be accesed but not changed post constructor
    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    //Maybe do this step on the ai base and player spereately to allow for more freedom


    //Change values to be more modular
    public void Heal()
    {
        //If the player has lost health allow this to run -- Maybe change to a bool check???
        if(CurrentHealth < MaxHealth)
        {
            //if the player has only lost up to 10 health current health is = to max to stop over healing
            if(MaxHealth - CurrentHealth <= 10)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += 10;
            }
        }
    }

    public void Damage()
    {
        CurrentHealth -= 10;
    }
}
