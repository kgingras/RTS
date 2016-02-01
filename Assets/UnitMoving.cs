using UnityEngine;
using System.Collections;

public class UnitMoving : MonoBehaviour {

	public Vector3 planet;
	public float acceleration = 9.0f;

	public Vector3 chkpnt = Vector3.zero;
	
	public int pathPos;

	//the speed, in units per second, we want to move towards the target
	public float speed = 1;

	float velocity;

	bool inCombat = false;
	Rigidbody rb;


	public bool selected = false;
	public bool inSelList = false;

	public Mouse msScript;

	private Renderer rend;
	// Use this for initialization
	void Start () {
//		path = GameObject.Find("Lane1").GetComponent<LanePath>().LanePoints;
//		rb = gameObject.GetComponent<Rigidbody>();
		rend = gameObject.GetComponent<Renderer>();
		msScript = GameObject.Find ("BaseManager").GetComponent<Mouse>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(!inCombat && chkpnt != Vector3.zero){
			transform.position = Vector3.Lerp (transform.position, chkpnt, speed*Time.deltaTime);

			//MoveTowardsTarget();
			if((transform.position-chkpnt).magnitude < 0.3){
				GetNextTarget();
			}
		}

		if(rend.isVisible && Input.GetMouseButton(0) && tag == "Bot"){
			selected = false;
			Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
			camPos.y = Mouse.InvertMouseY(camPos.y);
			selected = Mouse.selection.Contains(camPos);
//			if(selected && !inSelList){
//				Mouse.S.CurrentlySelectedUnits.Add((GameObject)this.gameObject);
//				inSelList = true;
//			}
		}

		if(selected){
			rend.material.color = Color.yellow;
			Transform target;
			if(msScript.lane == 1)chkpnt = msScript.Enemy1.transform.position;
			else if(msScript.lane == 2)chkpnt = msScript.Enemy2.transform.position;
			else if(msScript.lane == 3)chkpnt = msScript.Enemy3.transform.position;
			else if(msScript.lane == 4)chkpnt = msScript.Enemy4.transform.position;
			else{chkpnt = Vector3.zero;}
			if(Input.GetMouseButtonUp(1)){
				selected = false;
			}
		}
		else
			rend.material.color = Color.white;
	}


	private void MoveTowardsTarget() {

		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = chkpnt;
		
		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			//scale the movement on each axis by the directionOfTravel vector components
			
			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		}
	}

	public void GetNextTarget(){
//		if(gameObject.tag == "Top"){
//			pathPos++;
//			chkpnt = path[pathPos];
//		}
//		else if (gameObject.tag == "Bot"){
//			pathPos--;
//			chkpnt = path[pathPos];
//		}
	}

	public void SetPath(){
//		if(gameObject.tag == "Top"){pathPos = 0;}
//		else if(gameObject.tag == "Bot"){pathPos = 4;}
//		
//		chkpnt = path[pathPos];
	}

	void OnTriggerEnter(Collider coll){

		if(gameObject.tag == "Top" && coll.gameObject.tag == "HomeBase"){
			Destroy(gameObject);
		}
		else if (gameObject.tag == "Bot" && coll.gameObject.tag == "EnemyBase"){
			Destroy(gameObject);
		}

	}
}
