using UnityEngine;
using System.Collections;

public class LookAtCam : MonoBehaviour {

	public Transform Cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(Cam.position);
		
	}
}
