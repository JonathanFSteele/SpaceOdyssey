using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//handles: 
//-resume + menu buttons

//Is a class that will hold the show and hiding of menus (Excluding the Encounter Menu Popups)
public class ShowAndHideUI : MonoBehaviour
{
	public Transform NewSaveGameUI;
	public Transform LoadGameUI;
	public Transform ShipStatsUI;
	public Transform MenuUI;  

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (MenuUI.gameObject.activeInHierarchy == false){ //if menu isnt up.    
				MenuUI.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else {
				MenuUI.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}


	public void ShowNewAndSaveGameMenuTF(bool value)
	{
		NewSaveGameUI.gameObject.SetActive(value);
	}

	public void ShowLoadGameMenuTF(bool value)
	{
		LoadGameUI.gameObject.SetActive(value);
	}

	public void ShowMenuTF(bool value)
	{
		MenuUI.gameObject.SetActive(value);
	}

	public void ShowShipStatsTF(bool value)
	{
		ShipStatsUI.gameObject.SetActive(value);
	}

}