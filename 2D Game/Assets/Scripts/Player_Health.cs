using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // So we can access the UI elements

public class Player_Health : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -7) {
			Die ();
			Player_Score.playerScore = 0;
		}
	}

	void Die () { 
		SceneManager.LoadScene ("Prototype_1");
	}

}


