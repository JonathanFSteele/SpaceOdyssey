using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class AdjustBarAndStatLevels : MonoBehaviour
{  
   public GameObject playerObj; 
   private Player player;  // to get playerMoney

   public GameObject shipObj;
	private Ship ship;
   public Text shipNameDisplayText;
   public Image shipPicture;

   public Text balanceDisplayText; //ship cost in shipPort UI
   public Text costDisplayText; //ship cost in shipPort UI
   public Text hpDisplayText;
   public Text fuelDisplayText;
   public Text supplyDisplayText;
   public Text crewDisplayText;
   // public Text hpMaxDisplayText;
   // public Text fuelMaxDisplayText;   
   // public Text supplyMaxDisplayText;   
   // public Text crewMaxDisplayText;

   /* just stats tab */ //not header stats
   public Text speedDisplayText;
   public Text shieldsDisplayText;
   public Text gunDamageDisplayText;
   public Text armorDisplayText;
   public Text gunCountDisplayText;

   public Image shipHPBar;
   public Image fuelBar;
   public Image supplyBar;
   public Image crewBar;


   public void Start() {
		ship = shipObj.GetComponent<Ship> ();		


       if (shipPicture != null)
          // shipNameDisplayText.text = ship.shipName.ToString ();
         shipPicture.sprite = ship.shipPicture;

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



	public void UpdateText(){ //used just in header, and when buying ship. updates balance
		ship = shipObj.GetComponent<Ship> ();	



      if (balanceDisplayText != null) {
         player = playerObj.GetComponent<Player>();
         balanceDisplayText.text = "  Balance: " + player.credits.ToString () + " £";
      }

 		if(hpDisplayText != null)
		{         
			hpDisplayText.text = ship.health.ToString ();
			 depleteHP(0);print("test2");
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
      ship = shipObj.GetComponent<Ship> ();     		

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
      ship = shipObj.GetComponent<Ship> ();           

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
      ship = shipObj.GetComponent<Ship> ();           

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
      ship = shipObj.GetComponent<Ship> ();           

      ship.crewAmt -= reduceAmt;

      if(ship.crewAmt < 0)
         ship.crewAmt = 0;

      if (shipHPBar != null) {
         crewBar.fillAmount = (float)ship.crewAmt / ship.crewCapacity;
         crewDisplayText.text = ship.crewAmt.ToString () + '/' + ship.crewCapacity.ToString();
      }
   }      



}

