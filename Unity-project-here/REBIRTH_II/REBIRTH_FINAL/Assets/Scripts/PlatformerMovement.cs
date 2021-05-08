using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
 
public class PlatformerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private bool isOnPlatform;
    private Rigidbody2D platformRBody;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
 
    void FixedUpdate()
    {
        if(isOnPlatform)
        {
            rbody.velocity = rbody.velocity + platformRBody.velocity;
        }
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit Platform One");
        if(col.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Hit Platform");
            platformRBody = col.gameObject.GetComponent<Rigidbody2D>();
            isOnPlatform = true;
        }
    }
 
    void OnTriggerExit2D(Collider2D col)
    {   
        if(col.gameObject.tag == "MovingPlatform")
        {
            isOnPlatform = false;
            platformRBody = null;
        }
    }
}