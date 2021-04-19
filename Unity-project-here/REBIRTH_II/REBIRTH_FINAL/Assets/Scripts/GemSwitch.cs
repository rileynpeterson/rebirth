using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSwitch : MonoBehaviour
{

 [SerializeField]
 GameObject Iscollected;
 
 [SerializeField]
 GameObject Notcollected;

 public bool Gemcollected = false;

 void start()
 {
     //Set the gem switch to the not-collected sprite
     gameObject.GetComponent<SpriteRenderer>().sprite = Notcollected.GetComponent<SpriteRenderer>().sprite;
 }

 void OnTriggerEnter2D(Collider2D col)
 {
     //Set the gem switch to the is-collected sprite
    gameObject.GetComponent<SpriteRenderer>().sprite = Iscollected.GetComponent<SpriteRenderer>().sprite;

    //Set the gemcollected to true when triggered
    Gemcollected = true;
 }

}
