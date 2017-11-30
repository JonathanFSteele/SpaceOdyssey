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

	public GameObject CapCom;
	public GameObject CapChar;
	public GameObject CapMed;
	public GameObject CapName;
	public GameObject CapCredits;
	public GameObject TotCombat;
	public GameObject TotMedical;
	public GameObject TotCharisma;

	private GameObject playerObj;
	private Player player;
	private Mission ActivePlayerMission;


	void Start() {
		
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		ActivePlayerMission = player.playerMission;

		CapName.GetComponent<UnityEngine.UI.Text> ().text = "Name: " + player.playerCaptain.captainName;
		CapCredits.GetComponent<UnityEngine.UI.Text> ().text = "€: " + player.credits;
		TotCombat.GetComponent<UnityEngine.UI.Text> ().text = "Total-Combat: " + player.totalCombat;
		TotMedical.GetComponent<UnityEngine.UI.Text> ().text = "Total-Medical: " + player.totalMedical;
		TotCharisma.GetComponent<UnityEngine.UI.Text> ().text = "Total-Charisma: " + player.totalCharisma;
		CapCom.GetComponent<UnityEngine.UI.Text> ().text = "Combat: " + player.playerCaptain.combatBonus.ToString();
		CapChar.GetComponent<UnityEngine.UI.Text> ().text = "Charisma: " + player.playerCaptain.charismaBonus.ToString();
		CapMed.GetComponent<UnityEngine.UI.Text> ().text = "Medical: " + player.playerCaptain.medicalBonus.ToString();

		if (ActivePlayerMission != null){
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "Mission: " + ActivePlayerMission.MissionName;
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "Reward: " + ActivePlayerMission.RewardCredits + " €redits";
			string help = "";
			if (ActivePlayerMission.StartLocationID == 1)
				help += "Start: Earth \n";
			if (ActivePlayerMission.StartLocationID == 2)
				help += "End: Moon \n";

			if (ActivePlayerMission.EndLocationID == 1)
				help += "Start: Earth";
			if (ActivePlayerMission.EndLocationID == 2)
				help += "End: Moon";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = help; 
		}
		else {
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "Mission: no Mission Active";
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "Reward: None";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = "End: None"; 
		}
	}


	public void UpdateUI() {
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		ActivePlayerMission = player.playerMission;

		player.UpdatePlayerStats();

		CapName.GetComponent<UnityEngine.UI.Text> ().text = "Name: " + player.playerCaptain.captainName;
		CapCredits.GetComponent<UnityEngine.UI.Text> ().text = "€: " + player.credits;
		TotCombat.GetComponent<UnityEngine.UI.Text> ().text = "Total-Combat: " + player.totalCombat;
		TotMedical.GetComponent<UnityEngine.UI.Text> ().text = "Total-Medical: " + player.totalMedical;
		TotCharisma.GetComponent<UnityEngine.UI.Text> ().text = "Total-Charisma: " + player.totalCharisma;
		CapCom.GetComponent<UnityEngine.UI.Text> ().text = "Combat: " + player.playerCaptain.combatBonus.ToString();
		CapChar.GetComponent<UnityEngine.UI.Text> ().text = "Charisma: " + player.playerCaptain.charismaBonus.ToString();
		CapMed.GetComponent<UnityEngine.UI.Text> ().text = "Medical" + player.playerCaptain.medicalBonus.ToString();

		if (ActivePlayerMission != null){
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "Mission: " + ActivePlayerMission.MissionName;
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "Reward: " + ActivePlayerMission.RewardCredits + " €";
			string help = "";
			if (ActivePlayerMission.StartLocationID == 1)
				help += "Start: Earth \n";
			if (ActivePlayerMission.StartLocationID == 2)
				help += "End: Moon \n";

			if (ActivePlayerMission.EndLocationID == 1)
				help += "Start: Earth";
			if (ActivePlayerMission.EndLocationID == 2)
				help += "End: Moon";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = help; 
		}else {
			LogMissionName.GetComponent<UnityEngine.UI.Text> ().text = "Mission: no Mission Active";
			LogMissionReward.GetComponent<UnityEngine.UI.Text> ().text = "Reward: None";
			LogStartEnd.GetComponent<UnityEngine.UI.Text> ().text = "End: None"; 
		}
	}

}
