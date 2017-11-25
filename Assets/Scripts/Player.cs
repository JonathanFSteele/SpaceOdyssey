using System.Collections;
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
	public Captain playerCaptain;
//	public Ship playerShip; //ship is an object inside of player now
//	public CrewMember[] playerCrew;
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
			//		playerShip = player.playerShip;
			//		playerCrew = player.playerCrew;
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