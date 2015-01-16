using UnityEngine;
using System.Collections;

public class PE_Obj : MonoBehaviour {
	public PE_GravType grav = PE_GravType.constant;
	
	
	public Vector2 acc = Vector2.zero;
	public Vector2 vel = Vector2.zero;
	public Vector2 vel0 = Vector2.zero;
	
	public Vector2 pos0 = Vector2.zero;
	public Vector2 pos1 = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		if (PE_Engine.objs.IndexOf(this) == -1){
			PE_Engine.objs.Add(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
