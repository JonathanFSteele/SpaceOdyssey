using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
	public GameObject library;

	public GameObject canvasCrewUI;				//aka : Canvas_Crew
	public GameObject canvasRecruitmentCenter;	//aka : Canvas_RecruitCenter
	public GameObject canvasHeader;				//aka : Canvas_TopRow w/ script

	private AdjustBarAndStatLevels CenterStats;
	private AdjustBarAndStatLevels HeaderStats;
	//private AdjustBarAndStatLevels CrewUIStats;

	public GameObject playerObj;

	private Player player;	// to get playerMoney
	private Crew CurrentCrewMember;
	private Crew RecruitMember;
	private Sprite returnedPicture;

	public Button HireButton;


	public void Start ()
	{
	}

	public void HireCrew()
	{
		Debug.Log ("Hiring Crew Member!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		RecruitMember = library.GetComponent<CrewLibrary>().HireCurrentCrew(0);
		int originalLength = player.playerCrew.Length;

		if (player.credits - RecruitMember.CrewPrice >= 0) {

			player.credits -= RecruitMember.CrewPrice;

			Crew tempCrew = new Crew();
			tempCrew.CrewName = RecruitMember.CrewName;
			tempCrew.CrewImage = RecruitMember.CrewImage;
			tempCrew.Description = RecruitMember.Description;
			tempCrew.Combat = RecruitMember.Combat;
			tempCrew.Charisma = RecruitMember.Charisma;
			tempCrew.Medicine = RecruitMember.Medicine;

			Crew[] finalArray = new Crew[ originalLength + 1 ];
			for(int i = 0; i < originalLength; i++ ) {
				finalArray[i] = player.playerCrew[i];
			}
			finalArray[finalArray.Length - 1] = tempCrew;
			player.playerCrew = finalArray;
			player.playerShip.crewAmt = finalArray.Length;

			//UPDATE header and shipUIcanvas
			HeaderStats = canvasHeader.GetComponent<AdjustBarAndStatLevels> ();
			HeaderStats.UpdateText ();	//updates balance and header stats	

//			CrewUIStats = canvasCrewUI.GetComponent<AdjustBarAndStatLevels>();
//			CrewUIStats.UpdateText();
			//loadCrewUI_Display (); //TODO: still fix this

			LoadRecruitmentCenter ();

			CenterStats = canvasRecruitmentCenter.GetComponent<AdjustBarAndStatLevels> ();
			CenterStats.UpdateBalance();			

			player.UpdatePlayerStats();

		}

	}

	public void LoadRecruitmentCenter ()
	{
		Debug.Log ("Load RecruitmentCenter!!!");

		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		RecruitMember = library.GetComponent<CrewLibrary>().GetFirstCrew(0);
		CenterStats = canvasRecruitmentCenter.GetComponent<AdjustBarAndStatLevels> ();
		returnedPicture = library.GetComponent<CrewPictureLibrary> ().GetClipFromName (RecruitMember.CrewImage);

		CenterStats.BalanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		CenterStats.CostDisplayText.text = "Recruit for: " + RecruitMember.CrewPrice.ToString () + " €  ";
		CenterStats.CurrentCrewDisplayImage.sprite = returnedPicture;
		CenterStats.CurrentCrewNameDisplayText.text = RecruitMember.CrewName.ToString();
		CenterStats.CurrentCrewCombat.text = " Combat: " + RecruitMember.Combat.ToString();
		CenterStats.CurrentCrewMedical.text = " Medical: " + RecruitMember.Medicine.ToString();
		CenterStats.CurrentCrewCharisma.text = " Charisma: " + RecruitMember.Charisma.ToString();
		CenterStats.CurrentCrewDescription.text = RecruitMember.Description.ToString();

		if (player.credits - RecruitMember.CrewPrice >= 0)
			HireButton.interactable = true;
		else
			HireButton.interactable = false;	

		if (player.playerShip.crewAmt == player.playerShip.crewCapacity) {
			HireButton.interactable = false;
		} else {
			HireButton.interactable = true;
		}
			
	}


	public void previousCrewMember ()
	{
		Debug.Log ("Previous Crew Member!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		RecruitMember = library.GetComponent<CrewLibrary>().getPreviousCrew(0);
		CenterStats = canvasRecruitmentCenter.GetComponent<AdjustBarAndStatLevels> ();
		returnedPicture = library.GetComponent<CrewPictureLibrary> ().GetClipFromName (RecruitMember.CrewImage);

		if (player.credits - RecruitMember.CrewPrice >= 0)
			HireButton.interactable = true;
		else
			HireButton.interactable = false;	

		CenterStats.BalanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		CenterStats.CostDisplayText.text = "Recruit for: " + RecruitMember.CrewPrice.ToString () + " €  ";
		CenterStats.CurrentCrewDisplayImage.sprite = returnedPicture;
		CenterStats.CurrentCrewNameDisplayText.text = RecruitMember.CrewName.ToString();
		CenterStats.CurrentCrewCombat.text = " Combat: " + RecruitMember.Combat.ToString();
		CenterStats.CurrentCrewMedical.text = " Medical: " + RecruitMember.Medicine.ToString();
		CenterStats.CurrentCrewCharisma.text = " Charisma: " + RecruitMember.Charisma.ToString();
		CenterStats.CurrentCrewDescription.text = RecruitMember.Description.ToString();
	}


	public void nextCrewMember ()
	{
		Debug.Log ("Next Crew Member");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		RecruitMember = library.GetComponent<CrewLibrary>().GetNextCrew(0);
		CenterStats = canvasRecruitmentCenter.GetComponent<AdjustBarAndStatLevels> ();
		returnedPicture = library.GetComponent<CrewPictureLibrary> ().GetClipFromName (RecruitMember.CrewImage);

		if (player.credits - RecruitMember.CrewPrice >= 0)
			HireButton.interactable = true;
		else
			HireButton.interactable = false;	

		CenterStats.BalanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		CenterStats.CostDisplayText.text = "Recruit for: " + RecruitMember.CrewPrice.ToString () + " €  ";
		CenterStats.CurrentCrewDisplayImage.sprite = returnedPicture;
		CenterStats.CurrentCrewNameDisplayText.text = RecruitMember.CrewName.ToString();
		CenterStats.CurrentCrewCombat.text = " Combat: " + RecruitMember.Combat.ToString();
		CenterStats.CurrentCrewMedical.text = " Medical: " + RecruitMember.Medicine.ToString();
		CenterStats.CurrentCrewCharisma.text = " Charisma: " + RecruitMember.Charisma.ToString();
		CenterStats.CurrentCrewDescription.text = RecruitMember.Description.ToString();
	}

//
//	public void loadShipUI_Display ()
//	{
//
//		Debug.Log ("Load Ship UI Display!!!");
//
//		shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels> ();
//		playerObj = GameObject.FindGameObjectWithTag ("Player");
//		playerShip = playerObj.GetComponent<Player> ().playerShip;
//		//returnedPicture = library.GetComponent<ShipLibrary>().GetClipFromName(playerShip.shipPicture);
//		//shipUIStats.CurrentShipDisplayImage.sprite = returnedPicture;
//
//		shipUIStats.CurrentShipNameDisplayText.text = playerShip.shipName.ToString();
//		shipUIStats.hpDisplayText.text = "Health: " + playerShip.maxHealth.ToString ();
//		shipUIStats.speedDisplayText.text = "Speed: " + playerShip.speed.ToString();
//		shipUIStats.fuelDisplayText.text = "Fuel: " + playerShip.fuel.ToString ();
//		shipUIStats.crewDisplayText.text = "Crew Capacity: " + playerShip.crewCapacity.ToString ();
//		shipUIStats.supplyDisplayText.text = "Supply Capacity: " + playerShip.maxSupplies.ToString ();
//		shipUIStats.combatModifierText.text = "Combat Modifier: " + playerShip.combatBonus.ToString();
//
	//		//	shipUIStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
	//		//	shipUIStats.costDisplayText.text = playerShip.shipPrice.ToString () + " €  ";
//		//	shipUIStats.shieldsDisplayText.text = "Shields: " + playerShip.shields.ToString();
//		//	shipUIStats.gunDamageDisplayText.text = "Gun Damage: " + playerShip.gunDamage.ToString();
//		//	shipUIStats.armorDisplayText.text = "Armor: " + playerShip.armor.ToString();
//		//	shipUIStats.gunCountDisplayText.text = "Gun Count: " + playerShip.gunCount.ToString();
//	}
//


}

