using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour { 

    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 10f;
    public PlatformerCharacter2D player;
    public GameObject continueScreen;
    // Update is called once per frame

    void Start()
    {
        player.ChangeJump(0);
    }
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
            else if(popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.ChangeJump(400f);
                    popUpIndex++;
                }
            }
            else if(popUpIndex == 2)
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
            else if (popUpIndex == 3)
            {
                continueScreen.SetActive(true);
            }
        }
        
        if (player.IsDead() == true)
        {
            RestartTutorial();
        }

    }

    public void RestartTutorial()
    {

    }
}
