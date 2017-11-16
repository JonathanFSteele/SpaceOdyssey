using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour {

	public GameObject library;
	public GameObject player;
	public GameObject promptBox;
	public GameObject EncounterImage;
	public GameObject EncounterText;
	public GameObject CombatCanvas;
	public GameObject CharismaCanvas;
	public GameObject MedicalCanvas;



	public int RanNum;


	void Start() {
		library = GameObject.FindGameObjectWithTag("Library");
		//player = GameObject.FindGameObjectWithTag("Player");
	}

	public Encounter GenerateEncounter( int path, Encounter NewEnc ){


		RanNum = (int)Random.Range (0, 100);
		NewEnc.enemyPicture = library.GetComponent<ShipLibrary> ().GetRandomClipFromName ("Enemy"); 
		//Debug.Log ("Rng is" + RanNum);

		if (path == 1) {
			if (RanNum <= 10) {
				return CombatRoll( NewEnc);
			}
			if (RanNum > 10 && RanNum <= 20) {
				return CharismaRoll( NewEnc);
			}
			if (RanNum > 20 && RanNum <= 30) {
				return  MedicalRoll( NewEnc);
			}
		}

		if (path == 2) {
			if (RanNum <= 15) {
				return CombatRoll( NewEnc);
			}
			if (RanNum > 15 && RanNum <= 30) {
				return CharismaRoll( NewEnc);
			}
			if (RanNum > 30 && RanNum <= 45) {
				return  MedicalRoll( NewEnc);
			}
		}

		if (path == 3 ) {
			if (RanNum < 20) {
				return CombatRoll( NewEnc);
			}
			if (RanNum > 20 && RanNum <= 40) {
				return CharismaRoll( NewEnc);
			}
			if (RanNum >= 40 && RanNum <= 60) {
				return  MedicalRoll( NewEnc);
			}
		}
		SetUI ();
		return null;
	}


	public Encounter CombatRoll(Encounter NewEnc){
		NewEnc.encFocus = "Combat";
		NewEnc.Combat = Random.Range(5,10);
		NewEnc.enc2ndFocus = "Charisma";
		NewEnc.Charisma = Random.Range(3,10);
		NewEnc.prompt = "Enemy ship wants to fight us, What are we going to do?" ;
		SetUI (NewEnc);
		return NewEnc;
	}

	public Encounter CharismaRoll(Encounter NewEnc){
		NewEnc.encFocus = "Charisma";
		NewEnc.Charisma = Random.Range(5,10);
		NewEnc.enc2ndFocus = "Combat";
		NewEnc.Combat = Random.Range(3,10);
		NewEnc.prompt = "Enemy ship wants to Talk to us, What are we going to do?";
		SetUI (NewEnc);
		return NewEnc;
	}

	public Encounter MedicalRoll(Encounter NewEnc){
		NewEnc.encFocus = "Medical";
		NewEnc.Medical = Random.Range(5,10);
		NewEnc.enc2ndFocus = "Charisma";
		NewEnc.Combat = Random.Range(3,10);
		NewEnc.prompt = "Enemy ship wants us to give them aid, What are we going to do?";
		SetUI (NewEnc);
		return NewEnc;
	}

	public void SetUI(Encounter NewEnc) {

		promptBox.GetComponent<UnityEngine.UI.Text> ().text = NewEnc.prompt;
		EncounterImage.GetComponent<UnityEngine.UI.Image> ().sprite = NewEnc.enemyPicture;
		if (NewEnc.encFocus == "Combat") {
			CombatCanvas.gameObject.SetActive (true);
		}
		if (NewEnc.encFocus == "Charisma") {
			CharismaCanvas.gameObject.SetActive (true);
		}
		if (NewEnc.encFocus == "Medical") {
			MedicalCanvas.gameObject.SetActive (true);
		}

		EncounterText.GetComponent<UnityEngine.UI.Text> ().text = "Stats : Combat:" + NewEnc.Combat + " Charisma:" + NewEnc.Charisma + " Medical:" + NewEnc.Medical;


	}

	public void SetUI() {

		CombatCanvas.gameObject.SetActive (false);
		CharismaCanvas.gameObject.SetActive (false);
		MedicalCanvas.gameObject.SetActive (false);
		promptBox.GetComponent<UnityEngine.UI.Text> ().text = "Smooth Sailing so far...";
		EncounterText.GetComponent<UnityEngine.UI.Text> ().text = "";
		EncounterImage.GetComponent<UnityEngine.UI.Image> ().sprite = library.GetComponent<ShipLibrary>().GetClipFromName("Nada");




	}


	public void SetUI( int a) {

		CombatCanvas.gameObject.SetActive (false);
		CharismaCanvas.gameObject.SetActive (false);
		MedicalCanvas.gameObject.SetActive (false);
		EncounterText.GetComponent<UnityEngine.UI.Text> ().text = "";
		EncounterImage.GetComponent<UnityEngine.UI.Image> ().sprite = library.GetComponent<ShipLibrary>().GetClipFromName("Nada");


		if (a == 1) {
			promptBox.GetComponent<UnityEngine.UI.Text> ().text = "That was close! We should be more careful.";

		}


		if (a == 0) {
			promptBox.GetComponent<UnityEngine.UI.Text> ().text = "We got out of there alive, but we need to be better prepared for next time.";


		}

	}
}
