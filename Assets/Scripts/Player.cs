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
		credits = loadedStats.credits;
		sceneID = loadedStats.sceneID;
		encounterIndex = loadedStats.encounterIndex;
		playerCaptain = loadedStats.playerCaptain;
	}

}