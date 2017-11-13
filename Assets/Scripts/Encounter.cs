﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour {
	public GameObject player;
	public GameObject encounterScripts;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			//player = player.GetComponent<Player> ();
		}
		encounterScripts = GameObject.FindGameObjectWithTag("EncounterScripts");
	}



	public string encFocus = "";
	public string enc2ndFocus = "";
	public Sprite enemyPicture;
	public int Medical;
	public int Combat;
	public int Charisma;
	public string prompt;
	public int roll;

	public void Equals(Encounter a, Encounter b){
		a.enemyPicture = b.enemyPicture;
		a.Medical = b.Medical;
		a.Combat = b.Combat;
		a.Charisma = b.Charisma;
		a.prompt = b.prompt;
	}


	public void AttemptPrimary() {
		roll = Random.Range (0, 20);
		if (this.encFocus == "Combat") {
			if (roll + player.GetComponent<Player> ().playerCaptain.combatBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI ();
				return;
			} else {

			}
		}
		if (this.encFocus == "Charisma") {
			if (roll + player.GetComponent<Player> ().playerCaptain.charsmaBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI ();
				return;
			} else {

			}

		}
		if (this.encFocus == "Medical") {
			if (roll + player.GetComponent<Player> ().playerCaptain.medBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				return;
			} else {

			}

		}
	}


	public void AttemptSecondary() {
		roll = Random.Range (0, 20);
		if (this.enc2ndFocus == "Combat") {
			if (roll + player.GetComponent<Player> ().playerCaptain.combatBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI ();
				return;
			} else {

			}
		}
		if (this.enc2ndFocus == "Charisma") {
			if (roll + player.GetComponent<Player> ().playerCaptain.charsmaBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI ();
				return;
			} else {

			}

		}
		if (this.enc2ndFocus == "Medical") {
			if (roll + player.GetComponent<Player> ().playerCaptain.medBonus > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete ();
				return;
			} else {

			}

		}
	}





//	public void Run(){
//		roll = Random.Range (0, 20);
//		if (player != null) {
//
//		}
//	}

	public void Ignore(){
		roll = Random.Range (0, 20);
		if (player != null) {

		}
	}

//	public void Help(){
//		roll = Random.Range (0, 20);
//		if (player != null) {
//
//		}
//	}

//	public void Talk(){
//		roll = Random.Range (0, 20);
//		if (player != null) {
//
//		}
//	}
}
