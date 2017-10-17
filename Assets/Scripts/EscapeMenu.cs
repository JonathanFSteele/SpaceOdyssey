using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour {

	public Transform canvas;	

	public Transform hideSafeZoneUIcanvas;

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {

			if (hideSafeZoneUIcanvas.gameObject.activeSelf == true)
				hideSafeZoneUIcanvas.gameObject.SetActive(false);

			if (canvas.gameObject.activeInHierarchy == false){
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
			}

			else {
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
			}

		}
	}
}
