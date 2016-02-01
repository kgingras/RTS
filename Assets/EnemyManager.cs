using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject Board;

	public Transform[] Lane1;
	public Transform[] Lane2;
	public Transform[] Lane3;
	public Transform[] Lane4;

	public Transform Enemy1;
	public Transform Enemy2;
	public Transform Enemy3;
	public Transform Enemy4;

	public GameObject Home;
	public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {
//		Lane1 = GameObject.Find("Lane1").GetComponent<LanePath>().LanePoints;
//		Lane2 = GameObject.Find("Lane2").GetComponent<LanePath>().LanePoints;
//		Lane3 = GameObject.Find("Lane3").GetComponent<LanePath>().LanePoints;
//		Lane4 = GameObject.Find("Lane4").GetComponent<LanePath>().LanePoints;

		Invoke("SpawnUnit", 1f);
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void SpawnUnit(){

		GameObject enemy = Instantiate(EnemyPrefab, new Vector3(0.1f, 10.01f, 0.1f), Quaternion.identity) as GameObject;
		

		int lane = Random.Range(1, 5);

		if(lane ==1){enemy.transform.position = Enemy1.transform.position;}
		else if(lane == 2){enemy.transform.position = Enemy2.transform.position;}
		else if(lane == 3){enemy.transform.position = Enemy3.transform.position;}
		else if(lane == 4){enemy.transform.position = Enemy4.transform.position;}


//		if(lane ==1){enemy.GetComponent<UnitMoving>().path = Lane1;}
//		else if(lane == 2){enemy.GetComponent<UnitMoving>().path = Lane2;}
//		else if(lane == 3){enemy.GetComponent<UnitMoving>().path = Lane3;}
//		else if(lane == 4){enemy.GetComponent<UnitMoving>().path = Lane4;}
//		enemy.GetComponent<UnitMoving>().SetPath();

		enemy.GetComponent<UnitMoving>().chkpnt = Home.transform.position;

		Invoke("SpawnUnit", 1f);
	}
}
