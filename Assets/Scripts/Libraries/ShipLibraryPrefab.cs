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

		Ship[] ships = groupDictionary ["shop_ships"];

		shipArraySize = ships.Length;
		print ("shipArraySize: " + shipArraySize);
	}


	public Ship getFirstShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] ships = groupDictionary[name]; 
			return ships[0];
		}
		print ("getFirstShip() fail");
		return null;
	}


	public Ship getPreviousShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] ships = groupDictionary[name]; 

			scrollIndex--;
			if (scrollIndex < 0)
			scrollIndex = shipArraySize-1;

			print ("scrollIndex: " + scrollIndex);

			return ships[scrollIndex];
		}
		print ("getPreviousShip() fail");
		return null;
	}


	public Ship getNextShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Ship[] ships = groupDictionary[name]; 

			scrollIndex++;
			if (scrollIndex >= shipArraySize)
			scrollIndex = 0;

			print ("scrollIndex: " + scrollIndex);

			return ships[scrollIndex];
		}
		print ("getNextShip() fail");
		return null;
	}


	[System.Serializable]
	public class Ship_List {
		public string groupID;
		public Ship[] group;
	}
}
