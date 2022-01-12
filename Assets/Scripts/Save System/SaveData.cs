using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    /// <summary>Money</summary>
    public float Money;

    /// <summary>Creates a brand new, empty save file.</summary>
    public SaveData()
    {
        Money = 0;
    }

    /// <summary>Creates a save file from the given save information</summary>
    /// <param name="money">Money Value</param>
    public SaveData(float money)
    {
        Money = money;
    }
}
