using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles: 
//-esc key 

public class EscKey : MonoBehaviour {

	public Transform menuCanvas;  


	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (menuCanvas.gameObject.activeInHierarchy == false){ //if menu isnt up.    
				menuCanvas.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else {
				menuCanvas.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}
		
} //end of script
