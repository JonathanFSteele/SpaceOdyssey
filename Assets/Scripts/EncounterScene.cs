using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterScene : MonoBehaviour {

	//general stuuf
	private double MaxDistance = 300000; // In miles
	private double AvgTime = 3.5; // In Earth Days
	private double ShipSpeed = 60000.0; //Miles per day
	private double CurrentDistance = 0.0;
	private double TimeTaken = 0.0;
	private bool EncounterTF = false;
	private bool TravelFinishedTF = false;
	//public float distancePerSecond = 5;
	public GameObject player;
   public GameObject shipObj;
	private Ship ship;

	public GameObject encounter;
	public Encounter GenEnc;
	//progress bar references
	public GameObject playerShip;
	public GameObject PlayerImage;
	public GameObject playerStartPlace;
	public GameObject playerEndPlace;
	public GameObject playerText;
	public GameObject bars1;
	public GameObject bars2;

	//Win/Lose popUP stuff
	public GameObject rewards;
	public GameObject loses;
	public GameObject toptext;

	//progress bar variables
	Vector2 playerStart;
	Vector2 playerEnd;
	Vector2 playerPos;
	float percent;
	float progress;
	float prevProgress;
	float distance;


	// Use this for initialization
	void Start () {
		
		ship = shipObj.GetComponent<Ship> ();		
		encounter = GameObject.FindGameObjectWithTag ("Encounter");
		//player value retrieving
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			if (player.GetComponent<Player> ().DistanceToTarget == -1)
				SceneManager.LoadScene ("Safezone");
			else if (player.GetComponent<Player> ().DistanceToTarget > 0) {
				PlayerImage.GetComponent<UnityEngine.UI.Image> ().sprite = ship.shipPicture;
				MaxDistance = player.GetComponent<Player> ().DistanceToTarget;
				playerText.GetComponent<UnityEngine.UI.Text>().text = "Player Stats: Combat:" + player.GetComponent<Player> ().totalCombat + " Charisma:" + player.GetComponent<Player> ().totalCharisma + " Medical:" + player.GetComponent<Player> ().totalMedical;
			}
			else
				Debug.Log ("Player DistanceToTarget Not Set!!!!");
		}

		if (player != null) {
			if (ship.speed > 0) {
				MaxDistance = player.GetComponent<Player> ().DistanceToTarget;
				ShipSpeed = ship.speed;
			}
			else
				Debug.Log ("Player Speed Not Set!!!!");
		}


		StartCoroutine(Travel());
		playerStart = new Vector2( playerStartPlace.transform.localPosition.x , playerStartPlace.transform.localPosition.y);
		playerEnd = new Vector2( playerEndPlace.transform.localPosition.x , playerEndPlace.transform.localPosition.y);
		distance = playerEnd.x - playerStart.x;
		playerPos = playerStart;
	}

	//void Update(){
	//	if (EncounterTF == false) {
	//		
	//	}
	//}

	IEnumerator Travel()
	{
		GenEnc = encounter.GetComponent<Encounter> ();
		while (TravelFinishedTF == false) {
			yield return new WaitForSeconds(2);
			if (EncounterTF == false) {
				if (CurrentDistance < MaxDistance) {
					CurrentDistance += ShipSpeed;
					TimeTaken += 1;

					//// move object
					percent = (float)(CurrentDistance / MaxDistance);
					if (percent > 1)
						percent = 1;
					progress = percent * distance;
					if (progress != prevProgress) {
						//Debug.Log (percent);
						playerPos = new Vector2 (playerPos.x + (progress - prevProgress), playerPos.y);
						prevProgress = progress;
						ship.fuel -= ship.fuelEfficiency;
						ship.supplies -= 3;
						bars1.GetComponent<AdjustBarAndStatLevels> ().UpdateText ();
						bars2.GetComponent<AdjustBarAndStatLevels> ().UpdateText ();
					}
					playerShip.transform.localPosition =  new Vector2(playerPos.x, playerPos.y);
					//// move object

					// Generate encounter
					if (percent < 1)
					GenEnc = this.GetComponent<EncounterGenerator>().GenerateEncounter (player.GetComponent<Player>().PathColor,this.GetComponent<Encounter>() );
					if (GenEnc != null) {
						EncounterTF = true;
						this.GetComponent<Encounter> ().Equals (this.GetComponent<Encounter>(), GenEnc);
						//Debug.Log ("IT WORKED?");
					}
					//Call Encounter Generator Function -- Return EncounterTF == true or false
					Debug.Log ("Traveled " + CurrentDistance + " Miles In " + TimeTaken + " Earth Days");
				} else {
					TravelFinishedTF = true;
					Debug.Log ("Made it to destination in " + TimeTaken + " Earth Days");

				}
			} else {
				if (CurrentDistance >= MaxDistance) {
					
					player.GetComponent<Player> ().TimePassedSinceStart += player.GetComponent<Player> ().TimeToTarget;
					player.GetComponent<Player> ().CurrentLocationID = player.GetComponent<Player> ().TargetLocationID;
					player.GetComponent<Player> ().TargetLocationID = 0;
					SceneManager.LoadScene ("Safezone");

				}
				//Debug.Log ("Encounter Encountered, Waiting for Results ");
			}
		}
		Debug.Log("Travel Finished Jump back to Safezone Page, with new Destination");
		//Change Scenes with new Destination for Safe Zone...
		player.GetComponent<Player> ().TimePassedSinceStart += player.GetComponent<Player> ().TimeToTarget;
		player.GetComponent<Player> ().CurrentLocationID = player.GetComponent<Player> ().TargetLocationID;
		player.GetComponent<Player> ().TargetLocationID = 0;
		SceneManager.LoadScene ("Safezone");
	}

	public void EncounterComplete(int a) {
		
		if (a == 1) {
			toptext.GetComponent<UnityEngine.UI.Text> ().text = "Failure.";
			rewards.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
			loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			//EncounterTF = false;
			return;
		}

		if (a == 2) {
			toptext.GetComponent<UnityEngine.UI.Text> ().text = "Failure.";
			rewards.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
			loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			//EncounterTF = false;
			return;
		}

		if (a == 3) {
			toptext.GetComponent<UnityEngine.UI.Text> ().text = "Failure.";
			rewards.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
			loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			//EncounterTF = false;
			return;
		}


		toptext.GetComponent<UnityEngine.UI.Text> ().text = "Success!";	
		rewards.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
		loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: None";
		//EncounterTF = false;
		
		//StartCoroutine(Travel());
	}

	public void ContinueTravel(){
		EncounterTF = false;
	}



}