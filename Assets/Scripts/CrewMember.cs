using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class CrewMember : MonoBehaviour {

	public string crewPicture;
	public int medicalBonus;
	public int combatBonus;
	public int charsmaBonus;
	public int[] traits;
	public string description;

	public void Die(){
		GameObject.Destroy (this);
	}
}
