using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPath : MonoBehaviour {

	public GameObject[] moonPath = new GameObject[8];

	GameObject target;

	// Use this for initialization
	void Start () {
	    target = GameObject.Find("Moon 1");
		TurnOff ();
		if (target != null)
			SetPath (target.GetComponent<MoonPos>().GetMoonPos());
	}
	
	// Update is called once per frame
	void Update () {
		TurnOff ();
		if (target != null)
			SetPath (target.GetComponent<MoonPos>().GetMoonPos());
	}

	public void TurnOff(){
		for (int i = 0; i < 8; i++)
			moonPath [i].SetActive (false);
	}

	public void SetPath( int path) {
		moonPath [path].SetActive (true);
	}
}
