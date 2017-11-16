using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class AdjustBarAndStatLevels : MonoBehaviour
{
	public GameObject player;
	Ship ship;

   public Text shipNameDisplayText;
   public Image shipPicture;

   public Text hpDisplayText;
   public Text fuelDisplayText;
   public Text supplyDisplayText;
   public Text crewDisplayText;
   // public Text hpMaxDisplayText;
   // public Text fuelMaxDisplayText;   
   // public Text supplyMaxDisplayText;   
   // public Text crewMaxDisplayText;

   /* just stats tab */
   public Text speedDisplayText;
   public Text shieldsDisplayText;
   public Text gunDamageDisplayText;
   public Text armorDisplayText;
   public Text gunCountDisplayText;

   public Image shipHPBar;
   public Image fuelBar;
   public Image supplyBar;
   public Image crewBar;


   void Start() {

		player = GameObject.FindGameObjectWithTag ("Player");

	    ship = player.GetComponentInChildren<Ship> ();		

      if (shipNameDisplayText != null)
         shipNameDisplayText.text = ship.shipName.ToString ();

      /* ship stats tab */
      if(hpDisplayText != null)
      {         
         hpDisplayText.text = ship.health.ToString ();
         depleteHP(0);
      }

      if(speedDisplayText != null)
         speedDisplayText.text = ship.speed.ToString ();
      if(shieldsDisplayText != null)
         shieldsDisplayText.text = ship.shields.ToString ();
      if(gunDamageDisplayText != null)
         gunDamageDisplayText.text = ship.gunDamage.ToString ();
      if(fuelDisplayText != null)
      {
         fuelDisplayText.text = ship.fuel.ToString ();
         depleteFuel(0);         
      }
      if(armorDisplayText != null)
         armorDisplayText.text = ship.armor.ToString ();
      if(gunCountDisplayText != null)
         gunCountDisplayText.text = ship.gunCount.ToString ();
      if(crewDisplayText != null)
      {
         crewDisplayText.text = ship.crewAmt.ToString ();
         depleteCrew(0);
      }
      if(supplyDisplayText != null)
      {
         supplyDisplayText.text = ship.supplies.ToString ();
         depleteSupply(0);
      }
      

   }

	public void UpdateText(){

		player = GameObject.FindGameObjectWithTag ("Player");


		ship = player.GetComponentInChildren<Ship> ();


		if(hpDisplayText != null)
		{         
			hpDisplayText.text = ship.health.ToString ();
			 depleteHP(0);
		}

		if(fuelDisplayText != null)
		{
			fuelDisplayText.text = ship.fuel.ToString ();
			 depleteFuel(0);         
		}

		if(crewDisplayText != null)
		{
			crewDisplayText.text = ship.crewAmt.ToString ();
			 depleteCrew(0);
		}

		if(supplyDisplayText != null)
		{
			supplyDisplayText.text = ship.supplies.ToString ();
			 depleteSupply(0);
		}

	}



   public void depleteHP(int damageCount)
   {
      Ship ship = player.GetComponentInChildren<Ship> ();		

      ship.health -= damageCount;

      if(ship.health < 0)
         ship.health = 0;

      if (shipHPBar != null) {
         shipHPBar.fillAmount = (float)ship.health / ship.maxHealth;
         hpDisplayText.text = ship.health.ToString () + '/' + ship.maxHealth.ToString();
      }
   }


   public void depleteFuel(int reduceAmt)
   {
      Ship ship = player.GetComponentInChildren<Ship> ();      

      ship.fuel -= reduceAmt;

      if(ship.fuel < 0)
         ship.fuel = 0;

      if (fuelBar != null) {
         fuelBar.fillAmount = (float)ship.fuel / ship.maxFuel;
         fuelDisplayText.text = ship.fuel.ToString () + '/' + ship.maxFuel.ToString();
      }
   }



   public void depleteSupply(int reduceAmt)
   {
      Ship ship = player.GetComponentInChildren<Ship> ();      

      ship.supplies -= reduceAmt;

      if(ship.supplies < 0)
         ship.supplies = 0;

      if (supplyBar != null) {
         supplyBar.fillAmount = (float)ship.supplies / ship.maxSupplies;
         supplyDisplayText.text = ship.supplies.ToString () + '/' + ship.maxSupplies.ToString();
      }
   }



   public void depleteCrew(int reduceAmt)
   {
      Ship ship = player.GetComponentInChildren<Ship> ();      

      ship.crewAmt -= reduceAmt;

      if(ship.crewAmt < 0)
         ship.crewAmt = 0;

      if (shipHPBar != null) {
         crewBar.fillAmount = (float)ship.crewAmt / ship.crewCapacity;
         crewDisplayText.text = ship.crewAmt.ToString () + '/' + ship.crewCapacity.ToString();
      }
   }      



}

