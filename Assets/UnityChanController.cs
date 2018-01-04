using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	Animator animator;

	Rigidbody2D rigid2d;

	private float groundLevel = -3.0f;

	private float dump = 0.8f;

	float jumpVelocity = 20;

	private float deadLine = -9;

	// Use this for initialization
	void Start () {

		this.animator = GetComponent<Animator> ();

		this.rigid2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		this.animator.SetFloat ("Horizontal", 1);

		bool isGround = (transform.position.y > groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);

		this.GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

		if (Input.GetMouseButtonDown(0) && isGround){

			this.rigid2d.velocity = new Vector2 (0, jumpVelocity);

		}

		if (Input.GetMouseButton(0) == false){

			if(this.rigid2d.velocity.y > 0){
				
				this.rigid2d.velocity *= this.dump;

			}

		}

		if(transform.position.x < deadLine){

			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver();

			Destroy (gameObject);

		}
		
	}
}
