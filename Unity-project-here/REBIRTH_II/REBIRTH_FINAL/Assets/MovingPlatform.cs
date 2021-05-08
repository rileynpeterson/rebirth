using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   /* [SerializeField]
    private Vector3 velocity;
    public PlayerController spike;

    private bool moving;
	float dirX, moveSpeed = 3f;
	bool moveRight = true;
    bool SpikedBot = false;

    public int rightBound;
    public int leftBound;

	// Update is called once per frame
	void Update () {
		if (transform.position.x > rightBound || spike.robotSpiked())
			moveRight = false;
		if (transform.position.x < leftBound || spike.robotSpiked())
			moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}*/
   /* public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;
 
        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time/Vector3.Distance(startPosition, target))*speed);
            time += Time.deltaTime;
            yield return null;
        }   
    }

       void Start()
    {
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }

     void Update()
    {
        if(transform.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if(transform.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }*/

   /*public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rBody;
 
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }
 
    void Update()
    {
        if(rBody.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if(rBody.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }
 
    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector2 target, float speed)
    {
        Vector2 startPosition = obj.transform.position;
        float time = 0f;
 
        while(rBody.position != target)
        {
            rBody.MovePosition(Vector2.Lerp(startPosition, target, (time/Vector2.Distance(startPosition, target))*speed));
            time += Time.deltaTime;
            yield return null;
        }   
    }*/

    /*public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rBody;
 
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }
 
    void Update()
    {
        if(rBody.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if(rBody.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }
 
    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector2 target, float speed)
    {
        Vector2 startPosition = obj.transform.position;
        float time = 0f;
 
        while(rBody.position != target)
        {
            obj.transform.position = Vector2.Lerp(startPosition, target, (time/Vector2.Distance(startPosition, target))*speed);
            time += Time.deltaTime;
            yield return null;
        }   
    }
 
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit Platform II");
        col.gameObject.transform.SetParent(gameObject.transform,true);
    }
 
    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit me baby one more time!");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hitting Platform!");
        if(collision.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Hitting Platform!");
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }*/
    private GameObject target=null;
    private Vector3 offset;
    void Start(){
     target = null;
    }
    void OnTriggerStay2D(Collider2D col){
     target = col.gameObject;
     offset = target.transform.position - transform.position;
    }
    void OnTriggerExit2D(Collider2D col){
     target = null;
    }
    void LateUpdate(){
     if (target != null) {
         target.transform.position = transform.position+offset;
     }
 }
}
