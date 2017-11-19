using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipPort : MonoBehaviour {

public GameObject library;

public GameObject canvasShipUI; 
public GameObject canvasShipYard; //aka: Canvas_TopRow w/ script
public GameObject canvasHeader; //aka: Canvas_ShipYardUI_wScript
public GameObject playerShipObj; 
public GameObject playerObj; 

private Player player;	// to get playerMoney
private Ship playerShip;	// public GameObject storeShip;
private AdjustBarAndStatLevels portStats; //attached to Canvas_ShipYardUI_wScript
private AdjustBarAndStatLevels headerStats;
private AdjustBarAndStatLevels shipUIStats;
private Ship shopShip;

public Button purchaseButton;
public Button fuelButton;
public Button repairButton;

private int fuelPrice = 200;
private int repairPrice = 300;


public void Start () {}


public void buyFuel() 
{ //called by purchase button
	library = GameObject.FindGameObjectWithTag ("Library");
	player = playerObj.GetComponent<Player>();
	playerShip = playerShipObj.GetComponent<Ship> ();		


	if(player.credits - fuelPrice >= 0)
	{
		player.credits -= fuelPrice;

		playerShip.fuel = playerShip.maxFuel;


		//UPDATE header and shipUIcanvas
		headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels>();
		headerStats.UpdateText();	//updates balance and header stats	

		shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
		shipUIStats.UpdateText();		

		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
		portStats.UpdateText();			
	}
}


public void buyRepair() 
{ //called by purchase button
	library = GameObject.FindGameObjectWithTag ("Library");
	player = playerObj.GetComponent<Player>();
	playerShip = playerShipObj.GetComponent<Ship> ();		


	if(player.credits - repairPrice >= 0)
	{
		player.credits -= repairPrice;

		playerShip.health = playerShip.maxHealth;


		//UPDATE header and shipUIcanvas
		headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels>();
		headerStats.UpdateText();	//updates balance and header stats	

		shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
		shipUIStats.UpdateText();		

		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
		portStats.UpdateBalance();			
	}
}


public void buyShip()
{ //called by purchase button
	library = GameObject.FindGameObjectWithTag ("Library");
	player = playerObj.GetComponent<Player>();
	shopShip = library.GetComponent<ShipLibraryPrefab> ().buyCurrentShip ("shop_ships");
		playerShip = playerShipObj.GetComponent<Ship> ();		

	if(player.credits - shopShip.shipPrice >= 0)
	{
		player.credits -= shopShip.shipPrice;

		playerShip.shipPicture = shopShip.shipPicture;
		playerShip.shipName = shopShip.shipName;
		playerShip.maxHealth = shopShip.maxHealth;
		playerShip.health = shopShip.health;
		playerShip.shields = shopShip.shields;
		playerShip.armor = shopShip.armor;
		playerShip.speed = shopShip.speed;
		playerShip.gunCount = shopShip.gunCount;
		playerShip.gunDamage = shopShip.gunDamage;
		playerShip.maxFuel = shopShip.maxFuel;
		playerShip.fuelEfficiency = shopShip.fuelEfficiency;
		playerShip.fuel = shopShip.fuel;
		playerShip.crewCapacity = shopShip.crewCapacity;
		playerShip.crewAmt = shopShip.crewAmt;
		playerShip.maxSupplies = shopShip.maxSupplies;
		playerShip.supplies = shopShip.supplies;
		playerShip.medicalBonus = shopShip.medicalBonus;
		playerShip.combatBonus = shopShip.combatBonus;
		playerShip.charsmaBonus = shopShip.charsmaBonus;

		//UPDATE header and shipUIcanvas
		headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels>();
		headerStats.UpdateText();	//updates balance and header stats	

		shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
		shipUIStats.UpdateText();		

		portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
		portStats.UpdateText();			

	}
}


public void loadShipYard() 
{
	library = GameObject.FindGameObjectWithTag ("Library");
	shopShip = library.GetComponent<ShipLibraryPrefab> ().getFirstShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
	player = playerObj.GetComponent<Player>();
	playerShip = playerShipObj.GetComponent<Ship> ();		

	// print("shopShip.shipName: " + shopShip.shipName);
	// print("playerShip.shipName: " + playerShip.shipName);
	while(playerShip.shipName == shopShip.shipName)
	{
		print("NAME SAME");
		shopShip = library.GetComponent<ShipLibraryPrefab> ().getNextShip ("shop_ships");
	}

	portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
	portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " £  ";
	portStats.shipPicture.sprite = shopShip.shipPicture;
	portStats.shipNameDisplayText.text = shopShip.shipName.ToString();
	portStats.hpDisplayText.text = shopShip.health.ToString();
	portStats.speedDisplayText.text = shopShip.speed.ToString();
	portStats.shieldsDisplayText.text = shopShip.shields.ToString();
	portStats.gunDamageDisplayText.text = shopShip.gunDamage.ToString();
	portStats.fuelDisplayText.text = shopShip.fuel.ToString();
	portStats.armorDisplayText.text = shopShip.armor.ToString();
	portStats.gunCountDisplayText.text = shopShip.gunCount.ToString();
	portStats.crewDisplayText.text = shopShip.crewAmt.ToString();



	//checks if player can afford 'upgrades'. and needs them
	if(player.credits - repairPrice >= 0 && playerShip.health < playerShip.maxHealth)
		repairButton.interactable = true;
	else
		repairButton.interactable = false;		


	if(player.credits - fuelPrice >= 0 && playerShip.fuel < playerShip.maxFuel)
		fuelButton.interactable = true;
	else
		fuelButton.interactable = false;		


	if(player.credits - shopShip.shipPrice >= 0)
		purchaseButton.interactable = true;
	else
		purchaseButton.interactable = false;		
}


public void previousShopShip() 
{
	library = GameObject.FindGameObjectWithTag ("Library");
	shopShip = library.GetComponent<ShipLibraryPrefab> ().getPreviousShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
	player = playerObj.GetComponent<Player>();
	playerShip = playerShipObj.GetComponent<Ship> ();		

	if(playerShip.shipName == shopShip.shipName)
		shopShip = library.GetComponent<ShipLibraryPrefab> ().getPreviousShip ("shop_ships");

	if(player.credits - shopShip.shipPrice >= 0) //checks if player can afford ship. 
		purchaseButton.interactable = true;
	else
		purchaseButton.interactable = false;		

	portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
	portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " £  ";
	portStats.shipPicture.sprite = shopShip.shipPicture;
	portStats.shipNameDisplayText.text = shopShip.shipName.ToString();
	portStats.hpDisplayText.text = shopShip.health.ToString();
	portStats.speedDisplayText.text = shopShip.speed.ToString();
	portStats.shieldsDisplayText.text = shopShip.shields.ToString();
	portStats.gunDamageDisplayText.text = shopShip.gunDamage.ToString();
	portStats.fuelDisplayText.text = shopShip.fuel.ToString();
	portStats.armorDisplayText.text = shopShip.armor.ToString();
	portStats.gunCountDisplayText.text = shopShip.gunCount.ToString();
	portStats.crewDisplayText.text = shopShip.crewAmt.ToString();
}


public void nextShopShip() 
{
	library = GameObject.FindGameObjectWithTag ("Library");
	shopShip = library.GetComponent<ShipLibraryPrefab> ().getNextShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();
	player = playerObj.GetComponent<Player>();
	playerShip = playerShipObj.GetComponent<Ship> ();		

	if(playerShip.shipName == shopShip.shipName)
		shopShip = library.GetComponent<ShipLibraryPrefab> ().getNextShip ("shop_ships");

	if(player.credits - shopShip.shipPrice >= 0) //checks if player can afford ship. 
		purchaseButton.interactable = true;
	else
		purchaseButton.interactable = false;		

	portStats.balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
	portStats.costDisplayText.text = shopShip.shipPrice.ToString () + " £  ";
	portStats.shipPicture.sprite = shopShip.shipPicture;
	portStats.shipNameDisplayText.text = shopShip.shipName.ToString();
	portStats.hpDisplayText.text = shopShip.health.ToString();
	portStats.speedDisplayText.text = shopShip.speed.ToString();
	portStats.shieldsDisplayText.text = shopShip.shields.ToString();
	portStats.gunDamageDisplayText.text = shopShip.gunDamage.ToString();
	portStats.fuelDisplayText.text = shopShip.fuel.ToString();
	portStats.armorDisplayText.text = shopShip.armor.ToString();
	portStats.gunCountDisplayText.text = shopShip.gunCount.ToString();
	portStats.crewDisplayText.text = shopShip.crewAmt.ToString();
}



} //end of script
