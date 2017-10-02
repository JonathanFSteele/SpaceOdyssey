using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Called in beginning of game, and when exited out of the menu
//Prevent all canvas' that show after clicking menu buttons 
public class HidePopUpMenus : MonoBehaviour
{
  public Transform newGameMenu;
  // public Transform loadGameMenu; //will assign later
  // public Transform saveGameMenu; //will assign later
  
	void Start()
	{
    newGameMenu.gameObject.SetActive(false);
    // loadGameMenu.gameObject.SetActive(false);
    // saveGameMenu.gameObject.SetActive(false);
	}

	public void hideMenu()
	{
    Start();    

    //why doesnt this work without attaching canvas to component in unity?
    // HidePopUpMenus hideMenus = GetComponentInParent<HidePopUpMenus>();    
    // hideMenus.Start(); //or
    // hideMenus.gameObject.SetActive(false);
	}

}