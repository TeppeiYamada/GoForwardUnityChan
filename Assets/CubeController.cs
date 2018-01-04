using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private float speed = -0.2f;

	private float deadLine = -10;

	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = gameObject.GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (this.speed, 0, 0);

		if(transform.position.x < deadLine){

			Destroy (gameObject);

		}
		
	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.tag == "CubeTag"){

			audioSource.Play ();

		}

		if(other.gameObject.tag == "GroundTag"){

			audioSource.Play ();

		}

	}
}
