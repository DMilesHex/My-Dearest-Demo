using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour, ISaveable
{
    public delegate void MoneySpent();
    /// <summary> When the amount of money is updated  </summary>
    public static event MoneySpent MoneyEvent;

    [SerializeField] private float money;
    [SerializeField] private Text moneyText;

    private void Awake()
    {
        moneyText.text = $"${money}";
    }


    public object CaptureState()
    {
        return new SaveData
        {
            money = money
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        money = saveData.money;
    }

    [Serializable]
    private struct SaveData
    {
        public float money;
    }
}


