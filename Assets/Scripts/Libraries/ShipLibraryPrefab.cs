using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLibraryPrefab : MonoBehaviour {

	// public GameObject test1;

	public Ship_List[] shipList;
	// public Sprite displayImage;

	public int scrollIndex = 0;
	public int shipArraySize;

	Dictionary<string, Ship[]> groupDictionary = new Dictionary<string, Ship[]>();

	void Awake() {
		foreach (Ship_List foo in shipList) {
			groupDictionary.Add (foo.groupID, foo.group);
		}

		Ship[] sounds = groupDictionary ["shop_ships"];
			
		shipArraySize = sounds.Length;
		print ("shipArraySize: " + shipArraySize);
	}


	public Sprite getFirstShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] sounds = groupDictionary[name]; 
			return sounds[0].shipPicture;
		}
		print ("getFirstShip() fail");
		return null;
	}



	public Sprite getNextShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] sounds = groupDictionary[name]; 

			scrollIndex++;
			if (scrollIndex >= shipArraySize)
				scrollIndex = 0;

			print ("scrollIndex: " + scrollIndex);

			return sounds[scrollIndex].shipPicture;
		}
		print ("getNextShip() fail");
		return null;
	}


	public Sprite getPreviousShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] sounds = groupDictionary[name]; 

			scrollIndex--;
			if (scrollIndex < 0)
				scrollIndex = shipArraySize-1;

			print ("scrollIndex: " + scrollIndex);

			return sounds[scrollIndex].shipPicture;
		}
		print ("getPreviousShip() fail");
		return null;
	}



 
	[System.Serializable]
	public class Ship_List {
		public string groupID;
		public Ship[] group;
	}
}
