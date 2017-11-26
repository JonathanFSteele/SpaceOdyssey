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
	public GameObject result;
	public GameObject loses;
	public GameObject description;

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
		
		encounter = GameObject.FindGameObjectWithTag ("Encounter");
		//player value retrieving
		player = GameObject.FindGameObjectWithTag ("Player");
		ship = player.GetComponent<Player> ().playerShip;
		if (player != null) {
			if (player.GetComponent<Player> ().DistanceToTarget == -1)
				SceneManager.LoadScene ("Safezone");
			else if (player.GetComponent<Player> ().DistanceToTarget > 0) {
//				PlayerImage.GetComponent<UnityEngine.UI.Image> ().sprite = ship.shipPicture;
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
						ship.fuel -= (ship.fuelEfficiency + ship.extraFuelLostBecauseDamage);
						ship.supplies -= 3;//when crew implemented, this needs to change
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
					player.GetComponent<Player> ().sceneID = 1;
					SceneManager.LoadScene ("Safezone");

				}
				//Debug.Log ("Encounter Encountered, Waiting for Results ");
			}
		}
		Debug.Log("Travel Finished Jump back to Safezone Page, with new Destination");
		//Change Scenes with new Destination for Safe Zone...
		player.GetComponent<Player> ().TimePassedSinceStart += player.GetComponent<Player> ().TimeToTarget;
		player.GetComponent<Player> ().TotalDistanceTraveled += player.GetComponent<Player> ().DistanceToTarget;
		player.GetComponent<Player> ().CurrentLocationID = player.GetComponent<Player> ().TargetLocationID;
		player.GetComponent<Player> ().TargetLocationID = 0;
		player.GetComponent<Player> ().sceneID = 1;
		SceneManager.LoadScene ("Safezone");
	}

	public void EncounterComplete(int a) {
		//LOses
		if (a >= 1 && a <= 3) {
			result.GetComponent<UnityEngine.UI.Text> ().text = "Failure.";
			GenerateLoss (a);

			return;
		}


		//Wins
		if (a >= 4 && a <= 6) {
			result.GetComponent<UnityEngine.UI.Text> ().text = "Success!";	
			GenerateReward (a);
	
			return;
		}

		if (a == 7) {
			result.GetComponent<UnityEngine.UI.Text> ().text = " A win I guess?";	
			description.GetComponent<UnityEngine.UI.Text> ().text = "You just kinda flew away";
			loses.GetComponent<UnityEngine.UI.Text> ().text = "Nada";
			return;
		}

		if (a == 8) {
			result.GetComponent<UnityEngine.UI.Text> ().text = "Ya Done Goofed";	
			description.GetComponent<UnityEngine.UI.Text> ().text = "Your ship was not fast enough to get away and your ship got damaged.";
			loses.GetComponent<UnityEngine.UI.Text> ().text = "A lot of health";
			ship.health -= 5;
			bars1.GetComponent<AdjustBarAndStatLevels> ().UpdateText ();
			bars2.GetComponent<AdjustBarAndStatLevels> ().UpdateText ();
			return;
		}

		result.GetComponent<UnityEngine.UI.Text> ().text = " it broke";	
		description.GetComponent<UnityEngine.UI.Text> ().text = "Ripp";
		loses.GetComponent<UnityEngine.UI.Text> ().text = "Tell Zach about this";
		//EncounterTF = false;
		
		//StartCoroutine(Travel());
	}

	public void ContinueTravel(){
		EncounterTF = false;
	}


	public void GenerateReward( int a ){
		Debug.Log ("YE we has" + a);
		if (a == 4) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				int s = Random.Range (1, 6);
				description.GetComponent<UnityEngine.UI.Text> ().text = "You out gunned your opponent and found some supplies in their wreckage.";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Gain " + s + " supplies";
				ship.supplies += s;
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "You shot their fuel tank and completely destroyed their ship!";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You found nothing";
			}
			if (r == 2) {
				int c = Random.Range (5, 15);
				description.GetComponent<UnityEngine.UI.Text> ().text = "They quickly realized they were going to lose, surrendered, and gave you some credits";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You Gained " + c + " credits";
				player.GetComponent<Player> ().credits += c;
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "They just kind of blew up...";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You found nothing";
			}

			return;
		}

		if (a == 5) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				int c = Random.Range (5, 15);
				description.GetComponent<UnityEngine.UI.Text> ().text = "They decided to fund you!";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You Gained " + c + " credits";
				player.GetComponent<Player> ().credits += c;
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "You made some new friends! maybe they'll add you on Facebook!";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You now have a friend, YAY!";
			}
			if (r == 2) {
				int f = Random.Range (0 , 5);
				description.GetComponent<UnityEngine.UI.Text> ().text = "They Gave you some fuel! How nice of them!";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "you gained" + f + " hundred fuel";
				ship.fuel += (f * 100);
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "You had a nice chat and they flew off into the sunset";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You had a good time";
			}

			return;
		}

		if (a == 6) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				int c = Random.Range (5, 15);
				description.GetComponent<UnityEngine.UI.Text> ().text = "They were very thankful and gave you some credits";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You Gained " + c + " credits";
				player.GetComponent<Player> ().credits += c;
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "They just said 'Thaaaanks brah' and left";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "You gained nothing";
			}
			if (r == 2) {
				int s = Random.Range (1, 6);
				description.GetComponent<UnityEngine.UI.Text> ().text = "They didn't seem too excited about you helping them, but they did give you some food";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Gain " + s + " supplies";
				ship.supplies += s;
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "It was just a flesh wound, but they felt obligated to give you something";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "you gained a hundred fuel";
				ship.fuel += 100;
			}
			return;
		}

	}

	public void GenerateLoss( int a ) {

		if (a == 1) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 2) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
		}

		if (a == 2) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 2) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
		}

		if (a == 3) {
			int r = Random.Range (0, 3);
			if (r == 0) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 1) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 2) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
			if (r == 3) {
				description.GetComponent<UnityEngine.UI.Text> ().text = "Rewards: None";
				loses.GetComponent<UnityEngine.UI.Text> ().text = "Loses: 10 credits";
			}
		}

	}
		



}