using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;

    public GameController newgameController;
    public int totalgems;



    void OnTriggerEnter2D(Collider2D collision)
    {
        int x = newgameController.getScore();

        if (x == totalgems /*&& collision.gameObject.tag == "Player"*/)
        //if (collision.gameObject.tag == "Player")
        //if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Debug.Log(x);
        }
    }

    public int getTotalgems()
    {
        return totalgems;
    } 
}
