using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {


	public GameObject player;

	// Variables that will clamp the camera in a certain position
	public float xMin; // Least it can go on the x plane
	public float xMax; // Most it can go on the x plane
	public float yMin; // Least it can go on the y plane
	public float yMax; // Most it can go on the y plane


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player != null) {
			float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
			float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
			gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
		}

	}
}
