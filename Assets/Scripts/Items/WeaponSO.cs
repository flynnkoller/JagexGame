using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item", order = 1)]
public class WeaponSO : ScriptableObject
{
    //Use this to make item stats untill we set up a database

    string itemName;
    int damage;
    int durability;
    bool ranged;
    int ammoCap;
}
