using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoadManager {

	//Saving Functionality
	public static void SavePlayer(Player player){
		Debug.Log("Saving Player Data");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

		PlayerData data = new PlayerData (player);

		bf.Serialize(stream, data);
		stream.Close();

	}

	public static PlayerData LoadPlayer() {
		if (File.Exists (Application.persistentDataPath + "/player.sav")) {
			Debug.Log("Loading Player Data");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
			//return data.stats;
			return data;
		} else {
			Debug.LogError("File Does not Exist");

			return new PlayerData();
		}
	}
}


[Serializable]
public class PlayerData {

	//public int[] stats;
	public int credits;
	public int sceneID;
	public int encounterIndex;
//	public Captain playerCaptain;
//	public Ship playerShip;
//	public CrewMember[] playerCrew;
//	public Item[] inventory;

	public PlayerData() {
		credits = 0;
		sceneID = 0;
		encounterIndex = -1;
//		playerCaptain = null;
//		playerShip = null;
//		playerCrew = null;
//		inventory = null;
	}


	public PlayerData(Player player)
	{
		credits = player.credits;
		sceneID = player.sceneID;
		encounterIndex = player.encounterIndex;
//		playerCaptain = player.playerCaptain;
//		playerShip = player.playerShip;
//		playerCrew = player.playerCrew;
//		inventory = player.inventory;


//		stats = new int[4];
//		stats [0] = player.level;
//		stats [1] = player.health;
//		stats [2] = player.attack;
//		stats [3] = player.defense;
	}

}
