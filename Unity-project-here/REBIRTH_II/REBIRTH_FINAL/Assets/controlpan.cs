using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controlpan : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                panel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ClickedPanel()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
