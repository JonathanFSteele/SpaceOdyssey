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
}
