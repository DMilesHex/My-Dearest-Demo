using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AutoSave autoSave;

    private void Awake() => pauseMenu.SetActive(false);

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (pauseMenu.activeSelf) 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        autoSave.Save();
        Application.Quit();
    }
}
