using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class CrewLib : MonoBehaviour {

	public Transform CrewMemberRow;

	private GameObject library;
	private GameObject playerObj;
	private Player player;
	public Crew[] CrewList;
    public Sprite CrewImage;
	public Sprite returnedPicture;

	public void loadCurrentCrewList()
	{
		library = GameObject.FindGameObjectWithTag ("Library");
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();


		CrewList = player.playerCrew;
		Image currentImage = null;
		String currentName = "";
		String currentStats = " |Comb:  |Char:  |Medi:";
		for (int i = 0; i < CrewList.Length; i++) {
			returnedPicture = library.GetComponent<CrewPictureLibrary>().GetClipFromName(CrewList[i].CrewImage);
			currentImage.sprite = returnedPicture;
			currentName = CrewList [i].CrewName;
			currentStats = " |Comb: " + CrewList [i].Combat + " |Char: " + CrewList [i].Charisma + " |Medi: " + CrewList [i].Medicine;

			Instantiate(CrewMemberRow, CrewMemberRow.transform.position, CrewMemberRow.transform.rotation);
		}
	}
}
