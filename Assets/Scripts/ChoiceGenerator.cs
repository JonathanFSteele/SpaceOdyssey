using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGenerator : MonoBehaviour {

	private GameObject CurrentPlayer;
	public int CurrentPosition;
	public GameObject MoonChoices;
	public GameObject EarthChoices;
	public GameObject library;
	public GameObject BackGround;
	public GameObject DialogText;


	// Use this for initialization
	void Start () {

		library = GameObject.FindGameObjectWithTag ("Library");
		CurrentPlayer = GameObject.Find("Player");
		CurrentPosition = CurrentPlayer.GetComponent<Player> ().CurrentLocationID;
		Debug.Log("CurrentPosition: " + CurrentPosition);

		if (CurrentPosition == 1) { //Earth
			Debug.Log("You are on the Earth");
			//Probably should display a title as well
			BackGround.GetComponent<SpriteRenderer> ().sprite = library.GetComponent<PlaceLibrary>().GetClipFromName("EarthBack");
			//Need to also change Background
			MoonChoices.SetActive (false);
			EarthChoices.SetActive (true);
			DialogText.GetComponent<UnityEngine.UI.Text> ().text = "This is earth, but I think it should be called Coruscant";


		} else if (CurrentPosition == 2) { //Moon
			Debug.Log("You are on the Moon");
			//Probably should display a title as well\
			BackGround.GetComponent<SpriteRenderer> ().sprite = library.GetComponent<PlaceLibrary>().GetClipFromName("MoonBack");
			//Need to also change Background
			EarthChoices.SetActive (false);
			MoonChoices.SetActive (true);
			DialogText.GetComponent<UnityEngine.UI.Text>().text = "This is the Moon, but there isn't even an amusement park here!!!!!!!";


		}
	}
}
