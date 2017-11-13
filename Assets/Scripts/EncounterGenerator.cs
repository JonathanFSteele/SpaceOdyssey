using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour {

	public GameObject library;
	public GameObject player;
	public GameObject promptBox;
	public GameObject EncounterImage;

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
			if (RanNum < 25) {
				return CombatRoll( NewEnc);
			}
			if (RanNum > 25 && RanNum < 30) {
				return CharismaRoll( NewEnc);
			}
			if (RanNum > 30 && RanNum < 35) {
				return  MedicalRoll( NewEnc);
			}
		}

		if (path == 2) {
			return CombatRoll(NewEnc);
		}

		if (path == 3 ) {
			return CombatRoll(NewEnc);
		}
		SetUI ();
		return null;
	}


	public Encounter CombatRoll(Encounter NewEnc){
		NewEnc.Combat = 5;
		NewEnc.prompt = "Enemy ship wants to fight us, What are we going to do?" ;
		SetUI (NewEnc);
		return NewEnc;
	}

	public Encounter CharismaRoll(Encounter NewEnc){
		NewEnc.Charisma = 5;
		NewEnc.prompt = "Enemy ship wants to Talk to us, What are we going to do?";
		SetUI (NewEnc);
		return NewEnc;
	}

	public Encounter MedicalRoll(Encounter NewEnc){
		NewEnc.Medical = 5;
		NewEnc.prompt = "Enemy ship wants us to give them aid, What are we going to do?";
		SetUI (NewEnc);
		return NewEnc;
	}

	public void SetUI(Encounter NewEnc) {

		promptBox.GetComponent<UnityEngine.UI.Text> ().text = NewEnc.prompt;
		EncounterImage.GetComponent<UnityEngine.UI.Image> ().sprite = NewEnc.enemyPicture;


	}

	public void SetUI() {

		promptBox.GetComponent<UnityEngine.UI.Text> ().text = "Smooth Sailing so far...";
		EncounterImage.GetComponent<UnityEngine.UI.Image> ().sprite = library.GetComponent<ShipLibrary>().GetClipFromName("Nada");


	}
}
