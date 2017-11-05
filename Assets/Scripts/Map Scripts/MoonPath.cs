using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPath : MonoBehaviour {

	public GameObject[] moonPath = new GameObject[8];

	GameObject target;
	GameObject player;
	public float MoonDist = 100f;

	// Use this for initialization
	void Start () {
	    target = GameObject.Find("Moon 1");
		TurnOff ();
		if (target != null)
			SetPath (target.GetComponent<MoonPos>().GetMoonPos());
		player = GameObject.Find("Player") ;
	}
	
	// Update is called once per frame
	void Update () {
		TurnOff ();
		if (target != null)
			SetPath (target.GetComponent<MoonPos>().GetMoonPos());
	}

	public void TurnOff(){
		for (int i = 0; i < 8; i++)
			moonPath [i].SetActive (false);
	}

	public void SetPath( int path) {
		moonPath [path].SetActive (true);
	}

	public void PathChoose() {
		int CurrentPath = -1;
		if (target != null)
			CurrentPath = target.GetComponent<MoonPos>().GetMoonPos();
		if (CurrentPath == -1) {
			Debug.Log ("Target not found for MoonPath");
			return;
		}
		else if (CurrentPath == 0 || CurrentPath == 4)
			YellowPath ();
		else if (CurrentPath > 0 && CurrentPath < 4)
			RedPath ();
		else if (CurrentPath > 4 && CurrentPath < 8)
			GreenPath ();
	}

	public void YellowPath() {
		if (player != null) {
			
			if (player.GetComponent<Player> ().CurrentLocationID == 1)
				player.GetComponent<Player> ().TargetLocationID = 2;
			
			else if (player.GetComponent<Player> ().CurrentLocationID == 2)
				player.GetComponent<Player> ().TargetLocationID = 1;
		
			player.GetComponent<Player> ().PathColor = 2;
			player.GetComponent<Player> ().DistanceToTarget = MoonDist;

		

		}
		else 
			Debug.Log("Player Not Found");

	}

	public void RedPath() {

		if (player != null) {

			if (player.GetComponent<Player> ().CurrentLocationID == 1)
				player.GetComponent<Player> ().TargetLocationID = 2;

			else if (player.GetComponent<Player> ().CurrentLocationID == 2)
				player.GetComponent<Player> ().TargetLocationID = 1;

			player.GetComponent<Player> ().PathColor = 3;
			player.GetComponent<Player> ().DistanceToTarget = .8 * MoonDist;


		}
		else 
			Debug.Log("Player Not Found");
	}

	public void GreenPath() {

		if (player != null) {

			if (player.GetComponent<Player> ().CurrentLocationID == 1)
				player.GetComponent<Player> ().TargetLocationID = 2;

			else if (player.GetComponent<Player> ().CurrentLocationID == 2)
				player.GetComponent<Player> ().TargetLocationID = 1;

			player.GetComponent<Player> ().PathColor = 1;
			player.GetComponent<Player> ().DistanceToTarget = 1.2 * MoonDist;



		}
		else 
			Debug.Log("Player Not Found");
	}


}
