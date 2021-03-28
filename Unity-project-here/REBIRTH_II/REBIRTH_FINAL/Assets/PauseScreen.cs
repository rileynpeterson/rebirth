using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //checks if the player presses "x" which should bring up the menu screen by setting that game object to true. 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(StartScreen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
