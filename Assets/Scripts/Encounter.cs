using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour {
	public GameObject player;
	public Ship playerShip;
	public GameObject encounterScripts;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerShip = player.GetComponent<Player>().playerShip;
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
	public int speed;
	public int roll;

	public void Equals(Encounter a, Encounter b){
		a.enemyPicture = b.enemyPicture;
		a.Medical = b.Medical;
		a.Combat = b.Combat;
		a.Charisma = b.Charisma;
		a.prompt = b.prompt;
	}


	public void AttemptPrimary() {
		roll = Random.Range (1, 20);
		Debug.Log ("Our Stats " + (roll + player.GetComponent<Player> ().totalCombat) + " | " + (roll + player.GetComponent<Player> ().totalCharisma) + " | "
			+ (roll + player.GetComponent<Player> ().totalMedical) + " | There Stats: " + this.Combat + " | " + this.Charisma + " | " + this.Medical);
		if (this.encFocus == "Combat") {
			if (roll + player.GetComponent<Player> ().totalCombat > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (4);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (1);
			}
		}

		if (this.encFocus == "Charisma") {
			if (roll + player.GetComponent<Player> ().totalCharisma > this.Charisma) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (5);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (2);
			}

		}
		if (this.encFocus == "Medical") {
			if (roll + player.GetComponent<Player> ().totalMedical > this.Medical) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (6);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (3);
			}
		}


	}


	public void AttemptSecondary() {
		roll = Random.Range (1, 20);
		Debug.Log ("We Roll: " + roll);
		Debug.Log ("Our Stats " + (roll + player.GetComponent<Player> ().totalCombat) + " | " + (roll + player.GetComponent<Player> ().totalCharisma) + " | " 
			+ (roll + player.GetComponent<Player> ().totalMedical) + " | There Stats: " + this.Combat + " | " + this.Charisma + " | " + this.Medical);
		if (this.enc2ndFocus == "Combat") {
			if (roll + player.GetComponent<Player> ().totalCombat > this.Combat) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (4);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (1);
			}
		}
		
		if (this.enc2ndFocus == "Charisma") {
			if (roll + player.GetComponent<Player> ().totalCharisma > this.Charisma) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (5);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (2);
			}
		}

		
		if (this.enc2ndFocus == "Medical") {
			if (roll + player.GetComponent<Player> ().totalMedical > this.Medical) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (6);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (3);
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
		if (this.encFocus == "Combat") {
			Debug.Log ("This.speed: " + this.speed);
			Debug.Log ("This.speed: " + playerShip.speed);
			if (playerShip.speed > this.speed) {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (7);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (1);
				return;
			} else {
				encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (8);
				encounterScripts.GetComponent<EncounterGenerator> ().SetUI (0);
				return;
			}
		}
		encounterScripts.GetComponent<EncounterScene> ().EncounterComplete (7);
		encounterScripts.GetComponent<EncounterGenerator> ().SetUI (2);


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
