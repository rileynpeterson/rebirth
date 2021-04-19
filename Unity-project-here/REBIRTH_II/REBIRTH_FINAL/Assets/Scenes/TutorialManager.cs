using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour { 

    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 630f;
    public PlatformerCharacter2D player;
    public GameObject continueScreen;
    public GameObject bluegem;
    public GameObject bluegeminv;
    public GameObject map;
    public GameObject mapinv;
    // Update is called once per frame

    void Start()
    {
       // player.ChangeJump(0);
        continueScreen.SetActive(false);
        for (int i = 0; i < popUps.Length; i++)
        {
            popUps[i].SetActive(false);
        }
        bluegem.SetActive(false);
        map.SetActive(false);
    }
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (Input.GetKey("right") || Input.GetKeyDown("left"))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // player.ChangeJump(700f);
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            bluegem.SetActive(true);
            if (bluegeminv.activeSelf)
            {
                popUpIndex++;
            }
        }

        else if (popUpIndex == 3)
        {
            map.SetActive(true);
            if (mapinv.activeSelf)
            {
                popUpIndex++;
            }
        }

        else if (popUpIndex == 4)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        else if (popUpIndex == 5)
        {
            continueScreen.SetActive(true);
        }
        
/*        if (player.IsDead() == true)
        {
            RestartTutorial();
        }*/

    }

    public void RestartTutorial()
    {
        popUpIndex = 0;
       
    }
}
