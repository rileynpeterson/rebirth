using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSwitch : MonoBehaviour
{
 //Animator myAnimator;


 [SerializeField]
 GameObject isCollected;

 [SerializeField]
 GameObject notCollected;

 public Sprite demoSprite;

 public bool gemCollected = false;

 void start()
 {
     //myAnimator = GetComponent<myAnimator>();
     //Set the gem switch to the not-collected sprite
     gameObject.GetComponent<SpriteRenderer>().sprite = notCollected.GetComponent<SpriteRenderer>().sprite;
 }

 void SetState()
 {
     //myAnimator.SetBool("On", on);
 }

 void OnTriggerEnter2D(Collider2D col)
 {
     //Set the gem switch to the is-collected sprite
    gameObject.GetComponent<SpriteRenderer>().sprite = isCollected.GetComponent<SpriteRenderer>().sprite;
  //GameObject.GetComponent<SpriteRenderer>().sprite = demoSprite;
    //Set the gemcollected to true when triggered
    gemCollected = true;
 }

}
