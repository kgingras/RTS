using UnityEngine;
using System.Collections;

public class RotateBoard : MonoBehaviour {

	public float spinSpeed = 2;
	public float damping = 2;
	
	public Transform homeTarget;
	public Transform enemyTarget;


	public 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if(Input.GetKey(KeyCode.D)){
//			//rotate Right
//			transform.Rotate(Vector3.up*Time.deltaTime*spinSpeed);
//
//		}
//		else if(Input.GetKey(KeyCode.A)){
//			//rotate Left
//			transform.Rotate(-1*Vector3.up*Time.deltaTime*spinSpeed);
//		}
//		else if(Input.GetKey(KeyCode.S)){
//			//rotate Down
//			Quaternion wuat= Quaternion.LookRotation(enemyTarget.position - transform.position);
//			transform.rotation = Quaternion.Slerp(transform.rotation, wuat, Time.deltaTime*damping);
//			
//		}
//		else if(Input.GetKey(KeyCode.W)){
//			//rotate Up
//			Quaternion wuat= Quaternion.LookRotation(homeTarget.position - transform.position);
//			transform.rotation = Quaternion.Slerp(transform.rotation, wuat, Time.deltaTime*damping);
//
//		}


	}
}
