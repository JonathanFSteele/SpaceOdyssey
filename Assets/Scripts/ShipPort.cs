using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipPort : MonoBehaviour
{

	public GameObject library;

	public GameObject canvasShipUI;	//aka: Canvas_ShipUI_wScript
	public GameObject canvasShipYard;	//aka: Canvas_ShipYardUI_wScript
	public GameObject canvasHeader;	//aka: Canvas_TopRow w/ script
	//public GameObject playerShipObj;
	public GameObject playerObj;

	private Player player;
	// to get playerMoney
	private Ship playerShip;
	// public GameObject storeShip;
	private AdjustBarAndStatLevels portStats;
	//attached to Canvas_ShipYardUI_wScript
	private AdjustBarAndStatLevels headerStats;
	private AdjustBarAndStatLevels shipUIStats;
	private Ship shopShip;
	private Sprite returnedPicture;

	public Button purchaseButton;
	public Button fuelButton;
	public Button repairButton;

	private int fuelPrice = 1; //* (player.playerShip.maxFuel - player.playerShip.fuel);
	private int repairPrice = 100; // * (player.playerShip.maxHealth - player.playerShip.health);


	public void Start ()
	{
	}


	public void buyFuel ()
	{ //called by purchase button
		Debug.Log ("Buying Fuel!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerShip = playerObj.GetComponent<Player> ().playerShip;		


		if (player.credits >= (fuelPrice * (player.playerShip.maxFuel - player.playerShip.fuel))) {
			player.credits -= (fuelPrice * (player.playerShip.maxFuel - player.playerShip.fuel));

			playerShip.fuel = playerShip.maxFuel;


			//UPDATE header and shipUIcanvas
			headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels> ();
			headerStats.UpdateText ();	//updates balance and header stats	

			// shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
			// shipUIStats.UpdateText();		
			loadShipUI_Display ();

			portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> ();
			portStats.UpdateBalance ();			
		}
	}


	public void buyRepair ()
	{ //called by purchase button
		Debug.Log ("Buying Repair!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerShip = playerObj.GetComponent<Player> ().playerShip;		


		if (player.credits >= (repairPrice * (player.playerShip.maxHealth - player.playerShip.health))) {
			player.credits -= (repairPrice * (player.playerShip.maxHealth - player.playerShip.health));

			playerShip.health = playerShip.maxHealth;


			//UPDATE header and shipUIcanvas
			headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels> ();
			headerStats.UpdateText ();	//updates balance and header stats	

			// shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
			// shipUIStats.UpdateText();		
			loadShipUI_Display ();

			portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> ();
			portStats.UpdateBalance ();			
		}
	}


	public void buyShip ()
	{ //called by purchase button
		Debug.Log ("Buy Ship!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		shopShip = library.GetComponent<ShipObjLibrary> ().buyCurrentShip (0);
		//playerShip = playerObj.GetComponent<Player>().playerShip;

		if (player.credits - shopShip.shipPrice >= 0) {
			player.credits -= shopShip.shipPrice;

			playerShip.shipPicture = shopShip.shipPicture;
			playerShip.shipName = shopShip.shipName;
			playerShip.maxHealth = shopShip.maxHealth;
			// if(playerShip.health > shopShip.maxHealth)
			playerShip.health = shopShip.maxHealth;
//		playerShip.shields = shopShip.shields;
//		playerShip.armor = shopShip.armor;
			playerShip.speed = shopShip.speed;
//		playerShip.gunCount = shopShip.gunCount;
//		playerShip.gunDamage = shopShip.gunDamage;
			playerShip.maxFuel = shopShip.maxFuel;
			playerShip.fuelEfficiency = shopShip.fuelEfficiency;
			// if(playerShip.fuel > shopShip.maxFuel)
			playerShip.fuel = shopShip.maxFuel;
			playerShip.crewCapacity = shopShip.crewCapacity;
			if (playerShip.crewAmt > shopShip.crewCapacity)
				playerShip.crewAmt = shopShip.crewCapacity;
			playerShip.maxSupplies = shopShip.maxSupplies;
			if (playerShip.supplies > shopShip.maxSupplies)
				playerShip.supplies = shopShip.maxSupplies;
//		playerShip.medicalBonus = shopShip.medicalBonus;
			playerShip.combatBonus = shopShip.combatBonus;
//		playerShip.charsmaBonus = shopShip.charsmaBonus;
		
			//Debug.Log ("PlayerShip Bought and Added: ", player.playerShip);
			//player.playerShip = playerShip;

			// playerShip.health = 5;
			// playerShip.fuel = 5;

			//UPDATE header and shipUIcanvas
			headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels> ();
			headerStats.UpdateText ();	//updates balance and header stats	

			// shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
			// shipUIStats.UpdateText();		
			loadShipUI_Display ();

			portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> ();
			portStats.UpdateBalance ();		

			player.UpdatePlayerStats();

 
		}
	}


	public void loadShipYard ()
	{
		Debug.Log ("Load Ship Yard!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		shopShip = library.GetComponent<ShipObjLibrary> ().getFirstShip (0);
		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> (); 
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerShip = playerObj.GetComponent<Player> ().playerShip;
		returnedPicture = library.GetComponent<ShipLibrary> ().GetClipFromName (shopShip.shipPicture);

		fuelButton.GetComponentInChildren<Text>().text = "Refuel: " + (fuelPrice * (player.playerShip.maxFuel - player.playerShip.fuel)).ToString() + " €";
		repairButton.GetComponentInChildren<Text>().text = "Repair: " + (repairPrice * (player.playerShip.maxHealth - player.playerShip.health)).ToString() + " €";
			
		// print("shopShip.shipName: " + shopShip.shipName);
		// print("playerShip.shipName: " + playerShip.shipName);
		while (playerShip.shipName == shopShip.shipName) {
			//print("NAME SAME");
			shopShip = library.GetComponent<ShipObjLibrary> ().getNextShip (0);
		}

		portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " €  ";
		portStats.CurrentShipDisplayImage.sprite = returnedPicture;
		portStats.CurrentShipNameDisplayText.text = shopShip.shipName.ToString ();
		portStats.hpDisplayText.text = "Health: " + shopShip.maxHealth.ToString ();
		portStats.speedDisplayText.text = "Speed: " + shopShip.speed.ToString ();
		portStats.fuelDisplayText.text = "Fuel: " + shopShip.fuel.ToString ();
		portStats.crewDisplayText.text = "Crew Capacity: " + shopShip.crewCapacity.ToString ();
		portStats.supplyDisplayText.text = "Supply Capacity: " + shopShip.maxSupplies.ToString ();
		portStats.combatModifierText.text = "Combat Modifier: " + shopShip.combatBonus.ToString ();

		//	portStats.armorDisplayText.text = "Armor: " + shopShip.armor.ToString();
		//	portStats.gunCountDisplayText.text = "Gun Count: " + shopShip.gunCount.ToString();
		//	portStats.shieldsDisplayText.text = "Shields: " + shopShip.shields.ToString();
		//	portStats.gunDamageDisplayText.text = "Gun Damage: " + shopShip.gunDamage.ToString();



		//checks if player can afford 'upgrades'. and needs them
		if (player.credits - repairPrice >= (repairPrice * (player.playerShip.maxHealth - player.playerShip.health)) && playerShip.health < playerShip.maxHealth)
			repairButton.interactable = true;
		else
			repairButton.interactable = false;		


		if (player.credits - fuelPrice >= (fuelPrice * (player.playerShip.maxFuel - player.playerShip.fuel)) && playerShip.fuel < playerShip.maxFuel)
			fuelButton.interactable = true;
		else
			fuelButton.interactable = false;		


		if (player.credits - shopShip.shipPrice >= 0)
			purchaseButton.interactable = true;
		else
			purchaseButton.interactable = false;	 
		Debug.Log ("End ShipYard");
	}


	public void previousShopShip ()
	{
		Debug.Log ("Previous Shop Ship!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		shopShip = library.GetComponent<ShipObjLibrary> ().getPreviousShip (0);
		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> ();

		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerShip = playerObj.GetComponent<Player> ().playerShip;
		returnedPicture = library.GetComponent<ShipLibrary> ().GetClipFromName (shopShip.shipPicture);

		if (playerShip.shipName == shopShip.shipName)
			shopShip = library.GetComponent<ShipObjLibrary> ().getPreviousShip (0);

		if (player.credits - shopShip.shipPrice >= 0) //checks if player can afford ship. 
		purchaseButton.interactable = true;
		else
			purchaseButton.interactable = false;		

		portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " €  ";
		portStats.CurrentShipDisplayImage.sprite = returnedPicture;
		portStats.CurrentShipNameDisplayText.text = shopShip.shipName.ToString ();
		portStats.hpDisplayText.text = "Health: " + shopShip.maxHealth.ToString ();
		portStats.speedDisplayText.text = "Speed: " + shopShip.speed.ToString ();
		portStats.fuelDisplayText.text = "Fuel: " + shopShip.fuel.ToString ();
		portStats.crewDisplayText.text = "Crew Capacity: " + shopShip.crewCapacity.ToString ();
		portStats.supplyDisplayText.text = "Supply Capacity: " + shopShip.maxSupplies.ToString ();
		portStats.combatModifierText.text = "Combat Modifier: " + shopShip.combatBonus.ToString ();

		//	portStats.armorDisplayText.text = "Armor: " + shopShip.armor.ToString();
		//	portStats.gunCountDisplayText.text = "Gun Count: " + shopShip.gunCount.ToString();
		//	portStats.shieldsDisplayText.text = "Shields: " + shopShip.shields.ToString();
		//	portStats.gunDamageDisplayText.text = "Gun Damage: " + shopShip.gunDamage.ToString();
	}


	public void nextShopShip ()
	{
		Debug.Log ("Next Shop Ship!!!");
		library = GameObject.FindGameObjectWithTag ("Library");
		shopShip = library.GetComponent<ShipObjLibrary> ().getNextShip (0);
		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player> ();
		playerShip = playerObj.GetComponent<Player> ().playerShip;		
		returnedPicture = library.GetComponent<ShipLibrary> ().GetClipFromName (shopShip.shipPicture);

		if (playerShip.shipName == shopShip.shipName)
			shopShip = library.GetComponent<ShipObjLibrary> ().getNextShip (0);

		if (player.credits - shopShip.shipPrice >= 0) //checks if player can afford ship. 
		purchaseButton.interactable = true;
		else
			purchaseButton.interactable = false;		

		portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " €";
		portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " €  ";
		portStats.CurrentShipDisplayImage.sprite = returnedPicture;
		portStats.CurrentShipNameDisplayText.text = shopShip.shipName.ToString ();
		portStats.hpDisplayText.text = "Health: " + shopShip.maxHealth.ToString ();
		portStats.speedDisplayText.text = "Speed: " + shopShip.speed.ToString ();
		portStats.fuelDisplayText.text = "Fuel: " + shopShip.fuel.ToString ();
		portStats.crewDisplayText.text = "Crew Capacity: " + shopShip.crewCapacity.ToString ();
		portStats.supplyDisplayText.text = "Supply Capacity: " + shopShip.maxSupplies.ToString ();
		portStats.combatModifierText.text = "Combat Modifier: " + shopShip.combatBonus.ToString ();

		//	portStats.shieldsDisplayText.text = "Shields: " + shopShip.shields.ToString();
		//	portStats.gunDamageDisplayText.text = "Gun Damage: " + shopShip.gunDamage.ToString();
		//	portStats.armorDisplayText.text = "Armor: " + shopShip.armor.ToString();
		//	portStats.gunCountDisplayText.text = "Gun Count: " + shopShip.gunCount.ToString();
	}



	public void loadShipUI_Display ()
	{

		Debug.Log ("Load Ship UI Display!!!");
		
		shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		playerShip = playerObj.GetComponent<Player> ().playerShip;
		//returnedPicture = library.GetComponent<ShipLibrary>().GetClipFromName(playerShip.shipPicture);
		//shipUIStats.CurrentShipDisplayImage.sprite = returnedPicture;

		shipUIStats.CurrentShipNameDisplayText.text = playerShip.shipName.ToString();
		shipUIStats.hpDisplayText.text = "Health: " + playerShip.maxHealth.ToString ();
		shipUIStats.speedDisplayText.text = "Speed: " + playerShip.speed.ToString();
		shipUIStats.fuelDisplayText.text = "Fuel: " + playerShip.fuel.ToString ();
		shipUIStats.crewDisplayText.text = "Crew Capacity: " + playerShip.crewCapacity.ToString ();
		shipUIStats.supplyDisplayText.text = "Supply Capacity: " + playerShip.maxSupplies.ToString ();
		shipUIStats.combatModifierText.text = "Combat Modifier: " + playerShip.combatBonus.ToString();

		//	shipUIStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
		//	shipUIStats.costDisplayText.text = playerShip.shipPrice.ToString () + " £  ";
		//	shipUIStats.shieldsDisplayText.text = "Shields: " + playerShip.shields.ToString();
		//	shipUIStats.gunDamageDisplayText.text = "Gun Damage: " + playerShip.gunDamage.ToString();
		//	shipUIStats.armorDisplayText.text = "Armor: " + playerShip.armor.ToString();
		//	shipUIStats.gunCountDisplayText.text = "Gun Count: " + playerShip.gunCount.ToString();
	}



}
 //end of script
