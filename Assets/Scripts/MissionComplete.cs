using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionComplete : MonoBehaviour {

	public GameObject MissionAccomplishedCanvas;
	public GameObject Reward;
	private GameObject playerObj;
	private Player player;
	private Mission playerMission;
	public AudioSource AchievementSound;
	// Update is called once per frame

	void Start () {
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerMission = player.playerMission;
	}

	void Update () {
		
		CheckPosition ();

	}

	void CheckPosition() {


		if (playerMission != null){
			player = playerObj.GetComponent<Player> ();
			playerMission = player.playerMission;
			if (player.CurrentLocationID == playerMission.StartLocationID) {
				playerMission.StartLocationReached = true;
				//Debug.Log ("Ding!!!!!!!!");
			}
			if (playerMission.StartLocationReached && (player.CurrentLocationID == playerMission.EndLocationID)) {
				MissionIsComplete ();
				//Debug.Log ("Ding!!!!!!!! Ding!!!!!!!!!!!!!!!!!!!!");
			}
		}

	}
		
	void MissionIsComplete() {
		AchievementSound.Play();
		MissionAccomplishedCanvas.SetActive (true);
		Reward.GetComponent<UnityEngine.UI.Text> ().text = playerMission.RewardCredits + " credits!!!!";
		player.credits += playerMission.RewardCredits;
		player.playerMission = new Mission();
			playerMission.MissionName = "None";
			playerMission.Description = "None";
			playerMission.RewardCredits = 0;
			playerMission.StartLocationID = -1;
			playerMission.StartLocationReached = false;
			playerMission.EndLocationID = -1;
			playerMission.EndLocationReached = false;
	}
}
