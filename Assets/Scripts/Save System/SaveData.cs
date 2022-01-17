using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    /// <summary>The number of money player has available</summary>
    public float Money;

    /// <summary>Creates a brand new, empty save file.</summary>
    public SaveData()
    {
        Money = 0;
    }

    /// <summary>Creates a save file from the given save information</summary>
    /// <param name="savedMoney">The amount of money which was saved.</param>
    public SaveData(float savedMoney)
    {
        Money = savedMoney;
    }
}
