using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int credits;
	public int sceneID;
	public int encounterIndex;
	public Captain playerCaptain;
//	public Ship playerShip;
//	public CrewMember[] playerCrew;
//	public Item[] inventory;

	public void Save()
	{
		SaveAndLoadManager.SavePlayer(this);
	}

	public void Load()
	{
		PlayerData loadedStats = SaveAndLoadManager.LoadPlayer();
		credits = loadedStats.credits;
		sceneID = loadedStats.sceneID;
		encounterIndex = loadedStats.encounterIndex;
		playerCaptain = loadedStats.playerCaptain;
	}

}