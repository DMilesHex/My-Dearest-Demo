using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon")]
public class Weapon : ItemList
{   
    public enum WeaponType
    {
        Knife,
        Axe,
        Blunt//...
    }
    public WeaponType weaponType;
    public bool equipped;

    public GameObject weaponprefab;
}
