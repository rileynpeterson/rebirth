//written by Riley Peterson 3/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public string currentScene;

    // Update is called once per frame
    void Update()
    {
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
        SceneManager.LoadScene(currentScene);
        Resume();
    }

    public void Resume()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1f; //resumes time
        
    }

}