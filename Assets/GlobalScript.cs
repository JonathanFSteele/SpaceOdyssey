using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}