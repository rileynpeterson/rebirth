using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject remotePanel;

    void Start()
    {
        remotePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked_remote()
    {

        remotePanel.SetActive(!remotePanel.activeSelf);
        if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
}
