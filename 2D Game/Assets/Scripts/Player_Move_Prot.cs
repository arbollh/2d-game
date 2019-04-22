using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX; // Movement on the x-axis
	public bool isGrounded;
	public float playerRadius = 0.8f; // For raycast. Ex: Distance from (1) center of player sprite to (2) bottom of player sprite.

	void Update () {
		PlayerMove ();
		PlayerRaycast ();
	}


	void PlayerMove () {
		// Controls
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true) {
			Jump ();
		}

		// Animation

		// Player Direction
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}

		// Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}


	void Jump () {
		// Jumping Code
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;

	}


	void FlipPlayer () {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale; 
	}

	void OnCollisionEnter2D (Collision2D col) {
//		Debug.Log ("Player has collided with " + col.collider.name);
	}

	void PlayerRaycast () {

		// Ray Up – For breaking boxes 
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up); // Shoots a ray upwards
		if (rayUp != null && rayUp.collider != null && rayUp.distance < playerRadius && rayUp.collider.tag == "Chest") {
			Destroy (rayUp.collider.gameObject);
		}

		// Ray Down – For jumping on enemies
		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down); // Shoots a ray downwards
		if (rayDown != null && rayDown.collider != null && rayDown.distance < playerRadius && rayDown.collider.tag == "Enemy") {

			// Makes player bounce up
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);

			// Effects for enemy dropping off the screen
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			rayDown.collider.gameObject.GetComponent<Enemy_Move> ().enabled = false;

//			Destroy (rayDown.collider.gameObject);

		}
		if (rayDown != null && rayDown.collider != null && rayDown.distance < playerRadius && rayDown.collider.tag != "Enemy") {
			isGrounded = true;
		}
	}

}


