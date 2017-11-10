using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour {

	public GameObject distanceText;
	public GameObject timeText;
	public GameObject image;
	public GameObject Library;
	public GameObject player;
	public GameObject yesButton;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		

	}


	public void UpdatePath() {
		
		float timeToTravel = player.GetComponent<Player> ().DistanceToTarget / player.GetComponentInChildren<Ship> ().speed;
		timeText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Time:" + timeToTravel;
		distanceText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Distance:" + player.GetComponent<Player> ().DistanceToTarget.ToString();


		if ( player.GetComponent<Player> ().TargetLocationID == 1)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  Library.GetComponent<PlaceLibrary> ().GetClipFromName ("Earth");
		if ( player.GetComponent<Player> ().TargetLocationID == 2)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  Library.GetComponent<PlaceLibrary> ().GetClipFromName ("Moon");

	}

	public void TransitToEncounter () {
		SceneManager.LoadScene ("Encounter");
	}
}
