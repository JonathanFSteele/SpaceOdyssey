using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Show specific sub-menu after clicking menu button options
/// </summary>
public class ShowSubMenusScript : MonoBehaviour
{
	public Transform newGameMenu;
	public Transform loadGameMenu;


	public void ShowNewGameMenu()
	{
		newGameMenu.gameObject.SetActive(true);
	}	

	public void ShowLoadGameMenu()
	{
		loadGameMenu.gameObject.SetActive(true);
	}

}