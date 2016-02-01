using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float rotateSpeed = 40;
	public GameObject Center;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.D)){
			//rotate Right
			transform.RotateAround(Vector3.zero, -Vector3.up, rotateSpeed * Time.deltaTime);
			
		}
		else if(Input.GetKey(KeyCode.A)){
			//rotate Left
			transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
			
		}
		if(Input.GetKey(KeyCode.S)){
			//rotate Down
			transform.RotateAround(Vector3.zero, Center.transform.right, rotateSpeed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.W)){
			//rotate Up
			transform.RotateAround(Vector3.zero, -Center.transform.right, rotateSpeed * Time.deltaTime);
		}


	}
}
