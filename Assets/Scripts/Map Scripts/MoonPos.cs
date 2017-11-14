using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPos : MonoBehaviour {

	public Vector2[] MoonPosition;
	public int moonStart;
	int moonCont;
	GameObject target;
	GameObject player;
	public float MoonDist = 1000f;


	// Use this for initialization
	void Start () {
		moonCont = moonStart;
		transform.localPosition = MoonPosition [moonStart];
		player = GameObject.Find("Player") ;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = MoonPosition [moonCont];
	}

	public void MoonMove( int moonPos) {
		transform.localPosition = MoonPosition [moonPos];
	}

	public void NextMoonPos() {
		moonCont = ++moonCont % 8;
		transform.localPosition = MoonPosition [ (moonCont)];
	}

	public int GetMoonPos() {
		return moonCont;
	}
		

	public void PathChooseMoon() {
		player.GetComponent<Player> ().TargetLocationID = 2;

		if (player.GetComponent<Player> ().CurrentLocationID == 2) 
			player.GetComponent<Player> ().TargetLocationID =-1;

		int CurrentPath = -1;
			CurrentPath = GetMoonPos();
	
		 if (CurrentPath == 0 || CurrentPath == 4)
			GreenPath ();
		else if (CurrentPath == 1 || CurrentPath == 3 || CurrentPath == 5 || CurrentPath == 7)
			YellowPath ();
		else if (CurrentPath == 2 || CurrentPath == 6)
			RedPath ();
	}


	public void PathChooseEarth() {


		player.GetComponent<Player> ().TargetLocationID = 1;

		if (player.GetComponent<Player> ().CurrentLocationID == 1) 
			player.GetComponent<Player> ().TargetLocationID =-1;
		
		int CurrentPath = -1;
		CurrentPath = GetMoonPos();

		if (CurrentPath == 0 || CurrentPath == 4)
			GreenPath ();
		else if (CurrentPath == 1 || CurrentPath == 3 || CurrentPath == 5 || CurrentPath == 7)
			YellowPath ();
		else if (CurrentPath == 2 || CurrentPath == 6)
			RedPath ();
	}

	 void YellowPath() {
		if (player != null) {

		

			player.GetComponent<Player> ().PathColor = 2;
			player.GetComponent<Player> ().DistanceToTarget = MoonDist;



		}
		else 
			Debug.Log("Player Not Found");

	}

	 void RedPath() {

		if (player != null) {

		

			player.GetComponent<Player> ().PathColor = 3;
			player.GetComponent<Player> ().DistanceToTarget = .8f * MoonDist;


		}
		else 
			Debug.Log("Player Not Found");
	}

	 void GreenPath() {

		if (player != null) {


			player.GetComponent<Player> ().PathColor = 1;
			player.GetComponent<Player> ().DistanceToTarget = 1.2f * MoonDist;



		}
		else 
			Debug.Log("Player Not Found");
	}
}
