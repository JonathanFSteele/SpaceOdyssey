using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonFunctionality : MonoBehaviour {

	public Transform OverwritePopup;
	public Transform BackToMainMenuPopUp;
	private int CurrentSelectedSlot;

	public Button BtnLoad1;
	public Button BtnLoad2;
	public Button BtnLoad3;
	public Button BtnLoad4;

	public Button BtnSave1;
	public Button BtnSave2;
	public Button BtnSave3;
	public Button BtnSave4;

	public void overwriteGamePopup(int saveSpaceNumber)
	{
		//Show "Are you sure?" Popup "Yes" or "No"
		CurrentSelectedSlot = saveSpaceNumber;
		OverwritePopup.gameObject.SetActive(true);
	}

	public void SaveGame(int CurrentSelectedSlot)
	{
		Player player = FindObjectOfType<Player>().GetComponent<Player>();
		player.Save (CurrentSelectedSlot);
	}

	public void NewGame(bool value)
	{
		Debug.Log ("Are you allowing a new Game?: " + value);
		if (value == true) {
			Debug.Log ("Starting New Game on Game Slot: " + CurrentSelectedSlot);
			Player player = FindObjectOfType<Player>().GetComponent<Player>();
			player.Save (CurrentSelectedSlot);
			//NewGame Functionality
			SceneManager.LoadScene ("Safezone");
		} else {
			//Cancel Save
			OverwritePopup.gameObject.SetActive(false);
		}
	}

	public void InGameLoadSave(int value)
	{
		Debug.Log ("Loading Game on Game Slot: " + value);
		Player player = FindObjectOfType<Player>().GetComponent<Player>();
		player.Load (value);
		//SceneManager.LoadScene ("Safezone"); //Change scene based on id stored in Player Object being Loaded
	}

	public void LoadGame(int value)
	{
		Debug.Log ("Loading Game on Game Slot: " + value);
		Player player = FindObjectOfType<Player>().GetComponent<Player>();
		player.Load (value);
		//Load Functionality
		if (player.sceneID == 1) { //Player in Safezone
			SceneManager.LoadScene ("Safezone");
		} else if (player.sceneID == 2) { //Player is in Encounter
			SceneManager.LoadScene ("Encounter");
		}
	}

	public void MainMenu()
	{
		BackToMainMenuPopUp.gameObject.SetActive(true);
	}

	public void BackToMainMenu(bool value)
	{
		if (value == true) {
			//Save Game Functionality Goes Here...
			Player player = FindObjectOfType<Player>().GetComponent<Player>();
			player.Load(-1);
			SceneManager.LoadScene ("MainMenu");
		} else {
			BackToMainMenuPopUp.gameObject.SetActive(false);
		}
	}
		
	// *****************************************************
	// Exit Game Functionality Below
	// *****************************************************

	public Transform ExitGameMenu;

	public void ShowExitGame()
	{
		//Show "Are you sure?" Popup "Yes" or "No"
		ExitGameMenu.gameObject.SetActive(true);
	}

	public void ExitGameChoice(bool value)
	{
		//if Yes
		if (value == true) {
			//Save Game Functionality Goes Here...
			Debug.Log("Quitting Game...");
			Application.Quit ();
		} else {
			ExitGameMenu.gameObject.SetActive(false);
		}
	}

	public void InitializeSaveData()
	{
		PlayerData player1 = SaveAndLoadManager.LoadPlayer (1);
		PlayerData player2 = SaveAndLoadManager.LoadPlayer (2);
		PlayerData player3 = SaveAndLoadManager.LoadPlayer (3);
		PlayerData player4 = SaveAndLoadManager.LoadPlayer (4);

		GameObject SaveSlot1 = GameObject.FindWithTag("SaveSlot1");
		GameObject SaveSlot2 = GameObject.FindWithTag("SaveSlot2");
		GameObject SaveSlot3 = GameObject.FindWithTag("SaveSlot3");
		GameObject SaveSlot4 = GameObject.FindWithTag("SaveSlot4");

		if (player1 != null) {
			SaveSlot1.GetComponent<UnityEngine.UI.Text>().text = player1.playerCaptain.captainName + " (Time: "
				+ player1.TimePassedSinceStart + " ED | Distance: " + player1.TotalDistanceTraveled + " Mi)";
		} else {
			SaveSlot1.GetComponent<UnityEngine.UI.Text>().text = "Empty";
		}
		if (player2 != null) {
			SaveSlot2.GetComponent<UnityEngine.UI.Text>().text = player2.playerCaptain.captainName + " (Time: "
				+ player2.TimePassedSinceStart + " ED | Distance: " + player2.TotalDistanceTraveled + " Mi)";
		} else {
			SaveSlot2.GetComponent<UnityEngine.UI.Text>().text = "Empty";
		}
		if (player3 != null) {
			SaveSlot3.GetComponent<UnityEngine.UI.Text>().text = player3.playerCaptain.captainName + " (Time: "
				+ player3.TimePassedSinceStart + " ED | Distance: " + player3.TotalDistanceTraveled + " Mi)";
		} else {
			SaveSlot3.GetComponent<UnityEngine.UI.Text>().text = "Empty";
		}
		if (player4 != null) {
			SaveSlot4.GetComponent<UnityEngine.UI.Text>().text = player4.playerCaptain.captainName + " (Time: "
				+ player4.TimePassedSinceStart + " ED | Distance: " + player4.TotalDistanceTraveled + " Mi)";
		} else {
			SaveSlot4.GetComponent<UnityEngine.UI.Text>().text = "Empty";
		}
	}

	public void InitializeLoadData()
	{
		PlayerData player1 = SaveAndLoadManager.LoadPlayer (1);
		PlayerData player2 = SaveAndLoadManager.LoadPlayer (2);
		PlayerData player3 = SaveAndLoadManager.LoadPlayer (3);
		PlayerData player4 = SaveAndLoadManager.LoadPlayer (4);

		GameObject LoadSlot1 = GameObject.FindWithTag("LoadSlot1");
		GameObject LoadSlot2 = GameObject.FindWithTag("LoadSlot2");
		GameObject LoadSlot3 = GameObject.FindWithTag("LoadSlot3");
		GameObject LoadSlot4 = GameObject.FindWithTag("LoadSlot4");

		if (player1 != null) {
			LoadSlot1.GetComponent<UnityEngine.UI.Text> ().text = player1.playerCaptain.captainName + " (Time: "
				+ player1.TimePassedSinceStart + " ED | Distance : " + player1.TotalDistanceTraveled + " Mi)";
		} else {
			LoadSlot1.GetComponent<UnityEngine.UI.Text>().text = "Empty";
			//LoadSlot1.GetComponent<UnityEngine.UI.Button>().interactable = false;
			BtnLoad1.interactable = false;
		}
		if (player2 != null) {
			LoadSlot2.GetComponent<UnityEngine.UI.Text> ().text = player2.playerCaptain.captainName + " (Time: "
				+ player2.TimePassedSinceStart + " ED | Distance: " + player2.TotalDistanceTraveled + " Mi)";
		} else {
			LoadSlot2.GetComponent<UnityEngine.UI.Text>().text = "Empty";
			//LoadSlot2.GetComponent<UnityEngine.UI.Button>().interactable = false;
			BtnLoad2.interactable = false;
		}
		if (player3 != null) {
			LoadSlot3.GetComponent<UnityEngine.UI.Text> ().text = player3.playerCaptain.captainName + " (Time: "
				+ player3.TimePassedSinceStart + " ED | Distance: " + player3.TotalDistanceTraveled + " Mi)";
		} else {
			LoadSlot3.GetComponent<UnityEngine.UI.Text>().text = "Empty";
			//LoadSlot3.GetComponent<UnityEngine.UI.Button>().interactable = false;
			BtnLoad3.interactable = false;
		}
		if (player4 != null) {
			LoadSlot4.GetComponent<UnityEngine.UI.Text> ().text = player4.playerCaptain.captainName + " (Time: "
				+ player4.TimePassedSinceStart + " ED | Distance: " + player4.TotalDistanceTraveled + " Mi)";
		} else {
			LoadSlot4.GetComponent<UnityEngine.UI.Text>().text = "Empty";
			//LoadSlot4.GetComponent<UnityEngine.UI.Button>().interactable = false;
			BtnLoad4.interactable = false;
		}
	}

	public void DeleteAllData()
	{
		Debug.Log ("Resetting All Data");
		//SaveAndLoadManager.DeleteFile(0);
		SaveAndLoadManager.DeleteFile(1);
		SaveAndLoadManager.DeleteFile(2);
		SaveAndLoadManager.DeleteFile(3);
		SaveAndLoadManager.DeleteFile(4);
	}
}
