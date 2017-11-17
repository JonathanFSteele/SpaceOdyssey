using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipLoad : MonoBehaviour {

//	public GameObject distanceText;
//	public GameObject timeText;
	public GameObject image;
	public GameObject library;
//	public GameObject player;


	// Use this for initialization
	public void Start () {
//		player = GameObject.FindGameObjectWithTag ("Player");
	    library = GameObject.FindGameObjectWithTag ("Library");
//		player = GameObject.Find ("Player");
//		library = GameObject.Find ("Library");
	}


	public void nextShopShip() {
		library = GameObject.FindGameObjectWithTag ("Library");
		//		print ("loadShip()");
		image.GetComponent<UnityEngine.UI.Image>().sprite =  library.GetComponent<ShipLibrary> ().getNextShip ("shop_ships");
	}
		
	public void previousShopShip() {
		library = GameObject.FindGameObjectWithTag ("Library");
		//		print ("loadShip()");
		image.GetComponent<UnityEngine.UI.Image>().sprite =  library.GetComponent<ShipLibrary> ().getNextShip ("shop_ships");
	}

	public void loadShipYard() {
		library = GameObject.FindGameObjectWithTag ("Library");
		//		print ("loadShip()");
		if(image.GetComponent<UnityEngine.UI.Image>().sprite == null)
			image.GetComponent<UnityEngine.UI.Image>().sprite =  library.GetComponent<ShipLibrary> ().getFirstShip ("shop_ships");
	}

	public void TransitToEncounter () {
		SceneManager.LoadScene ("Encounter");
	}
}
