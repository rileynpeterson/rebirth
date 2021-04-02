using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private bool FaceRight = true;  // determine which way player is facing.
	public float runSpeed = 10f;

	void Update () {
		//Horizontal axis: [a]/left arrow is -1, [d]/right arrow is 1
		Vector3 hMove = new Vector3(Input.GetAxis ("Horizontal"), 0.0f, 0.0f );
		transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

		// if input is moving player right and player faces left, turn, and vice-versa
		if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight)){
			Turn();
		}
	}

	private void Turn()
	{
		// Switch player facing label
		FaceRight = FaceRight;

		// Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}