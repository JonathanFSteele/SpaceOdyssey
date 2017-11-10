using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour {

	private double MaxDistance = 239900.0; // In miles
	private double AvgTime = 3.5; // In Earth Days
	private double ShipSpeed = 60000.0; //Miles per day
	private double CurrentDistance = 0.0;
	private double TimeTaken = 0.0;
	private bool EncounterTF = false;
	private bool TravelFinishedTF = false;
	public float distancePerSecond = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine(Travel());
	}
		
	IEnumerator Travel()
	{
		while (TravelFinishedTF == false) {
			yield return new WaitForSeconds(2);
			if (EncounterTF == false) {
				if (CurrentDistance < MaxDistance) {
					CurrentDistance += ShipSpeed;
					TimeTaken += 1;
					//Call Encounter Generator Function -- Return EncounterTF == true or false
					Debug.Log ("Traveled " + CurrentDistance + " Miles In " + TimeTaken + " Earth Days");
				} else {
					TravelFinishedTF = true;
					Debug.Log ("Made it to destination in " + TimeTaken + " Earth Days");
				}
			} else {
				//Debug.Log ("Encounter Encountered, Waiting for Results ");
			}
		}
		Debug.Log("Travel Finished Jump back to Safezone Page, with new Destination");
		//Change Scenes with new Destination for Safe Zone...
	}
}
