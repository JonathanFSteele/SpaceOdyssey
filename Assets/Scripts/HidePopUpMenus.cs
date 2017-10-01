using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//SCRIPT PROBABLY ISNT NECESSARY

//Prevent all canvas' that show after clicking menu buttons 
public class HidePopUpMenus : MonoBehaviour
{
	public Transform newGameMenu;
  
	void Start()
	{
		newGameMenu.gameObject.SetActive(false);
	}

}