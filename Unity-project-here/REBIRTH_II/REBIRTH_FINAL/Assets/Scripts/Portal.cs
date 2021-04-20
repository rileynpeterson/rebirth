using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PortalOpens()
	{
		anim.SetBool ("Opens", true);
		}

	public void PortalCloses()
	{
		anim.SetBool ("Opens", false);
	}

	void CollEnable()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	void CollDisable()
	{
		GetComponent<Collider2D>().enabled = false;
	}



}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool IsOpen;

    //Animator myAnimator;

    Collider2D myCollider;

    void start()
    {
        //myAnimator = GetComponent<PortalOpen>();
        myCollider = GetComponent<Collider2D>();
    }

    public void open()
    {
        if (!IsOpen)
            SetState(true);
    }

    public void close()
    {
        if (IsOpen)
            SetState(false);
    }

    public void Toggle()
    {
        if (IsOpen)
            close();
        else
            open();
    }

    void SetState(bool open)
    {
        IsOpen = open;
        //myAnimator.SetBool("Open", open);
        myCollider.isTrigger = open; 
    }
}*/
