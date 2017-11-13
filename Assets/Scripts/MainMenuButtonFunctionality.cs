using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonFunctionality : MonoBehaviour {

	public Transform OverwritePopup;
	public Transform BackToMainMenuPopUp;
	private int CurrentSelectedSlot;

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
		SceneManager.LoadScene ("Safezone");
	}

	public void MainMenu()
	{
		BackToMainMenuPopUp.gameObject.SetActive(true);
	}

	public void BackToMainMenu(bool value)
	{
		if (value == true) {
			//Save Game Functionality Goes Here...
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
		PlayerData player1 = SaveAndLoadManager.LoadPlayer (0);
		PlayerData player2 = SaveAndLoadManager.LoadPlayer (1);
		PlayerData player3 = SaveAndLoadManager.LoadPlayer (2);
		PlayerData player4 = SaveAndLoadManager.LoadPlayer (3);

		GameObject SaveSlot1 = GameObject.FindWithTag("SaveSlot1");
		GameObject SaveSlot2 = GameObject.FindWithTag("SaveSlot2");
		GameObject SaveSlot3 = GameObject.FindWithTag("SaveSlot3");
		GameObject SaveSlot4 = GameObject.FindWithTag("SaveSlot4");

		SaveSlot1.GetComponent<UnityEngine.UI.Text>().text = player1.playerCaptain.captainName;
		SaveSlot2.GetComponent<UnityEngine.UI.Text>().text = player2.playerCaptain.captainName;
		SaveSlot3.GetComponent<UnityEngine.UI.Text>().text = player3.playerCaptain.captainName;
		SaveSlot4.GetComponent<UnityEngine.UI.Text>().text = player4.playerCaptain.captainName;
	}

	public void InitializeLoadData()
	{
		PlayerData player1 = SaveAndLoadManager.LoadPlayer (0);
		PlayerData player2 = SaveAndLoadManager.LoadPlayer (1);
		PlayerData player3 = SaveAndLoadManager.LoadPlayer (2);
		PlayerData player4 = SaveAndLoadManager.LoadPlayer (3);

		GameObject LoadSlot1 = GameObject.FindWithTag("LoadSlot1");
		GameObject LoadSlot2 = GameObject.FindWithTag("LoadSlot2");
		GameObject LoadSlot3 = GameObject.FindWithTag("LoadSlot3");
		GameObject LoadSlot4 = GameObject.FindWithTag("LoadSlot4");

		LoadSlot1.GetComponent<UnityEngine.UI.Text>().text = player1.playerCaptain.captainName;
		LoadSlot2.GetComponent<UnityEngine.UI.Text>().text = player2.playerCaptain.captainName;
		LoadSlot3.GetComponent<UnityEngine.UI.Text>().text = player3.playerCaptain.captainName;
		LoadSlot4.GetComponent<UnityEngine.UI.Text>().text = player4.playerCaptain.captainName;
	}
}
