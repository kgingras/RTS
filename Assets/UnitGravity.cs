using UnityEngine;
using System.Collections;

public class UnitGravity : MonoBehaviour {

	public float gravity = -9.8f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 gravityDirection = (transform.position - Vector3.zero).normalized;
		rb.AddForce(gravityDirection * gravity);
	}

	void OnTriggerStay(Collider other) {
		// get the direction vector and normalize it (magnitude = 1)
		Vector3 direction = other.transform.position - Vector3.zero;
		Vector3 force = direction.normalized * gravity;
		
		// accelerate the object in that direction
		rb.AddForce(force, ForceMode.Acceleration);
	}
}
