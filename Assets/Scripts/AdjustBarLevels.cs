using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class AdjustBarLevels : MonoBehaviour
{
   public Player player;

   public Text hpDisplayText;
   public Text fuelDisplayText;
   public Text supplyDisplayText;
   public Text crewDisplayText;

   public Image shipHPBar;
   public Image fuelBar;
   public Image supplyBar;
   public Image crewBar;


   void Start() {
      // print("AdjustBarLevels 2.0 UP!!");

      depleteHP(0);
      depleteFuel(0);
      depleteSupply(0);
      depleteCrew(0);

   }



   public void depleteHP(int damageCount)
   {
      Ship ship = player.GetComponentInChildren<Ship> ();		

      ship.health -= damageCount;

      if(ship.health < 0)
         ship.health = 0;

      if (shipHPBar != null) {
         shipHPBar.fillAmount = (float)ship.health / ship.maxHealth;
         hpDisplayText.text = ship.health.ToString ();
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
         fuelDisplayText.text = ship.fuel.ToString ();
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
         supplyDisplayText.text = ship.supplies.ToString ();
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
         crewDisplayText.text = ship.crewAmt.ToString ();
      }
   }      



}

