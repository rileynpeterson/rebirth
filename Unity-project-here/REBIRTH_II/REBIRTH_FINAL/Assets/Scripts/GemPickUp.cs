using UnityEngine;
using System;
using System.Collections;

public class GemPickUp : MonoBehaviour {

    private float originalY;
    public float bobStrength = 0.5f;

    void Start(){
        this.originalY = this.transform.position.y;
    }

    void Update() {
        transform.position = new Vector2(transform.position.x,
        originalY + ((float)Mathf.Sin(Time.time) * bobStrength));
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
        GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyThis()); }
    }

    IEnumerator DestroyThis(){
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}