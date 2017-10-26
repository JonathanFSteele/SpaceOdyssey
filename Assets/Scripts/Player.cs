using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int level = 1;
	public int health = 20;
	public int attack = 6;
	public int defense = 4;


	public int credits;
	public int sceneID;
	public int encounterIndex;
	public Captain playerCaptain;
	public Ship playerShip;
	public CrewMember[] playerCrew;
	public Item[] inventory;

	public void Save()
	{
		SaveAndLoadManager.SavePlayer(this);
	}

	public void Load()
	{
		int[] loadedStats = SaveAndLoadManager.LoadPlayer();

		level = loadedStats[0];
		health = loadedStats[1];
		attack = loadedStats[2];
		defense = loadedStats[3];
	}

}