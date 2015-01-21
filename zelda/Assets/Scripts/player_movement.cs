using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
	private PE_Obj peo;
	public float Speed = 10.0f;
	private Animator Link_animator;

	// Use this for initialization
	void Start () {
		Link_animator = GetComponent<Animator> ();
		peo = GetComponent<PE_Obj>();
	}
	
	// Update is called once per frame
	void Update () {
		//************ Movement ******************\\

		float hSpeed = Input.GetAxis ("Horizontal");
		float vSpeed = Input.GetAxis ("Vertical");

		Link_animator.SetFloat ("vSpeed", Mathf.Abs (vSpeed));
		Link_animator.SetFloat ("hSpeed", Mathf.Abs (hSpeed));

		if (hSpeed > 0) {
			// move right
			Link_animator.SetTrigger("right_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("left_arrow");
			 peo.vel = new Vector2 (hSpeed * Speed, 0);
		}
		if (vSpeed > 0) {
			// move up
			Link_animator.SetTrigger("up_arrow");
			Link_animator.ResetTrigger("right_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("left_arrow");
			peo.vel = new Vector2 (0, vSpeed * Speed);
		}
		if (hSpeed < 0) {
			// move left
			Link_animator.SetTrigger("left_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("right_arrow");
			peo.vel = new Vector2 (hSpeed * Speed, 0);
		}
		if (vSpeed < 0) {
			// move down
			Link_animator.SetTrigger("down_arrow");
			Link_animator.ResetTrigger("right_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("left_arrow");
			peo.vel = new Vector2 (0, vSpeed * Speed);
		}

		if (vSpeed == 0 && hSpeed == 0) {
			peo.vel = new Vector2 (0, 0);
		}



		//*************attacking****************\\
		if(Input.GetButton("A")) {
			// attack with sword
			Link_animator.SetTrigger("A_button");
			Link_animator.ResetTrigger("down_arrow");
			Link_animator.ResetTrigger("right_arrow");
			Link_animator.ResetTrigger("up_arrow");
			Link_animator.ResetTrigger("left_arrow");
			peo.vel = new Vector2 (0, 0);
		}
	}
}
