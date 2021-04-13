using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtons : MonoBehaviour
{
    public string level1;
    public string mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Play()
    {
        SceneManager.LoadScene(level1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainmenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
