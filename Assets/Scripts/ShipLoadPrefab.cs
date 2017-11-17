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


// Use this for initialization
	public void Start () {}


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
