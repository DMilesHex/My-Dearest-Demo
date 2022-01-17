using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    [Header("How often should the autosave save the game")]
    [SerializeField] private float timeBeforeSave;

    [Header("Scripts that are saved:")]
    [SerializeField] private Money money;

    private SaveData saveData;
    private float time;

    private void Awake()
    {
        saveData = SaveSystem.Load();
    }
    // Update is called once per frame
    void Update()
    {
        CalculateTime();
    }

    private void CalculateTime()
    {
        if (time < timeBeforeSave)
            time += Time.deltaTime;
        else
        {
         //   saveData.Money = money.MoneyAmount;
            SaveSystem.Save(saveData);
            Debug.Log("Saved");
        }
            
    }
}
