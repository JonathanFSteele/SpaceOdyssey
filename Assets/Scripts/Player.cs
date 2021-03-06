﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Player : MonoBehaviour {


	public int credits;
	public int sceneID;
	public int encounterIndex;
	public PlayersItems playerItems;
	public Captain playerCaptain;
	public Ship playerShip; //ship is an object inside of player now
	public Crew[] playerCrew;
	public Mission playerMission;
//	public Item[] inventory;
	public int CurrentLocationID;  // 1 == earth, 2 == moon
	public int TargetLocationID;  // 1 == earth, 2 == moon
	public int PathColor; // 1 == green, 2 == yellow, 3 == Red
	public float DistanceToTarget;
	public float DistanceTraveled;
	public float TimeToTarget;
	public float TimePassedSinceStart;
	public float TotalDistanceTraveled;
	public bool newGameTF;

	public int totalCombat;
	public int totalCharisma;
	public int totalMedical;

	/// <summary>
	///  needs to be updated at every stat implementation
	/// </summary>
	void Start() {

		totalCombat = playerCaptain.combatBonus;
		totalCharisma = playerCaptain.charismaBonus;
		totalMedical = playerCaptain.medicalBonus;
	}

	public void UpdatePlayerStats() {
		Debug.Log ("Update Player Stats Called");
		totalCombat = playerCaptain.combatBonus + playerShip.combatBonus;
		totalCharisma = playerCaptain.charismaBonus;
		totalMedical = playerCaptain.medicalBonus;
		int i = 0;
		if (playerCrew != null)
		while (i < playerCrew.Length) {
			totalCombat += playerCrew [i].Combat;
			totalCharisma += playerCrew [i].Charisma;
			totalMedical += playerCrew [i].Medicine;
			i++;
		}
		Debug.Log ("Total Combat: " + totalCombat);
		Debug.Log ("Total Charisma: " + totalCharisma);
		Debug.Log ("Total Medical: " + totalMedical);
	}


	public void Save(int Id)
	{
		Debug.Log("Save(" + Id + ")");
		SaveAndLoadManager.SavePlayer(this, Id);
	}

	public void Load(int Id)
	{
		PlayerData loadedStats = SaveAndLoadManager.LoadPlayer(Id);
		if (loadedStats == null) {
			Debug.LogWarning ("There is no data to load from this slot");
			//Do Nothing
		} else {
			credits = loadedStats.credits;
			sceneID = loadedStats.sceneID;
			encounterIndex = loadedStats.encounterIndex;
			playerCaptain = loadedStats.playerCaptain;
			playerShip = loadedStats.playerShip;
			playerCrew = loadedStats.playerCrew;
			playerMission = loadedStats.playerMission;
			//		inventory = player.inventory;
			CurrentLocationID = loadedStats.CurrentLocationID; //1 means earth/ 2 means moon/ etc...
			TargetLocationID = loadedStats.TargetLocationID; //-1 means there is no target yet
			PathColor = loadedStats.PathColor; //-1 means there is no path chosen 1 == green, 2 == yellow, 3 == Red
			DistanceToTarget = loadedStats.DistanceToTarget;
			DistanceTraveled = loadedStats.DistanceTraveled;
			TimeToTarget = loadedStats.TimeToTarget;
			TimePassedSinceStart = loadedStats.TimePassedSinceStart;
			TotalDistanceTraveled = loadedStats.TotalDistanceTraveled;
			newGameTF = loadedStats.newGameTF;

			Debug.Log("CurrentPlayerData--( credits: " + credits + " | sceneID: " + sceneID + "" +
				" | encounterIndex: " + encounterIndex + " | playerCaptain: " + playerCaptain + ")");
		}
	}

}