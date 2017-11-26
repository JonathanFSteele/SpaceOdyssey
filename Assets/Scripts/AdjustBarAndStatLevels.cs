using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class AdjustBarAndStatLevels : MonoBehaviour
{  
	public GameObject playerObj; 
	public Text CurrentShipNameDisplayText;
	public Image CurrentShipDisplayImage;
	public Text balanceDisplayText; //ship cost in shipPort UI
	public Text costDisplayText; //ship cost in shipPort UI
	public Text hpDisplayText;
	public Text fuelDisplayText;
	public Text supplyDisplayText;
	public Text crewDisplayText;
	public Text speedDisplayText;
	public Text combatModifierText;

	public Text BalanceDisplayText;
	public Text CostDisplayText;
	public Image CurrentCrewDisplayImage;
	public Text CurrentCrewNameDisplayText;
	public Text CurrentCrewCombat;
	public Text CurrentCrewMedical;
	public Text CurrentCrewCharisma;
	public Text CurrentCrewDescription;

	public Image shipHPBar;
	public Image fuelBar;
	public Image supplyBar;
	public Image crewBar;

	private Sprite returnedPicture;
	private Player player;  // to get playerMoney
	private Ship CurrentShip;
	private GameObject Library;

	// public Text hpMaxDisplayText;
	// public Text fuelMaxDisplayText;   
	// public Text supplyMaxDisplayText;   
	// public Text crewMaxDisplayText;

	/* just stats tab */ //not header stats

	//   public Text shieldsDisplayText;
	//   public Text gunDamageDisplayText;
	//   public Text armorDisplayText;
	//   public Text gunCountDisplayText;

	/***************************************Awake Function**************************************************/

   public void Awake() {
		Debug.Log ("Start of Awake in AdjustBarAndStatLevels");

		Library = GameObject.FindGameObjectWithTag("Library");
		playerObj = GameObject.FindGameObjectWithTag("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;
		returnedPicture = Library.GetComponent<ShipLibrary>().GetClipFromName(CurrentShip.shipPicture);

		if (returnedPicture != null && CurrentShipDisplayImage != null) {
			CurrentShipDisplayImage.sprite = returnedPicture;
		}

		if (CurrentShipNameDisplayText != null) {		
			CurrentShipNameDisplayText.text = CurrentShip.shipName.ToString();
		}
			
		/* ship stats tab */
		if(hpDisplayText != null)
		{         
			hpDisplayText.text = CurrentShip.health.ToString ();
			depleteHP(0);
		}

		if (speedDisplayText != null) {
			speedDisplayText.text = CurrentShip.speed.ToString ();
		}

		if(fuelDisplayText != null)
		{
			fuelDisplayText.text = CurrentShip.fuel.ToString ();
			depleteFuel(0);         
		}

		if(crewDisplayText != null)
		{
			crewDisplayText.text = CurrentShip.crewAmt.ToString ();
			depleteCrew(0);
		}

		if(supplyDisplayText != null)
		{
			supplyDisplayText.text = CurrentShip.supplies.ToString ();
			depleteSupply(0);
		}

		//      if(armorDisplayText != null)
		//         armorDisplayText.text = ship.armor.ToString ();
		//      if(gunCountDisplayText != null)
		//         gunCountDisplayText.text = ship.gunCount.ToString ();
		//      if(shieldsDisplayText != null)
		//         shieldsDisplayText.text = ship.shields.ToString ();
		//      if(gunDamageDisplayText != null)
		//         gunDamageDisplayText.text = ship.gunDamage.ToString ();
   }

	/***************************************Update Balance Function**************************************************/

	public void UpdateBalance(){ //used just in header, and when buying ship. updates balance
		Debug.Log ("Update Balance!!!");
		//ship = shipObj.GetComponent<Ship> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

		if (balanceDisplayText != null) {
			 player = playerObj.GetComponent<Player>();
			 balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
		}
	}

	/***************************************Update Text Function**************************************************/

	public void UpdateText(){ //used just in header, and when buying ship. updates balance
		Debug.Log ("Update Text!!!");
		Library = GameObject.FindGameObjectWithTag ("Library");
		//ship = shipObj.GetComponent<Ship> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

      if (balanceDisplayText != null) {
         player = playerObj.GetComponent<Player>();
         balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
      }

 		if(hpDisplayText != null)
		{         
			hpDisplayText.text = CurrentShip.health.ToString ();
			 depleteHP(0);
		}

		if(fuelDisplayText != null)
		{
			fuelDisplayText.text = CurrentShip.fuel.ToString ();
			 depleteFuel(0);         
		}

		if(crewDisplayText != null)
		{
			crewDisplayText.text = CurrentShip.crewAmt.ToString ();
			 depleteCrew(0);
		}

		if(supplyDisplayText != null)
		{
			supplyDisplayText.text = CurrentShip.supplies.ToString ();
			 depleteSupply(0);
		}
	}



	public void depleteHP(int damageCount)
	{
		Debug.Log ("Deplete HP!!!");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

		CurrentShip.health -= damageCount;

		if(CurrentShip.health < 0)
			CurrentShip.health = 0;

		if (shipHPBar != null) {
			shipHPBar.fillAmount = (float)CurrentShip.health / CurrentShip.maxHealth;
			hpDisplayText.text = CurrentShip.health.ToString () + '/' + CurrentShip.maxHealth.ToString();
		}
	}


	public void depleteFuel(int reduceAmt)
	{
		Debug.Log ("Deplete Fuel!!!");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

		CurrentShip.fuel -= reduceAmt;

		if(CurrentShip.fuel < 0)
			CurrentShip.fuel = 0;

		if (fuelBar != null) {
			fuelBar.fillAmount = (float)CurrentShip.fuel / CurrentShip.maxFuel;
			fuelDisplayText.text = CurrentShip.fuel.ToString () + '/' + CurrentShip.maxFuel.ToString();
		}
	}



	public void depleteSupply(int reduceAmt)
	{
		Debug.Log ("Deplete Supply!!!");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

		CurrentShip.supplies -= reduceAmt;

		if(CurrentShip.supplies < 0)
			CurrentShip.supplies = 0;

		if (supplyBar != null) {
			supplyBar.fillAmount = (float)CurrentShip.supplies / CurrentShip.maxSupplies;
			supplyDisplayText.text = CurrentShip.supplies.ToString () + '/' + CurrentShip.maxSupplies.ToString();
		}
	}



	public void depleteCrew(int reduceAmt)
	{
		Debug.Log ("Deplete Crew!!!");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		CurrentShip = player.playerShip;

		CurrentShip.crewAmt -= reduceAmt;

		if(CurrentShip.crewAmt < 0)
			CurrentShip.crewAmt = 0;

		if (shipHPBar != null) {
			crewBar.fillAmount = (float)CurrentShip.crewAmt / CurrentShip.crewCapacity;
			crewDisplayText.text = CurrentShip.crewAmt.ToString () + '/' + CurrentShip.crewCapacity.ToString();
		}
	}      



}

