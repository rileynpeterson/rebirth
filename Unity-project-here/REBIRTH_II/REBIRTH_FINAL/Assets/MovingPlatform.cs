using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	float dirX, moveSpeed = 3f;
	bool moveRight = true;

	// Update is called once per frame
	void Update () {
		if (transform.position.x > 30f)
			moveRight = false;
		if (transform.position.x < 15f)
			moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}
}
