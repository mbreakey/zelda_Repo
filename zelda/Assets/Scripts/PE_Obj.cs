using UnityEngine;
using System.Collections;

public class PE_Obj : MonoBehaviour {
	
	
	public Vector2 acc = Vector2.zero;
	public Vector2 vel = Vector2.zero;
	public Vector2 vel0 = Vector2.zero;
	
	public Vector2 pos0 = Vector2.zero;
	public Vector2 pos1 = Vector2.zero;
	
	public PE_Dir dir = PE_Dir.still;
	
	//Use this for initialization
	void Start () {
		if (PE_Engine.objs.IndexOf(this) == -1){
			PE_Engine.objs.Add(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (this.name == "Link"){
			OnTriggerEnter2D(other);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		PE_Obj otherPEO = other.GetComponent<PE_Obj>();
		if (otherPEO == null) return;
		
		ResolveCollisionWith(otherPEO);
	}
	
	void ResolveCollisionWith(PE_Obj that){
		Debug.Log("PLEASE",gameObject);
		Vector2 posFinal = pos1;
		Vector2 a0,a1,b;
		a0 = a1 = b = Vector2.zero;
		Vector2 delta = pos1 - pos0;
		
		switch (dir){
		case PE_Dir.down:
			// Just resolve to be on top
			a1 = pos1;
			a1.y -= transform.lossyScale.y/2f;
			b = that.pos1;
			b.y += that.transform.lossyScale.y/2f;
			if (b.y > a1.y) {
				posFinal.y += Mathf.Abs( a1.y - b.y )-5;
			}
			
			// Handle vel
			vel.y = 0;
			break;
		
		case PE_Dir.up:
			// Just resolve to be below
			a1 = pos1;
			a1.y += transform.lossyScale.y/2f;
			b = that.pos1;
			b.y -= that.transform.lossyScale.y/2f;
			if (b.y < a1.y) {
				posFinal.y -= Mathf.Abs( a1.y - b.y )-5;
			}
			
			// Handle vel
			vel.y = 0;
			break;
			
		case PE_Dir.left:
			// Just resolve on right
			a1 = pos1;
			a1.x -= transform.lossyScale.x/2f;
			b = that.pos1;
			b.x += that.transform.lossyScale.x/2f;
			if (b.x > a1.x) {
				posFinal.x += Mathf.Abs( a1.x - b.x )-5;
			}
			
			// Handle vel
			vel.y = 0;
			break;
		
		case PE_Dir.right:
			//just resolve on left
			a1 = pos1;
			a1.x += transform.lossyScale.x/2f;
			b = that.pos1;
			b.x -= that.transform.lossyScale.x/2f;
			if (b.x < a1.x) {
				posFinal.x -= Mathf.Abs( a1.x - b.x )-5;
			}
			
			// Handle vel
			vel.y = 0;
			break;
		}
		
		transform.position = pos1 = posFinal;
	
	}
}
