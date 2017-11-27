using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Log : MonoBehaviour {
	
    //Varibles that change the output text on screen
//    public Sprite CaptainImage;
//    public String CaptainName;
//    public String Description;
//    public int Combat;
//    public int Mechanics;
//    public int Medicine;
//    public int Charisma;

	public GameObject LogMissionName;
	public GameObject LogMissionReward;
	public GameObject LogStartEnd;

	private GameObject playerObj;
	private Player player;
	private Mission ActivePlayerMission;


	void Start() {
		
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		ActivePlayerMission = player.playerMission;

		if (ActivePlayerMission != null){
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = ActivePlayerMission.MissionName;
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = ActivePlayerMission.RewardCredits + " credits";
			string help = "";
			if (ActivePlayerMission.StartLocationID == 1)
				help += "Earth \n";
			if (ActivePlayerMission.StartLocationID == 2)
				help += "Moon \n";

			if (ActivePlayerMission.EndLocationID == 1)
				help += "Earth";
			if (ActivePlayerMission.EndLocationID == 2)
				help += "Moon";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = help; 
		}
		else {
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "no Mission Active";
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = ""; 
		}
	}


	public void UpdateUI() {
		

		if (ActivePlayerMission != null){
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = ActivePlayerMission.MissionName;
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = ActivePlayerMission.RewardCredits + " credits";
			string help = "";
			if (ActivePlayerMission.StartLocationID == 1)
				help += "Earth \n";
			if (ActivePlayerMission.StartLocationID == 2)
				help += "Moon \n";

			if (ActivePlayerMission.EndLocationID == 1)
				help += "Earth";
			if (ActivePlayerMission.EndLocationID == 2)
				help += "Moon";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = help; 
		}else {
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "no Mission Active";
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = ""; 
		}
	}

}
