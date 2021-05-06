using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShake : MonoBehaviour
{
    private bool shaking;
    public float shakeAmt;
    void Start()
    {
        shaking = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }

    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        Vector3 originalPos = transform.position;
        if (!shaking)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(0.25f);
        shaking = false;
        transform.position = originalPos;
    }
}
