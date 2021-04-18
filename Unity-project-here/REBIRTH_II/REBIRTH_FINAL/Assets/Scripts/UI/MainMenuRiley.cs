//written by Riley Peterson 3/28/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuRiley : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("Level II Draft");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
