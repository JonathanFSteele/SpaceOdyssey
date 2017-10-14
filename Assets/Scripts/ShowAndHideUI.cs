using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Is a class that will hold the show and hiding of menus (Excluding the Encounter Menu Popups)
public class ShowAndHideUI : MonoBehaviour
{
	public Transform newGameMenu;
	public Transform loadGameMenu;
	// public Transform saveGameMenu; //will assign later

	public void ShowNewGameMenuTF(bool value)
	{
		newGameMenu.gameObject.SetActive(value);
	}	

	public void ShowLoadGameMenuTF(bool value)
	{
		loadGameMenu.gameObject.SetActive(value);
	}

}