using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [Header("The amount of money")]
    [SerializeField] private float money;
    [Header("Text")]
    [SerializeField] private Text moneyText;

    private SaveData saveData;

    private void OnEnable()
    {
        player.ValueChanged += TextChanged;
        Pickup.ItemPrice += PriceChange;
    }

    private void OnDisable()
    {
        player.ValueChanged -= TextChanged;
        Pickup.ItemPrice -= PriceChange;
    }

    public float MoneyAmount
    {
        get { return money; }
    }

    private void Awake()
    {
        saveData = SaveSystem.Load();

        money = saveData.Money;
        moneyText.text = $"${money}";
    }

    private void TextChanged(float moneyAmount)
    {
        money = moneyAmount;
        moneyText.text = $"${money}";
    }

    private void PriceChange(float price)
    {
        money -= price;
        moneyText.text = $"${money}";
    }

    private void OnValidate()
    {
        moneyText.text = $"${money}";
    }
}


