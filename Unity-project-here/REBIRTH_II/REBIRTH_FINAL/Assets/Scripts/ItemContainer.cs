using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour {

      public GameHandler gameController;
      public string ItemName;

      void Awake(){
            GameObject gameControllerLocation = GameObject.FindWithTag("GameController");
            if (gameControllerLocation != null) {
                  gameController = gameControllerLocation.GetComponent<GameHandler>();
            }
      }

      void OnTriggerEnter2D(Collider2D coll){
            if (coll.tag == "Player"){
                  //Debug.Log("You found an" + ItemName);
                  gameController.InventoryAdd(ItemName);
                  //gameController.removeObjectFromLevel(ItemName);
                  Destroy(gameObject);
            }
      }
}