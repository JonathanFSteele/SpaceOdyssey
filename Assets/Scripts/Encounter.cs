using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour {
	
	public enum encFocus {Combat,Medical,Charisma};
	public enum enc2ndFocus {Combat,Medical,Charisma};
	public Sprite enemyPicture;
	public int Medical;
	public int Combat;
	public int Charisma;
	public string prompt;


}
