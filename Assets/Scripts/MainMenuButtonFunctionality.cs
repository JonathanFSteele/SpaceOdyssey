using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonFunctionality : MonoBehaviour {

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
