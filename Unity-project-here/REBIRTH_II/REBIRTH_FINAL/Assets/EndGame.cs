//written by Riley Peterson 5/10/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject EndGameMenuUI;

    //load menu function
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //quit function
    public void QuitMenu()
    {

        Application.Quit();
    }

   
}
