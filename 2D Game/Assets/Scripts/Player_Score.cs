using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // So we can access the UI elements

public class Player_Score : MonoBehaviour {

	public float timeLeft = 100; // Time left to finish the level
	public static int playerScore = 0; 
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	public bool completedLevel = false;


	void Start () {
		// Saves score between scenes
		DataManagement.dataManagement.LoadData();
	}

	void Update () {
		timeLeft -= Time.deltaTime; // Ticks value down one second at a time
//		Debug.Log (timeLeft);
		timeLeftUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)playerScore);
			
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Prototype_1");
		}
	}

	void OnTriggerEnter2D (Collider2D trig) {
//		Debug.Log ("Touched the end of the level");
		if (trig.gameObject.name == "EndLevel" && completedLevel != true) {
			completedLevel = true;
			CountScore ();
			// Uncomment the below code when we are ready to add the next level
			// SceneManager.LoadScene ("Level_2");
		}
		if (trig.gameObject.name.Contains ("Coin")) {
			playerScore += 10;
			Destroy (trig.gameObject);
		}

	}

	void CountScore () {
		playerScore = playerScore + (int)(timeLeft * 10);
//		Debug.Log (playerScore);
		DataManagement.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
		DataManagement.dataManagement.SaveData (); // Saves game data
	}
}

