using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<Weapon> inventoryList = new List<Weapon>();
    public List<GameObject> weaponSprites;
    public player pl;
    public NonDialogueInteractions student;
    public List<Pickup> pickup;
    
    
    public void Remove(int index)
    {
            RemoveItem(inventoryList[index], index);
            pickup[index].DisableButton();
    }

    public void OnClickButton(Weapon equippedWeapon)
    {
        Debug.Log("Just do something please");
        foreach (Weapon weapon in inventoryList)
        {
            weapon.equipped = false;
        }
        equippedWeapon.equipped = true;

        if (equippedWeapon.name == "Wood Hatchet")
        {
            Debug.Log("Axe in hand");
            weaponSprites[1].SetActive(true);
        }
        else if (equippedWeapon.name == "Fidget Cube")
        {
            if (pl.Sanity <= pl.SanityMax - 10)
                pl.Sanity += 10;
            equippedWeapon.equipped = false;
            Debug.Log(pl.Sanity);
        }
        else if (equippedWeapon.name == "Hunting Knife")
        {
            Debug.Log("Knife in hand");
            weaponSprites[0].SetActive(true);
        }
        else if (equippedWeapon.name == "Humming Bird Charm")
        {
            Debug.Log("charm in hand");
            weaponSprites[2].SetActive(true);
        }


    }

    

    

    public void AddWeapon(Weapon weapontoadd)
    {
        inventoryList.Add(weapontoadd);

    }

    public void RemoveItem(Weapon itemToRemove, int itemIndex)
    {
        Debug.Log("stuff");
        if (GameObject.Find(itemToRemove.weaponprefab.name))
        {
            Debug.Log("deleted");
            inventoryList.Remove(itemToRemove);
        }
        weaponSprites[itemIndex].SetActive(false);
    }
}
