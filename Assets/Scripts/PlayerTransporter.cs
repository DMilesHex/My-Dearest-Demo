using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerTransporter
{
    public static void LoadMap(int sceneIndex)
    {
        Debug.Log(sceneIndex);
        Scene levelToLoad = SceneManager.GetSceneByBuildIndex(sceneIndex);
        Debug.Log(levelToLoad.name);
        if (levelToLoad != null) SceneManager.LoadScene(levelToLoad.name);
    }
}
