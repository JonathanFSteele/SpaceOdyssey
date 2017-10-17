using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR HIDING TRANSLUCENT NON GREY SHIP BACKGROUND

public class hgdfxfg : MonoBehaviour {

	public Transform canvas;  
	public Transform hideUIcanvas;
	//	public Transform hideUIcanvasChild; 23.42
	private GameObject parent;// = transform.parent.gameObject;


	void Start(){
		parent = hideUIcanvas.parent.gameObject;
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			//20.90004
			if (canvas.gameObject.activeInHierarchy == false){		    
				canvas.gameObject.SetActive(true);
				Time.timeScale = 1;
				if (parent.activeSelf == true)
					hideUIcanvas.gameObject.SetActive(false);			
			}

			else {
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
				if (parent.activeSelf == true)
					hideUIcanvas.gameObject.SetActive(true);	
			}

		}
	}


	public void hitMenuButton () {
			if (canvas.gameObject.activeInHierarchy == false){		    
				canvas.gameObject.SetActive(true);
				Time.timeScale = 1;

			parent = hideUIcanvas.parent.gameObject;

				if (parent.activeSelf == true)
					hideUIcanvas.gameObject.SetActive(false);			
			}


		}


	public void hitResumeButton () {
			canvas.gameObject.SetActive(false);
			Time.timeScale = 1;

			parent = hideUIcanvas.parent.gameObject;

			if (parent.activeSelf == true)
				hideUIcanvas.gameObject.SetActive(true);			


		}
	 
} //end of script
