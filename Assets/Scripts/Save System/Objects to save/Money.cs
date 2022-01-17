using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private float money;
    [SerializeField] private Text moneyText;

    private SaveData saveData;
    private float tim;

    private void Awake()
    {
        saveData = SaveSystem.Load();

        money = saveData.Money;
        moneyText.text = $"${money}";
    }
    private void Update()
    {
        tim += Time.deltaTime;
        if (tim < 10) {
            return;
        }
        saveData.Money = money;
        SaveSystem.Save(saveData);
        Debug.Log("Saved bsij");
        tim = 0;

    }
    private void OnValidate()
    {
        moneyText.text = $"${money}";
    }
}


