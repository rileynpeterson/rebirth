//written by Riley Peterson 3/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;

public class PauseMenuRiley : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject volumeMenuUI;
    public GameObject deathScreen;
    public static bool dead = false;
    public string curr_level;
    public AudioMixer audioMixer;

    // Update is called once per frame
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else 
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
        GameIsPaused = false;
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

    public void Volume()
    {
        volumeMenuUI.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Back()
    {
        volumeMenuUI.SetActive(false);
    }

}
