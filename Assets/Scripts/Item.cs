using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


	public string name; 
	public Sprite itemPicture;

	public bool isPerm;
	public int medicalBonus;
	public int combatBonus;
	public int charsmaBonus;

	// public int amountInStore = -1; //probably won't implement
	public int supplyBonus;
	public string description; 
	public int amountPurchasing = 1;
	public int price;


	public void Use() {
		if (!isPerm) {
			GameObject.Destroy (this);
		}
	}

}
