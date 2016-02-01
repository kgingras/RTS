using UnityEngine;
using System.Collections;

public class BaseManager : MonoBehaviour {

	public Transform Enemy1;
	public Transform Enemy2;
	public Transform Enemy3;
	public Transform Enemy4;
	
	public GameObject Home;
	public GameObject EnemyPrefab;

	public float base_rate = 1f;

	// Use this for initialization
	void Start () {
		Invoke("SpawnUnit", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnUnit(){
		
		GameObject baseUnit = Instantiate(EnemyPrefab, new Vector3(0f, .2f, 0f), Quaternion.identity) as GameObject;
		
		
		baseUnit.transform.position = new Vector3(Random.Range(-2f, 2f), .2f, Random.Range(-2f, 2f));
		
		//		if(lane ==1){enemy.GetComponent<UnitMoving>().path = Lane1;}
		//		else if(lane == 2){enemy.GetComponent<UnitMoving>().path = Lane2;}
		//		else if(lane == 3){enemy.GetComponent<UnitMoving>().path = Lane3;}
		//		else if(lane == 4){enemy.GetComponent<UnitMoving>().path = Lane4;}
		//		enemy.GetComponent<UnitMoving>().SetPath();
		
//		enemy.GetComponent<UnitMoving>().chkpnt = Home.transform;
		
		Invoke("SpawnUnit", 1f);
	}

}
