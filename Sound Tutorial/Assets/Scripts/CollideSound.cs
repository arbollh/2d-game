using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSound : MonoBehaviour {

	public AudioClip clip1;
	private AudioSource source;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

//	void OnCollisionEnter (Collision other) {
//
//		if (other.GameObject.name == "Capsule") {
//			Debug.Log("Collide");
//		}
//
//	}
}
