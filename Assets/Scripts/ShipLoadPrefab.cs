using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipLoadPrefab : MonoBehaviour {

	public GameObject library;

	public GameObject canvas; //aka: Canvas_ShipYardUI_wScript
	private AdjustBarAndStatLevels stats; //attached to Canvas_ShipYardUI_wScript
	private Ship ship;


	public GameObject playerShipObj;
	private Ship playerShip;	// public GameObject storeShip;


// Use this for initialization
	public void Start () {}


	public void buyShip() {

		library = GameObject.FindGameObjectWithTag ("Library");
		ship = library.GetComponent<ShipLibraryPrefab> ().getCurrentShip ("shop_ships");
		// stats = canvas.GetComponent<AdjustBarAndStatLevels>();

		playerShip = playerShipObj.GetComponent<Ship> ();		

//METHOD #1
//		playerShip = ship;
//
//
//		if (playerShip == null)
//			print ("playerShip is null");
//
//		if (ship == null)
//			print ("ship is null");
//		

//METHOD #2
//		System.Type type = ship.GetType();
////		Component copy = playerShip.AddComponent(type);
////		// Copied fields can be restricted with BindingFlags
////
//		System.Reflection.FieldInfo[] fields = type.GetFields(); 
//		foreach (System.Reflection.FieldInfo field in fields)
//		{
//			field.SetValue(playerShip, field.GetValue(ship));
//		}


//METHOD #3
		playerShip.shipPicture = ship.shipPicture;


		// stats.shipPicture.sprite = ship.shipPicture;

		// stats.shipNameDisplayText.text = ship.shipName.ToString();
		// stats.hpDisplayText.text = ship.health.ToString();
		// stats.speedDisplayText.text = ship.speed.ToString();
		// stats.shieldsDisplayText.text = ship.shields.ToString();
		// stats.gunDamageDisplayText.text = ship.gunDamage.ToString();
		// stats.fuelDisplayText.text = ship.fuel.ToString();
		// stats.armorDisplayText.text = ship.armor.ToString();
		// stats.gunCountDisplayText.text = ship.gunCount.ToString();
		// stats.crewDisplayText.text = ship.crewAmt.ToString();
	}


	public void loadShipYard() {

		library = GameObject.FindGameObjectWithTag ("Library");
		ship = library.GetComponent<ShipLibraryPrefab> ().getFirstShip ("shop_ships");
		stats = canvas.GetComponent<AdjustBarAndStatLevels>();

		stats.shipPicture.sprite = ship.shipPicture;

		stats.shipNameDisplayText.text = ship.shipName.ToString();
		stats.hpDisplayText.text = ship.health.ToString();
		stats.speedDisplayText.text = ship.speed.ToString();
		stats.shieldsDisplayText.text = ship.shields.ToString();
		stats.gunDamageDisplayText.text = ship.gunDamage.ToString();
		stats.fuelDisplayText.text = ship.fuel.ToString();
		stats.armorDisplayText.text = ship.armor.ToString();
		stats.gunCountDisplayText.text = ship.gunCount.ToString();
		stats.crewDisplayText.text = ship.crewAmt.ToString();
	}


	public void previousShopShip() {
		library = GameObject.FindGameObjectWithTag ("Library");
		ship = library.GetComponent<ShipLibraryPrefab> ().getPreviousShip ("shop_ships");
		stats = canvas.GetComponent<AdjustBarAndStatLevels>();

		stats.shipPicture.sprite = ship.shipPicture;

		stats.shipNameDisplayText.text = ship.shipName.ToString();
		stats.hpDisplayText.text = ship.health.ToString();
		stats.speedDisplayText.text = ship.speed.ToString();
		stats.shieldsDisplayText.text = ship.shields.ToString();
		stats.gunDamageDisplayText.text = ship.gunDamage.ToString();
		stats.fuelDisplayText.text = ship.fuel.ToString();
		stats.armorDisplayText.text = ship.armor.ToString();
		stats.gunCountDisplayText.text = ship.gunCount.ToString();
		stats.crewDisplayText.text = ship.crewAmt.ToString();
	}


	public void nextShopShip() {
		library = GameObject.FindGameObjectWithTag ("Library");
		ship = library.GetComponent<ShipLibraryPrefab> ().getNextShip ("shop_ships");
		stats = canvas.GetComponent<AdjustBarAndStatLevels>();

		stats.shipPicture.sprite = ship.shipPicture;

		stats.shipNameDisplayText.text = ship.shipName.ToString();
		stats.hpDisplayText.text = ship.health.ToString();
		stats.speedDisplayText.text = ship.speed.ToString();
		stats.shieldsDisplayText.text = ship.shields.ToString();
		stats.gunDamageDisplayText.text = ship.gunDamage.ToString();
		stats.fuelDisplayText.text = ship.fuel.ToString();
		stats.armorDisplayText.text = ship.armor.ToString();
		stats.gunCountDisplayText.text = ship.gunCount.ToString();
		stats.crewDisplayText.text = ship.crewAmt.ToString();
	}



//	public void TransitToEncounter () {
//		SceneManager.LoadScene ("Encounter");
//	}
}
