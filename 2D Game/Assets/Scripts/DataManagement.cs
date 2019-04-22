using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour {

	public static DataManagement dataManagement;

	public int highScore; 

	// Save Game Functionality:
	// If there is no gameObject called "dataManagement", then set dataManagement to this. (Make a save state)
	// If there is a dataManagement, destroy it and use the current instance as dataManagement instead. (Overwrite an old save state with a new one)
	void Awake () {
		if (dataManagement == null) {
			DontDestroyOnLoad (gameObject);
			dataManagement = this;
		} else if (dataManagement != this) {
			Destroy (gameObject);
		}
	}

	public void SaveData () {
		// Data is saved
		BinaryFormatter BinForm = new BinaryFormatter (); // Creates a binary formatter
		FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat"); // Creates save file
		gameData data = new gameData(); // Creates container for data
		data.highscore = highScore; // Saves high score variable. Add more variables for saving more stuff.
		BinForm.Serialize (file, data); // Serializes
		file.Close(); // Closes the file

	}

	public void LoadData () {
		// Data is loaded
		if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
			BinaryFormatter BinForm = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			gameData data = (gameData)BinForm.Deserialize (file);
			file.Close();
			highScore = data.highscore;
		}
	}

}

// When we save data, we save it to this class, and loaded data comes from this class.
[Serializable]
class gameData {

	public int highscore;

}
