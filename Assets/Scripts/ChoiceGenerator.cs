using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGenerator : MonoBehaviour {

	private GameObject CurrentPlayer;
	public int CurrentPosition;

	// Use this for initialization
	void Start () {
		CurrentPlayer = GameObject.Find("Player");
		CurrentPosition = CurrentPlayer.GetComponent<Player> ().CurrentLocationID;
		Debug.Log("CurrentPosition: " + CurrentPosition);

		if (CurrentPosition == 1) { //Earth
			Debug.Log("You are on the Earth");



		} else if (CurrentPosition == 2) { //Moon
			Debug.Log("You are on the Moon");



		}
	}
}
