using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Mission : MonoBehaviour {

//    public string Mission1 = "x";
//    public string Mission2 = "x";
//    public string Mission3 = "x";

	public Transform MissionControlUI;

//    public Text m1;
//    public Text m2;
//    public Text m3;

    // Update is called once per frame
    void Update () {

//        m1.text = Mission1;
//        m2.text = Mission2;
//        m3.text = Mission3;

	}

	public void activateMissionControlTF(bool value)
	{
		MissionControlUI.gameObject.SetActive(value);
	}

}
