using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject menu;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Leave()
    {
        PlayerTransporter.LoadMap(sceneToLoad);
        Destroy(gameObject);
    }


}
