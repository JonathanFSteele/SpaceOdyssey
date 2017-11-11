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

	void Start()
	{
		Debug.Log ("Start Called");
		PlayerData player1 = SaveAndLoadManager.LoadPlayer (0);
		PlayerData player2 = SaveAndLoadManager.LoadPlayer (1);
		PlayerData player3 = SaveAndLoadManager.LoadPlayer (2);
		PlayerData player4 = SaveAndLoadManager.LoadPlayer (3);

		GameObject SaveSlot1 = GameObject.FindGameObjectWithTag("SaveSlot1");
		GameObject SaveSlot2 = GameObject.FindGameObjectWithTag("SaveSlot2");
		GameObject SaveSlot3 = GameObject.FindGameObjectWithTag("SaveSlot3");
		GameObject SaveSlot4 = GameObject.FindGameObjectWithTag("SaveSlot4");

		SaveSlot1.GetComponent<UnityEngine.UI.Text>().text = player1.playerCaptain.captainName;
		SaveSlot2.GetComponent<UnityEngine.UI.Text>().text = player2.playerCaptain.captainName;
		SaveSlot3.GetComponent<UnityEngine.UI.Text>().text = player3.playerCaptain.captainName;
		SaveSlot4.GetComponent<UnityEngine.UI.Text>().text = player4.playerCaptain.captainName;

		GameObject LoadSlot1 = GameObject.FindGameObjectWithTag("LoadSlot1");
		GameObject LoadSlot2 = GameObject.FindGameObjectWithTag("LoadSlot2");
		GameObject LoadSlot3 = GameObject.FindGameObjectWithTag("LoadSlot3");
		GameObject LoadSlot4 = GameObject.FindGameObjectWithTag("LoadSlot4");

		LoadSlot1.GetComponent<UnityEngine.UI.Text>().text = player1.playerCaptain.captainName;
		LoadSlot2.GetComponent<UnityEngine.UI.Text>().text = player2.playerCaptain.captainName;
		LoadSlot3.GetComponent<UnityEngine.UI.Text>().text = player3.playerCaptain.captainName;
		LoadSlot4.GetComponent<UnityEngine.UI.Text>().text = player4.playerCaptain.captainName;
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