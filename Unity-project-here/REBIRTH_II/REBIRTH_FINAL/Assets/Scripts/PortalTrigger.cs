using UnityEngine;
using System.Collections;

public class PortalTrigger : MonoBehaviour {

	public Portal portal;
	//public bool ignoreTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){

		//if (ignoreTrigger)
						//return;

		if (other.tag == "Player")
						portal.PortalOpens ();

		}

	void OnTriggerExit2D(Collider2D other){


		//if (ignoreTrigger)
			//return;

		if (other.tag == "Player")
			portal.PortalCloses();
		
	}

	/*public void Toggle(bool state)
	{
		if (state)
						portal.PortalOpens ();
				else
						portal.PortalCloses ();
		}*/


	/*void OnDrawGizmos()
	{
		if (!ignoreTrigger) {
			BoxCollider2D box = GetComponent<BoxCollider2D>();

			Gizmos.DrawWireCube(transform.position, new Vector2(box.size.x,box.size.y));

				}


	}*/
}