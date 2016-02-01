using UnityEngine;
using System.Collections;

public class zoom : MonoBehaviour {

	public float zoomSpeed = 2;

	public Transform minZoom;
	public Transform maxZoom;

	public float rotateSpeed = 40;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			//zoom
			transform.position = Vector3.Lerp(transform.position, maxZoom.position, Time.deltaTime*zoomSpeed);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0){
			//mooz
			transform.position = Vector3.Lerp(transform.position, minZoom.position, Time.deltaTime*zoomSpeed);
		}





		transform.LookAt(Vector3.zero);
	}
}
