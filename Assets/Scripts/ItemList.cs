using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Gift,
    Default,
    Weapon
}
public abstract class ItemList : ScriptableObject
{

    
    public ItemType type;
    public string name;
}
