using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitMapMove : MonoBehaviour {

	public int numStops = 0;

	bool isStopped = false;
	public GameObject ContinueBut;

	// Use this for initialization
	void Start () {
		isStopped = false;
	}

	// Update is called once per frame
	void Update () {

		while (!isStopped) {
			transform.position += transform.right;
			checkStop (numStops, transform.position.x);
		}
			
		if (isStopped) {
			ContinueBut.SetActive (true);
		}
			
	}

	void Go() {
		ContinueBut.SetActive (false);
		isStopped = false;
	}

	void checkStop( int stops, float xPos  ) {

		if (numStops == 3) {
			if ( xPos == -175 ||  xPos == 0 || xPos == 175 ){
				isStopped = true;
			}
		}

		if (numStops == 4) {
			if ( xPos == -175 ||  xPos == -75 || xPos == 75 || xPos == 175 ){
				isStopped = true;
			}
		}
			
		if (numStops == 5) {
			if ( xPos == -230 ||  xPos == -115 || xPos == 0 || xPos == 115 || xPos == 230){
				isStopped = true;
			}
		}

		return;
			
	}
}
