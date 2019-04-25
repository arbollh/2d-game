using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // So we can access the UI elements

public class Enemy_Move : MonoBehaviour {

	public int EnemySpeed;
	public int xMoveDirection;


	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 2.2f) {
			Flip ();
			if (hit.collider.tag == "Player") {
				Destroy (hit.collider.gameObject);
				ResetScene ();
			}
		}

	}

	void Flip () {
		if (xMoveDirection > 0.5) {
			xMoveDirection = -1;
		} else {
			// Changes movement direction on the x-axis
			xMoveDirection = 1;
			// Flips Enemy sprite
			Vector2 localScale = gameObject.transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}

	void ResetScene () {
		Player_Score.playerScore = 0;
		SceneManager.LoadScene ("Prototype_1");
	}
}
