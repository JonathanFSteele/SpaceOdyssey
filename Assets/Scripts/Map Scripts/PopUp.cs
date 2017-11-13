using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour {

	public GameObject distanceText;
	public GameObject timeText;
	public GameObject image;
	public GameObject library;
	public GameObject player;


	// Use this for initialization
	public void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	    library = GameObject.FindGameObjectWithTag ("Library");
		player = GameObject.Find ("Player");
		library = GameObject.Find ("Library");
	}
	
	// Update is called once per frame
	void Update () {


	}

	/// <summary>
	/// Get this to work with earth!!!!!!!!!!!!!!!
	/// </summary>
	public void UpdatePath() {

		player = GameObject.FindGameObjectWithTag ("Player");
		library = GameObject.FindGameObjectWithTag ("Library");
		
		float timeToTravel = player.GetComponent<Player> ().DistanceToTarget / player.GetComponentInChildren<Ship> ().speed;
		timeText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Time:" + timeToTravel;
		distanceText.GetComponent<UnityEngine.UI.Text> ().text = "Estimated Distance:" + player.GetComponent<Player> ().DistanceToTarget.ToString();


		if ( player.GetComponent<Player> ().TargetLocationID == 1)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  library.GetComponent<PlaceLibrary> ().GetClipFromName ("Earth");
		
		if ( player.GetComponent<Player> ().TargetLocationID == 2)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  library.GetComponent<PlaceLibrary> ().GetClipFromName ("Moon");

	}



	public void TransitToEncounter () {
		SceneManager.LoadScene ("Encounter");
	}
}
