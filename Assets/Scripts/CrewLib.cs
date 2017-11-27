using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class CrewLib : MonoBehaviour {

	public Transform CrewMemberParent;
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

		for (int i=0; i < player.playerCrew.Length; i++) {
			Debug.Log("Destroy: " + i);
			Destroy(GameObject.Find("Row(Clone)"+i));
		}

		CrewList = player.playerCrew;
		//Image currentImage = null;
		String currentName = "";
		String currentStats = " |Comb:  |Char:  |Medi:";
		for (int i = 0; i < CrewList.Length; i++) {
			returnedPicture = library.GetComponent<CrewPictureLibrary>().GetClipFromName(CrewList[i].CrewImage);
			currentName = CrewList [i].CrewName;
			currentStats = " |Comb: " + CrewList [i].Combat + " |Char: " + CrewList [i].Charisma + " |Medi: " + CrewList [i].Medicine;

			Transform NewRow = Instantiate (CrewMemberRow, CrewMemberRow.transform.position , Quaternion.identity);
			NewRow.GetChild (0).GetChild(0).GetComponent<Text>().text = currentStats;
			NewRow.GetChild (0).GetChild (1).GetComponent<Image> ().sprite = returnedPicture;
			NewRow.transform.parent = CrewMemberParent;
			NewRow.gameObject.SetActive(true);
			NewRow.transform.localScale = CrewMemberRow.transform.localScale;
			NewRow.transform.name = "Row(Clone)" + i;
		}
	}

//	public void clickCrewMember()
//	{
//		
//
//
//		selectCrewMember(value);
//	}
//
//	public void selectCrewMember(int i)
//	{
//
//	}
}
