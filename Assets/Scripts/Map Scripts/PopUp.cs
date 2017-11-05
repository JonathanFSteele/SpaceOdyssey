using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {

	public GameObject distanceText;
	public GameObject timeText;
	public GameObject image;
	public GameObject Library;
	public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}


	public void UpdatePath() {
		
		float timeToTravel = player.GetComponent<Player> ().DistanceToTarget / player.GetComponent<Player> ().playerShip.speed;
		timeText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Time:" + timeToTravel;
		distanceText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Distance:" + player.GetComponent<Player> ().DistanceToTarget.ToString();


		if ( player.GetComponent<Player> ().TargetLocationID == 1)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  Library.GetComponent<PlaceLibrary> ().GetClipFromName ("Earth");
		if ( player.GetComponent<Player> ().TargetLocationID == 2)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  Library.GetComponent<PlaceLibrary> ().GetClipFromName ("Moon");

	}
}
