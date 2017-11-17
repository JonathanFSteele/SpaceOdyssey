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

private Ship playerShip;	// public GameObject storeShip;
private AdjustBarAndStatLevels portStats; //attached to Canvas_ShipYardUI_wScript
private AdjustBarAndStatLevels headerStats;
private AdjustBarAndStatLevels shipUIStats;
private Ship ship;


public void Start () {}


public void buyShip() { //called by purchase button
	library = GameObject.FindGameObjectWithTag ("Library");
	ship = library.GetComponent<ShipLibraryPrefab> ().getCurrentShip ("shop_ships");
	playerShip = playerShipObj.GetComponent<Ship> ();		

	playerShip.shipPicture = ship.shipPicture;
	playerShip.shipName = ship.shipName;
	playerShip.maxHealth = ship.maxHealth;
	playerShip.health = ship.health;
	playerShip.shields = ship.shields;
	playerShip.armor = ship.armor;
	playerShip.speed = ship.speed;
	playerShip.gunCount = ship.gunCount;
	playerShip.gunDamage = ship.gunDamage;
	playerShip.maxFuel = ship.maxFuel;
	playerShip.fuelEfficiency = ship.fuelEfficiency;
	playerShip.fuel = ship.fuel;
	playerShip.crewCapacity = ship.crewCapacity;
	playerShip.crewAmt = ship.crewAmt;
	playerShip.maxSupplies = ship.maxSupplies;
	playerShip.supplies = ship.supplies;
	playerShip.medicalBonus = ship.medicalBonus;
	playerShip.combatBonus = ship.combatBonus;
	playerShip.charsmaBonus = ship.charsmaBonus;

//UPDATE header and shipUIcanvas
	headerStats = canvasHeader.GetComponent<AdjustBarAndStatLevels>();
	headerStats.UpdateText();		

	shipUIStats = canvasShipUI.GetComponent<AdjustBarAndStatLevels>();
	shipUIStats.Start();			
}


public void loadShipYard() {
	library = GameObject.FindGameObjectWithTag ("Library");
	ship = library.GetComponent<ShipLibraryPrefab> ().getFirstShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();

	portStats.shipPicture.sprite = ship.shipPicture;
	portStats.shipNameDisplayText.text = ship.shipName.ToString();
	portStats.hpDisplayText.text = ship.health.ToString();
	portStats.speedDisplayText.text = ship.speed.ToString();
	portStats.shieldsDisplayText.text = ship.shields.ToString();
	portStats.gunDamageDisplayText.text = ship.gunDamage.ToString();
	portStats.fuelDisplayText.text = ship.fuel.ToString();
	portStats.armorDisplayText.text = ship.armor.ToString();
	portStats.gunCountDisplayText.text = ship.gunCount.ToString();
	portStats.crewDisplayText.text = ship.crewAmt.ToString();
}


public void previousShopShip() {
	library = GameObject.FindGameObjectWithTag ("Library");
	ship = library.GetComponent<ShipLibraryPrefab> ().getPreviousShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();

	portStats.shipPicture.sprite = ship.shipPicture;
	portStats.shipNameDisplayText.text = ship.shipName.ToString();
	portStats.hpDisplayText.text = ship.health.ToString();
	portStats.speedDisplayText.text = ship.speed.ToString();
	portStats.shieldsDisplayText.text = ship.shields.ToString();
	portStats.gunDamageDisplayText.text = ship.gunDamage.ToString();
	portStats.fuelDisplayText.text = ship.fuel.ToString();
	portStats.armorDisplayText.text = ship.armor.ToString();
	portStats.gunCountDisplayText.text = ship.gunCount.ToString();
	portStats.crewDisplayText.text = ship.crewAmt.ToString();
}


public void nextShopShip() {
	library = GameObject.FindGameObjectWithTag ("Library");
	ship = library.GetComponent<ShipLibraryPrefab> ().getNextShip ("shop_ships");
	portStats = canvasShipYard.GetComponent<AdjustBarAndStatLevels>();

	portStats.shipPicture.sprite = ship.shipPicture;
	portStats.shipNameDisplayText.text = ship.shipName.ToString();
	portStats.hpDisplayText.text = ship.health.ToString();
	portStats.speedDisplayText.text = ship.speed.ToString();
	portStats.shieldsDisplayText.text = ship.shields.ToString();
	portStats.gunDamageDisplayText.text = ship.gunDamage.ToString();
	portStats.fuelDisplayText.text = ship.fuel.ToString();
	portStats.armorDisplayText.text = ship.armor.ToString();
	portStats.gunCountDisplayText.text = ship.gunCount.ToString();
	portStats.crewDisplayText.text = ship.crewAmt.ToString();
}



}
