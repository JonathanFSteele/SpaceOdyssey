using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class Mission {

	public string MissionName;
	public int StartLocationID;
	public bool StartLocationReached;
	public int EndLocationID;
	public bool EndLocationReached;
	public string Description;
	public int RewardCredits;



}
