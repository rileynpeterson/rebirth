//written by Riley Peterson 3/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuRiley : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathScreen;
    public static bool dead = false;
    public string curr_level;

    // Update is called once per frame
    void Update()
    {
        if (deathScreen.activeSelf)
        {
            dead = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

             if (!dead && !GameIsPaused)
            {
                Pause();
            }


        }
    }

    //Resume function
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //resumes time
        GameIsPaused = false;
    }

    //Pause function
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //pauses time
        GameIsPaused = true;
    }

    //load menu function
    public void LoadMenu()
    {
        Time.timeScale = 1f; //resume time
        SceneManager.LoadScene("Menu");
    }

    //quit function
    public void QuitMenu()
    {
     
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(curr_level);
        Resume();
    }

    public void Disable()
    {

    }
}
