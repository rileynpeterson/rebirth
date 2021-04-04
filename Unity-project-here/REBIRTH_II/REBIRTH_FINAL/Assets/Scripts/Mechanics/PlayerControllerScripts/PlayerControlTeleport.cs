 using UnityEngine;
 using System;
 using System.Collections;
 public class PlayerControlTeleport : MonoBehaviour
 {
  
    /*public void Teleport(Transform tp_trans)
    {
        Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        new_pos.z = tp_trans.position.z;
        tp_trans.position = new_pos;
    }*/
    //Set up a variable to access the player from
 private Transform player; 
 
 void Awake()
 {
 //Find the player object and set it
 player = GameObject.FindGameObjectWithTag("Player").transform;
 }
 
 void Update()
 {
 // Check if you click the left mouse button then change position
 if (Input.GetMouseButtonDown(0))
 player.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 }
 }
 