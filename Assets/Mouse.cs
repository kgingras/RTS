using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mouse : MonoBehaviour {

//	public static Mouse S;

	RaycastHit hit;

	public Texture2D selectionHighlight;
	public static Rect selection = new Rect(0,0,0,0);
	private Vector3 startClick = -Vector3.one;

	public List<GameObject> CurrentlySelectedUnits = new List<GameObject>(); //of Gameobject

	public int lane = 0;

	public Transform Enemy1;
	public Transform Enemy2;
	public Transform Enemy3;
	public Transform Enemy4;


//	public GUIStyle MouseDragSkin;
//
//	public GameObject Target;
//
//	private static Vector3 mouseDownPoint;
//	private static Vector3 mouseUpPoint;
//	private static Vector3 currentMouse;
//
//	public static bool UserIsDragging;
//	private static float TimeLimitBeforeDeclaringDrag = 1f;
//	private static float TimeLeftBegoreDeclareDrag;
//	private static Vector2 MouseDragStart;
//
//	private static float clickDragZone = 1.3f;

	void Awake(){
//		mouseDownPoint = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		CheckCamera();

		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
				if (hit.transform.name == "Lane1" ) lane = 1;
				else if (hit.transform.name == "Lane2" ) lane = 2;
				else if (hit.transform.name == "Lane3" ) lane = 3;
				else if (hit.transform.name == "Lane4" ) lane = 4;
				else lane = 0;
			}
		}
		if(Input.GetMouseButtonUp(1)){
			lane = 0;
		}
	}

	private void RemoveUnselectedUnits(){
		foreach (GameObject item in CurrentlySelectedUnits.ToArray())
		{
			if (!item.GetComponent<UnitMoving>().selected ) CurrentlySelectedUnits.Remove(item);
		}
	}


	private void CheckCamera(){

		if(Input.GetMouseButtonDown(0))
			startClick = Input.mousePosition;
		else if(Input.GetMouseButtonUp(0)){
			if(selection.width < 0){
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			if (selection.height < 0){
				selection.y += selection.height;
				selection.height = -selection.height;
			}

			startClick = -Vector3.one;
		}

		if (Input.GetMouseButton(0)){
			selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
		}

	}

	private void OnGUI(){
		if (startClick!=-Vector3.one){
			GUI.color = new Color(1, 1, 1, .5f);
			GUI.DrawTexture(selection, selectionHighlight);
		}

	}

	public static float InvertMouseY(float y){
		return Screen.height - y;
	}

			            
}
