using UnityEngine;
using System;
using System.Collections;

public class ReversedPlayerControlAnimated : MonoBehaviour {

      public float speed = 0.2f ;
      public string axisName = "Horizontal";
      public float jump = 1;
      public Animator anim;
    public GameObject keyinv;
    public GameObject mapinv;

    void Start () {
            anim = gameObject.GetComponent<Animator> ();
        keyinv.SetActive(false);
        mapinv.SetActive(false);
    }

      void Update () {
            //movement code
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
                  transform.position -= (transform.right * Input.GetAxis(axisName)* speed) * Time.deltaTime;
                  anim.SetBool("walk", true);}
            else { anim.SetBool("walk", false);}

            //jump code
            if (Input.GetKey(KeyCode.DownArrow)){
                  Vector3 position = this.transform.position;
                  position.y += (jump / 4) * Time.deltaTime;
                  this.transform.position = position;
                  anim.SetTrigger("jump");
            }

            anim.SetFloat("speed", Mathf.Abs(Input.GetAxis(axisName)));

            //flip character based on movement direction
            if (Input.GetAxis (axisName) < 0){
                  Vector3 newScale = transform.localScale;
                  newScale.x = 1.5f;
                  transform.localScale = newScale;
            }
            else if (Input.GetAxis (axisName) > 0){
                  Vector3 newScale =transform.localScale;
                  newScale.x = -1.5f;
                  transform.localScale = newScale;
            }
      }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PickUpKey")
        {
            other.gameObject.SetActive(false);
            keyinv.SetActive(true);
        }

        if (other.gameObject.tag == "PickUpMap")
        {
            other.gameObject.SetActive(false);
            mapinv.SetActive(true);
        }
    }
}