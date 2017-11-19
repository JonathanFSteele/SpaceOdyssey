using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoadManager {

	//Saving Functionality
	public static void SavePlayer(Player player, int saveSlot){
		Debug.Log("Saving Player Data");
		BinaryFormatter bf = new BinaryFormatter();

		if (saveSlot == 0) {

			FileStream stream = new FileStream (Application.persistentDataPath + "/player0.sav", FileMode.Create);

			PlayerData data = new PlayerData (player);

			bf.Serialize (stream, data);
			stream.Close ();
		} else if(saveSlot == 1) {

			FileStream stream = new FileStream (Application.persistentDataPath + "/player1.sav", FileMode.Create);

			PlayerData data = new PlayerData (player);

			bf.Serialize (stream, data);
			stream.Close ();
		} else if(saveSlot == 2) {

			FileStream stream = new FileStream (Application.persistentDataPath + "/player2.sav", FileMode.Create);

			PlayerData data = new PlayerData (player);

			bf.Serialize (stream, data);
			stream.Close ();
		} else if(saveSlot == 3) {

			FileStream stream = new FileStream (Application.persistentDataPath + "/player3.sav", FileMode.Create);

			PlayerData data = new PlayerData (player);

			bf.Serialize (stream, data);
			stream.Close ();
		}
	}

//	public void DeleteFile(int value) 
//	{
//		string guiMessage = "type in a file name and hit save";
//		string filePath = Application.dataPath + "/player"+ value +".sav";
//
//		// check if file exists
//		if ( !File.Exists( filePath ) )
//		{
//			guiMessage = "no /player" + + " file exists"; //Debug.Log( "no " + fileName + " file exists" );
//		}
//		else
//		{
//			guiMessage = " /player" + value + " file exists, deleting..."; //Debug.Log( fileName + " file exists, deleting..." );
//
//			File.Delete( filePath );
//
//			//RefreshEditorProjectWindow();
//		}
//	}

	public static PlayerData LoadPlayer(int loadSlot) {
		if (loadSlot == 0) {
			if (File.Exists (Application.persistentDataPath + "/player0.sav")) {
				Debug.Log ("Loading Player Data");
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (Application.persistentDataPath + "/player0.sav", FileMode.Open);

				PlayerData data = bf.Deserialize (stream) as PlayerData;

				stream.Close ();
				//return data.stats;
				return data;
			} else {
				Debug.LogError ("File Does not Exist");

				return new PlayerData ();
			}
		} else if(loadSlot == 1) {
			if (File.Exists (Application.persistentDataPath + "/player1.sav")) {
				Debug.Log ("Loading Player Data");
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (Application.persistentDataPath + "/player1.sav", FileMode.Open);

				PlayerData data = bf.Deserialize (stream) as PlayerData;

				stream.Close ();
				//return data.stats;
				return data;
			} else {
				Debug.LogError ("File Does not Exist");

				return new PlayerData ();
			}
		} else if(loadSlot == 2) {
			if (File.Exists (Application.persistentDataPath + "/player2.sav")) {
				Debug.Log ("Loading Player Data");
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (Application.persistentDataPath + "/player2.sav", FileMode.Open);

				PlayerData data = bf.Deserialize (stream) as PlayerData;

				stream.Close ();
				//return data.stats;
				return data;
			} else {
				Debug.LogError ("File Does not Exist");

				return new PlayerData ();
			}
		} else {
			if (File.Exists (Application.persistentDataPath + "/player3.sav")) {
				Debug.Log ("Loading Player Data");
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (Application.persistentDataPath + "/player3.sav", FileMode.Open);

				PlayerData data = bf.Deserialize (stream) as PlayerData;

				stream.Close ();
				//return data.stats;
				return data;
			} else {
				Debug.LogError ("File Does not Exist");

				return new PlayerData ();
			}
		}
	}
}


[Serializable]
public class PlayerData {

	public int credits;
	public int sceneID;
	public int encounterIndex;
	public Captain playerCaptain;
//	public Ship playerShip;
//	public CrewMember[] playerCrew;
//	public Item[] inventory;

	public PlayerData() {
		credits = 0;
		sceneID = 0;
		encounterIndex = -1;
		playerCaptain = null;
//		playerShip = null;
//		playerCrew = null;
//		inventory = null;
	}


	public PlayerData(Player player)
	{
		credits = player.credits;
		sceneID = player.sceneID;
		encounterIndex = player.encounterIndex;
		playerCaptain = player.playerCaptain;
//		playerShip = player.playerShip;
//		playerCrew = player.playerCrew;
//		inventory = player.inventory;
	}

}
