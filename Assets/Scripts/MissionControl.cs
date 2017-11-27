using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionControl : MonoBehaviour {

	public GameObject M1Name;
	public GameObject M1Reward;
	public GameObject M1Start;
	public GameObject M1End;
	public GameObject M1Description;

	public GameObject M2Name;
	public GameObject M2Reward;
	public GameObject M2Start;
	public GameObject M2End;
	public GameObject M2Description;

	public GameObject M3Name;
	public GameObject M3Reward;
	public GameObject M3Start;
	public GameObject M3End;
	public GameObject M3Description;

	public Mission mission1;
	public Mission mission2;
	public Mission mission3;

	//player
	public GameObject playerObj;
	private Player player;


	void Start() {
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();

		Mission mission10 = new Mission ();

		mission10.MissionName = "One Day Honey, TO THE MOON!";
		mission10.Description = "Deliver this sugar to my grandma on the Moon";
		mission10.StartLocationID = 1;
		mission10.EndLocationID = 2;
		mission10.StartLocationReached = false;
		mission10.EndLocationReached = false;
		mission10.RewardCredits = 10000;

		mission1 = mission10;

		mission2 = null;

		mission3 = null;

		UpdateUI ();
	}


	public void UpdateUI(){
		// mission 1 stuff
		if (mission1 != null) {
			M1Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: " + mission1.MissionName;
			M1Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward : " + mission1.RewardCredits + " credits";

			if (mission1.StartLocationID == 1) {
				M1Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Earth";
			} else if (mission1.StartLocationID == 2) {
				M1Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Moon";
			} else {
				M1Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: The Void";
			}

			if (mission1.EndLocationID == 1) {
				M1End.GetComponent<UnityEngine.UI.Text> ().text = "End: Earth";
			} else if (mission1.EndLocationID == 2) {
				M1End.GetComponent<UnityEngine.UI.Text> ().text = "End: Moon";
			} else {
				M1End.GetComponent<UnityEngine.UI.Text> ().text = "End: The Void";
			}
				
			M1Description.GetComponent<UnityEngine.UI.Text> ().text = mission1.Description;
		} else {
			M1Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: This mission has been taken \"";
			M1Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward :";
			M1Start.GetComponent<UnityEngine.UI.Text> ().text = "Start:";
			M1End.GetComponent<UnityEngine.UI.Text> ().text = "End:";
			M1Description.GetComponent<UnityEngine.UI.Text> ().text = "";
		}
		//mission 2 stuff
		if (mission2 != null) {
			M2Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: " + mission2.MissionName;
			M2Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward : " + mission2.RewardCredits + " credits";

			if (mission2.StartLocationID == 1) {
				M2Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Earth";
			} else if (mission2.StartLocationID == 2) {
				M2Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Moon";
			} else {
				M2Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: The Void";
			}

			if (mission2.EndLocationID == 1) {
				M2End.GetComponent<UnityEngine.UI.Text> ().text = "End: Earth";
			} else if (mission2.EndLocationID == 2) {
				M2End.GetComponent<UnityEngine.UI.Text> ().text = "End: Moon";
			} else {
				M2End.GetComponent<UnityEngine.UI.Text> ().text = "End: The Void";
			}

			M2Description.GetComponent<UnityEngine.UI.Text> ().text = mission2.Description;
		}
		else {
			M2Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: This mission has been taken ";
			M2Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward :";
			M2Start.GetComponent<UnityEngine.UI.Text> ().text = "Start:";
			M2End.GetComponent<UnityEngine.UI.Text> ().text = "End:";
			M2Description.GetComponent<UnityEngine.UI.Text> ().text = "";
		}
		//mission 3 stuff
		if (mission3 != null) {
			M3Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: " + mission3.MissionName;
			M3Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward : " + mission3.RewardCredits + " credits";

			if (mission3.StartLocationID == 1) {
				M3Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Earth";
			} else if (mission3.StartLocationID == 2) {
				M3Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: Moon";
			} else {
				M3Start.GetComponent<UnityEngine.UI.Text> ().text = "Start: The Void";
			}

			if (mission3.EndLocationID == 1) {
				M3End.GetComponent<UnityEngine.UI.Text> ().text = "End: Earth";
			} else if (mission3.EndLocationID == 2) {
				M3End.GetComponent<UnityEngine.UI.Text> ().text = "End: Moon";
			} else {
				M3End.GetComponent<UnityEngine.UI.Text> ().text = "End: The Void";
			}

			M3Description.GetComponent<UnityEngine.UI.Text> ().text = mission3.Description;
		}
		else {
			M3Name.GetComponent<UnityEngine.UI.Text> ().text = "Name: This mission has been taken ";
			M3Reward.GetComponent<UnityEngine.UI.Text> ().text = "Reward :";
			M3Start.GetComponent<UnityEngine.UI.Text> ().text = "Start:";
			M3End.GetComponent<UnityEngine.UI.Text> ().text = "End:";
			M3Description.GetComponent<UnityEngine.UI.Text> ().text = "";
		}

	}

	public void GetMission1(){
		if (mission1 != null) {
			player.playerMission = mission1;
			mission1 = null;
			UpdateUI ();
		}


	}

	public void GetMission2(){
		if (mission2 != null) {
			player.playerMission = mission2;
			mission2 = null;
			UpdateUI ();
		}


	}

	public void GetMission3(){
		if (mission3 != null) {
			player.playerMission = mission3;
			mission3 = null;
			UpdateUI ();
		}

	}

}
