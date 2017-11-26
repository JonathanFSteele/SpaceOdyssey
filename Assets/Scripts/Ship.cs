using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


[Serializable]
public class Ship : MonoBehaviour {

	public int shipPrice; //how much it costs in the store

	public Sprite shipPicture;
	public String shipName;
	public int maxHealth;
	public int health;
	public int speed;
	public int maxFuel;
	public int fuelEfficiency;
	public int fuel;
	public int crewCapacity;
	public int crewAmt; //present amount of crew members
	public int maxSupplies;
	public int supplies;
	public int combatBonus;

	//Out of Scope --JFS
	//public int charsmaBonus;
	//public int medicalBonus;
	//public int shields;
	//public int armor;
	//public int gunCount;
	//public int gunDamage;

}
