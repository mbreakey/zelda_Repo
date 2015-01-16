using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PE_GravType{
	none,
	constant
}


public class PE_Engine : MonoBehaviour {
	static public List<PE_Obj> objs;
	public Vector2 gravity = new Vector2(0,-9.8f);

	void Awake(){
		objs = new List<PE_Obj>();
	}


	void FixedUpdate(){
		float dt = Time.fixedDeltaTime;
		foreach (PE_Obj po in objs){
			TimeStep(po,dt);
		}
		
		//Resolve collisions
		
		//Finalize positions
		foreach(PE_Obj po in objs){
			po.transform.position = po.pos1;
		}
	}
	

	public void TimeStep(PE_Obj po, float dt){
		
		//Velocity
		po.vel0 = po.vel;
		Vector2 tAcc = po.acc;
		tAcc += gravity;
		po.vel += tAcc*dt;
		
		//Position
		po.pos1 = po.pos0 = po.transform.position;
		po.pos1+= po.vel*dt;
		
	}


}
