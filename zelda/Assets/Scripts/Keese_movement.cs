using UnityEngine;
using System.Collections;

public class Keese_movement : MonoBehaviour {

	public float speed = 1f;
	
	//Distance where keese turns around
	public float leftAndRightEdge = 1f;
	
	//Chance that the keese will change directions
	public float chanceToChangeDirections = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		//Basic Movement
		Vector2 pos = transform.position;
		if (Random.value < chanceToChangeDirections){
			pos.x += speed * Time.deltaTime;
		}
		else{
			pos.y+= speed*Time.deltaTime;
		}
		//pos.x += speed * Time.deltaTime;
		transform.position = pos;
		
		//Changing Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		}
		else if (pos.x > leftAndRightEdge){
			speed = -Mathf.Abs (speed);
		}
		
		
		if (pos.y < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		}
		else if (pos.y > leftAndRightEdge){
			speed = -Mathf.Abs (speed);
		}
		
		
	}
	
	void FixedUpdate(){
		if (Random.value < chanceToChangeDirections){
			speed*=-1;
		}
		
	}
}
