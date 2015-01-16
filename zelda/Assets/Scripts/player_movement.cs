﻿using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public float Speed = 10.0f;
	private Animator Link_animator;

	// Use this for initialization
	void Start () {
		Link_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//************ Movement ******************\\

		float hSpeed = Input.GetAxis ("Horizontal");
		float vSpeed = Input.GetAxis ("Vertical");

		if (hSpeed > 0) {
			// move right
			Link_animator.SetTrigger("right_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("left_arrow");
		}
		if (vSpeed > 0) {
			// move up
			Link_animator.SetTrigger("up_arrow");
			Link_animator.ResetTrigger("right_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("left_arrow");
		}
		if (hSpeed < 0) {
			// move left
			Link_animator.SetTrigger("left_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("right_arrow");
		}
		if (vSpeed < 0) {
			// move down
			Link_animator.SetTrigger("down_arrow");
			Link_animator.ResetTrigger("right_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("left_arrow");
		}

		this.rigidbody2D.velocity = new Vector2 (hSpeed * Speed, vSpeed * Speed);


		//*************attacking****************\\
		if(Input.GetButton("A")) {
			// attack with sword

		}




	}
}