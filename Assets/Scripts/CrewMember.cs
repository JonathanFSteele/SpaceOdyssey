using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour {

	public Sprite crewPicture;
	public int medBonus;
	public int combatBonus;
	public int charsmaBonus;
	public int[] traits;
	public string description;

	public void Die(){
		GameObject.Destroy (this);
	}
}
