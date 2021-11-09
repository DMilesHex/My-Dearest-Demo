using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerTransporter
{
    public static void LoadMap(string sceneIndex)
    {
        Debug.Log(sceneIndex);
        
        
         SceneManager.LoadScene(sceneIndex);
    }
}
