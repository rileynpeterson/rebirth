using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        //checks if the player presses "x" which should bring up the menu screen by setting that game object to true. 
        if (Input.GetKeyDown("x"))
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

    }

    public void QuitGame()
    {

    }
}
