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
	public Transform MenuUI;  
	public Transform MapUI;
	public Transform ShipUI;
	public Transform LogUI;
	public Transform CrewUI;
	public Transform OptionsUI;

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

	public void ShowMapTF(bool value)
	{
		NewSaveGameUI.gameObject.SetActive(value);
	}

	public void ShowShipTF(bool value)
	{
		ShipUI.gameObject.SetActive(value);
	}

	public void ShowCrewTF(GameObject Canvas_Crew)
	{
        Canvas_Crew.SetActive(!Canvas_Crew.activeSelf);
    }

    public void ShowCrewPG(GameObject Character_Page)
    {
        Character_Page.SetActive(!Character_Page.activeSelf);
    }

	public void ShowLogTF(GameObject  Canvas_Log)
	{
        Canvas_Log.SetActive(!Canvas_Log.activeSelf);
    }

	public void ShowOptionsTF(bool value)
	{
		OptionsUI.gameObject.SetActive(value);
	}
}