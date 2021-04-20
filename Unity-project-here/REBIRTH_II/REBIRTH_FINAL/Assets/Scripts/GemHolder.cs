using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHolder : MonoBehaviour
{
    private List<GemSwitch.GemType> gemList;
    private void Awake()
    {
        gemList = new List<GemSwitch.GemType>();

    }

    public void AddGem(GemSwitch.GemType gemType)
    {
        Debug.Log("Added gem: " + gemType);
        gemList.Add(gemType);
    }

    public void RemoveGem(GemSwitch.GemType gemType)
    {
        gemList.Remove(gemType);
    }

    public bool ContainsGem(GemSwitch.GemType gemType)
    {
        return gemList.Contains(gemType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GemSwitch gem = collider.GetComponent<GemSwitch>();
        if (gem != null)
        {
            AddGem(gem.GetGemType());
            Destroy(gem.gameObject);
        }

        GemDoor gemDoor = collider.GetComponent<GemDoor>();
        {
            if(gemDoor != null)
            {
                if(ContainsGem(gemDoor.GetGemType()));
                // Currently holding key to open this
                RemoveGem(gemDoor.GetGemType());
                gemDoor.OpenPortal();
            }
        }
    }
}
