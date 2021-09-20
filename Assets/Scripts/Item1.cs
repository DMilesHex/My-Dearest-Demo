using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default", menuName = "Inventory System/Items/Default")]   
public class Item1 : ItemList
{
    private player player;
    public void Awake()
    {
        type = ItemType.Default;
    }

    void UseItem()
    {
        if (name.Equals("Fidget Cube"))
        {
            if (player.sanity <= player.sanityMax - 20)
                player.sanity += 20;
            else
                player.sanity = player.sanityMax;
        }
    }
}
