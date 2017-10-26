﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public bool isPerm;
	public Sprite itemPicture;
	public int medBonus;
	public int combatBonus;
	public int charsmaBonus;


	public void Use() {
		if (!isPerm) {
			GameObject.Destroy (this);
		}
	}

}