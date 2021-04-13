using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    // Update is called once per frame
    private float timeElapsed;
    [SerializeField]
    private float delayBeforeLoading = 30f;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }
}
