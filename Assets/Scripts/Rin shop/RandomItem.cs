using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [Header("List of gameobjects available in the shop")]
    [SerializeField] private GameObject[] items;
    [Header("List of gameobjects available in the shop (Attach the scriptable object)")]
    [SerializeField] private Weapon[] weapons;


    private int number;

    private void OnEnable()
    {
        TimeCycle.NewWeek += SelectRandomItem;
        Pickup.ItemBought += DisableItem;
    }

    private void OnDisable()
    {
        TimeCycle.NewWeek -= SelectRandomItem;
        Pickup.ItemBought -= DisableItem;
    }


    /// <summary> Select the random item if it's not equipped. It's also protecteed against having 1 items 2 weeks in row. </summary>
    private void SelectRandomItem()
    {
        items[number].SetActive(false);     

        while (true)
        {
            int selectedNum = Random.Range(0, items.Length);
            print(selectedNum);

            if(number != selectedNum && weapons[selectedNum].equipped == false)
            {
                number = selectedNum;
                items[selectedNum].SetActive(true);
                break;
            }           
        }
    }

    /// <summary> Disable the item when it's bought. </summary>
    private void DisableItem()
    {
        items[number].SetActive(false);
    }
}
