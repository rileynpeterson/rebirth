using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] gems;

    [SerializeField]
    GameObject exitPortal;

    int noOfGems;

    [SerializeField]
    Text gemCount;

    void Start()
    {
        GetNoOfGems();
    }

    public int GetNoOfGems()
    {
        int x = 0;

        for(int i = 0; i < gems.Length; i++)
        {
            if(gems[i].GetComponent<GemSwitch>().gemCollected == false)
            {
                x++;
            }
            else if(gems[i].GetComponent<GemSwitch>().gemCollected == true)
            {
                noOfGems--;
            }
        }
        noOfGems = x;


        return noOfGems;
    }

    /*public void GetexitPortalState()
    {
        if(noOfGems <= 0)
        {
            exitPortal.GetComponent<exitPortal>().ActivatePortal();
        }
    }*/

    void Update()
    {
//        gemCount.text = GetNoOfGems().ToString();

        //GetexitPortalState();
    }

}
