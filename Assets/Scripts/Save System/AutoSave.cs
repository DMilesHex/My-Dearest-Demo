using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    [Header("How often should autosave the game")]
    [SerializeField] private float saveTime;

    [SerializeField] LoadAndSave LoadAndSave;
    private float time;

    private void Awake()
    {
        LoadAndSave.Load();
        LoadAndSave.Save();
        Debug.Log("Saved");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTime();
        Debug.Log(time);
    }

    private void CalculateTime()
    {
        if (time < saveTime)
            time += Time.deltaTime;
        else
        {
            
            time = 0;
            print("Saved");
        }
            
        
    }
}
