using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonFunctionality : MonoBehaviour {

	public Transform OverwritePopup;
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
			//NewGame Functionality
			SceneManager.LoadScene ("Safezone");
		} else {
			//Cancel Save
			OverwritePopup.gameObject.SetActive(false);
		}
	}

	public void LoadGame()
	{
		Debug.Log ("Loading Game on Game Slot: " + CurrentSelectedSlot);
		//Load Functionality
		SceneManager.LoadScene ("Safezone");
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
			Debug.Log("Quitting Game...");
			Application.Quit ();
		} else {
			ExitGameMenu.gameObject.SetActive(false);
		}
	}
}
