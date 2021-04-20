using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDoor : MonoBehaviour
{
    [SerializeField] 
    private GemSwitch.GemType gemType;

    public GemSwitch.GemType GetGemType()
    {
        return gemType;
    }

    public void OpenPortal()
    {
        gameObject.SetActive(false);
    }

}
