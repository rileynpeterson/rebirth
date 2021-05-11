//written by Riley Peterson 3/28/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;


public class MainMenuRiley : MonoBehaviour
{

    public AudioMixer audioMixer;
    public GameObject volumeMenuUI;
    public GameObject mainMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial_Level_One");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Volume()
    {
        volumeMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Back()
    {
        volumeMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

}
