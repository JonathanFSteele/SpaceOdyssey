using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour {

	public GameObject library;
	public GameObject player;
	public GameObject promptBox;

	public int RanNum;


	void Start() {
		library = GameObject.FindGameObjectWithTag("Library");
		//player = GameObject.FindGameObjectWithTag("Player");
	}

	public Encounter GenerateEncounter( int path){

		 Encounter NewEnc = new Encounter();

		RanNum = (int)Random.Range (0, 100);
		NewEnc.enemyPicture = library.GetComponent<ShipLibrary> ().GetRandomClipFromName ("enemy"); 


		if (path == 1) {
			if (RanNum < 25) {
				
				return CombatRoll();
			}
			if (RanNum > 25 && RanNum < 30) {
				return CharismaRoll();
			}
			if (RanNum > 30 && RanNum < 35) {
				return  MedicalRoll();
			}
		}

		if (path == 2) {
			NewEnc.Combat = 10;
			return NewEnc;
		}

		if (path == 3 ) {
			NewEnc.Combat = 10;
			return NewEnc;
		}
	
		return null;
	}


	public Encounter CombatRoll(){
		Encounter NewEnc = new Encounter();
		NewEnc.Combat = 5;
		NewEnc.prompt = "Enemy ship wants to fight us, What are we going to do?" ;
		return NewEnc;
	}

	public Encounter CharismaRoll(){
		Encounter NewEnc = new Encounter();
		NewEnc.Charisma = 5;
		NewEnc.prompt = "Enemy ship wants to Talk to us, What are we going to do?";
		return NewEnc;
	}

	public Encounter MedicalRoll(){
		Encounter NewEnc = new Encounter();
		NewEnc.Medical = 5;
		NewEnc.prompt = "Enemy ship wants us to give them aid, What are we going to do?";
		return NewEnc;
	}
}
