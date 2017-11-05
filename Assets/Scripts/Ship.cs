using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Ship : MonoBehaviour {

	public string shipPicture;
	public int maxHealth;
	public int health;
	public int shields;
	public int armor;
	public int speed;
	public int gunCount;
	public int gunDamage;
	public int maxFuel;
	public int fuel;
	public int crewCapacity;
	public int medBonus;
	public int combatBonus;
	public int charsmaBonus;

}
