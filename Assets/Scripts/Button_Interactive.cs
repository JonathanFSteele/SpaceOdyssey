using UnityEngine;
using System.Collections;
using UnityEngine.UI; // required when using UI elements in scripts

public class Button_Interactive : MonoBehaviour
{
	public Button startButton;
	public bool interactive;

	public void test()
	{
//    if (startButton.interactable == false)
//     startButton.interactable = true;  
//    else
     startButton.interactable = false; 


		// if (interactive == true && startButton.interactable == false)
		// 	startButton.interactable = true;	
		// else
		// 	startButton.interactable = false;	
	}
}