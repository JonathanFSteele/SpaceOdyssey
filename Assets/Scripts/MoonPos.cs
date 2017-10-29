using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPos : MonoBehaviour {

	public Vector2[] MoonPosition;
	public int moonStart;
	int moonCont;


	// Use this for initialization
	void Start () {
		moonCont = moonStart;
		transform.localPosition = MoonPosition [moonStart];
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = MoonPosition [moonCont];
	}

	public void MoonMove( int moonPos) {
		transform.localPosition = MoonPosition [moonPos];
	}

	public void NextMoonPos() {
		moonCont = ++moonCont % 8;
		transform.localPosition = MoonPosition [ (moonCont)];
	}

	public int GetMoonPos() {
		return moonCont;
	}
		
}
