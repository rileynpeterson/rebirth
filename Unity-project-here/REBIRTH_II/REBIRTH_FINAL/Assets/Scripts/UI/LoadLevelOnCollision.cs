using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        //if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
