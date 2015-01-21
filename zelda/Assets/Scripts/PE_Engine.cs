using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PE_Dir{
	still,
	up,
	down,
	left,
	right
}


public class PE_Engine : MonoBehaviour {
	static public List<PE_Obj> objs;
	
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
		po.vel += tAcc*dt;
		
		if (po.vel.x==0){
			if (po.vel.y>0){
				po.dir = PE_Dir.up;
			}
			else if (po.vel.y<0){
				po.dir = PE_Dir.down;
			}
			else{
				po.dir = PE_Dir.still;
			}
		}
		else if (po.vel.x>0){
			if (po.vel.y!=0) {throw new UnityException();}
			po.dir = PE_Dir.right;
		}
		else{
			if (po.vel.y!=0) {throw new UnityException();}
			po.dir = PE_Dir.left;
		}
					
		//Position
		po.pos1 = po.pos0 = po.transform.position;
		po.pos1+= po.vel*dt;
	}


}
