using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour {

  public Player player;
  public Ship playerShip;
  public Ship noShip;
  public int initialCredits;



	void Start () {

    player.credits = initialCredits;
    // playerShip = noShip; DOESNT WORK this way

    playerShip.shipPicture = noShip.shipPicture;
    playerShip.shipName = noShip.shipName;
    playerShip.maxHealth = noShip.maxHealth;
    // if(playerShip.health > noShip.maxHealth)
      playerShip.health = noShip.maxHealth;
//    playerShip.shields = noShip.shields;
//    playerShip.armor = noShip.armor;
    playerShip.speed = noShip.speed;
//    playerShip.gunCount = noShip.gunCount;
//    playerShip.gunDamage = noShip.gunDamage;
    playerShip.maxFuel = noShip.maxFuel;
    playerShip.fuelEfficiency = noShip.fuelEfficiency;
    // if(playerShip.fuel > noShip.maxFuel)
      playerShip.fuel = noShip.maxFuel;
    playerShip.crewCapacity = noShip.crewCapacity;
    // if(playerShip.crewAmt > noShip.crewCapacity)
      playerShip.crewAmt = noShip.crewCapacity;
    playerShip.maxSupplies = noShip.maxSupplies;
    // if(playerShip.supplies > noShip.maxSupplies)
      playerShip.supplies = noShip.maxSupplies;
    // playerShip.medicalBonus = noShip.medicalBonus;
    // playerShip.combatBonus = noShip.combatBonus;
    // playerShip.charsmaBonus = noShip.charsmaBonus;    
		
	}
	
 
}
