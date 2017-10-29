using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPos : MonoBehaviour {

	public Vector2[] MoonPosition;
	public int moonStart;
	int moonCont;
	float MoonPhaseChange;
	float BetweenMoonPhase = 5;

	// Use this for initialization
	void Start () {
		transform.localPosition = MoonPosition [moonStart];
		moonCont = moonStart;
		MoonPhaseChange = Time.deltaTime * 1/BetweenMoonPhase;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = MoonPosition [moonCont % 8];
	}

	public void MoonMove( int moonPos) {
		transform.localPosition = MoonPosition [moonPos];
	}

	public void NextMoonPos() {
		transform.localPosition = MoonPosition [ (++moonCont) % 8];
	}
		
}
