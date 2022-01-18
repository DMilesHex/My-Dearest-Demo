using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private player player;
    [SerializeField] private List<Weapon> inventoryList = new List<Weapon>();
    [SerializeField] private List<GameObject> weaponSprites;
    [SerializeField] private NonDialogueInteractions student;
    [SerializeField] private List<Pickup> pickup;

    public List<Weapon> InventoryList { get => inventoryList; set => inventoryList = value; }

    public void Remove(int index)
    {
       RemoveItem(InventoryList[index], index);
       pickup[index].DisableButton();
    }

    public void OnClickButton(Weapon equippedWeapon)
    {
        Debug.Log("Just do something please");
        foreach (Weapon weapon in InventoryList)
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
            if (player.Sanity <= player.SanityMax - 10)
                player.Sanity += 10;
            equippedWeapon.equipped = false;
            Debug.Log(player.Sanity);
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
        InventoryList.Add(weapontoadd);
    }

    public void RemoveItem(Weapon itemToRemove, int itemIndex)
    {
        Debug.Log("stuff");
        if (GameObject.Find(itemToRemove.weaponprefab.name))
        {
            Debug.Log("deleted");
            InventoryList.Remove(itemToRemove);
        }
        weaponSprites[itemIndex].SetActive(false);
    }
}
