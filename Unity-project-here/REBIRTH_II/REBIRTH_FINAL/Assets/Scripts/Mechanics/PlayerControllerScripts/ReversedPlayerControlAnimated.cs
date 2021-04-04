using UnityEngine;
using System;
using System.Collections;

public class ReversedPlayerControlAnimated : MonoBehaviour {

      public float speed = 0.2f ;
      public string axisName = "Horizontal";
      public float jump = 1;
      public Animator anim;

      void Start () {
            anim = gameObject.GetComponent<Animator> ();
      }

      void Update () {
            //movement code
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
                  transform.position -= transform.right * Input.GetAxis(axisName)* speed;
                  anim.SetBool("walk", true);}
            else { anim.SetBool("walk", false);}

            //jump code
            if (Input.GetKey(KeyCode.DownArrow)){
                  Vector3 position = this.transform.position;
                  position.y += jump / 4;
                  this.transform.position = position;
                  anim.SetTrigger("jump");
            }

            anim.SetFloat("speed", Mathf.Abs(Input.GetAxis(axisName)));

            //flip character based on movement direction
            if (Input.GetAxis (axisName) < 0){
                  Vector3 newScale = transform.localScale;
                  newScale.x = 1.0f;
                  transform.localScale = newScale;
            }
            else if (Input.GetAxis (axisName) > 0){
                  Vector3 newScale =transform.localScale;
                  newScale.x = -1.0f;
                  transform.localScale = newScale;
            }
      }
}