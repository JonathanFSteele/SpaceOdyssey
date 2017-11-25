using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameSetup : MonoBehaviour {

	private Player player;
	public GameObject StatSheet;
	public GameObject Tutorial;
	public InputField NameInput;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>().GetComponent<Player>();
		//Debug.Log("New Game!! Show StatSheet");
		if(player.newGameTF) {
			StatSheet.SetActive (true);
		}
	}

	public void Accept()
	{
		player.playerCaptain.captainName = NameInput.text;
//		player.playerCaptain.combatBonus = combatInput;
//		player.playerCaptain.charismaBonus = charismaInput;
//		player.playerCaptain.medicalBonus = medicalInput;
		player.newGameTF = false;
		StatSheet.SetActive (false);
		Tutorial.SetActive (true);
	}

	public void activateTutorial(bool value)
	{
		Tutorial.SetActive (value);
	}
}
