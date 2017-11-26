using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private Player player;
	private GameObject TutorialUI;
	private GameObject StatSheet;

	void Awake() {
		player = FindObjectOfType<Player>().GetComponent<Player>();
		player.Load(-1);
//		player = FindObjectOfType<Player>();
	}


	// Use this for initialization
	void Start () {
//		UpdateDisplay ();
	}

	public void UpdateDisplay(){
//		Debug.Log("Player Display Updating...");
//		Debug.Log(player.credits);
//		Debug.Log (player.sceneID);
//		Debug.Log (player.encounterIndex);
//		Debug.Log (player.playerCaptain);
	}
}
