using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipObjLibrary : MonoBehaviour {

	public ImageGroup[] ShipList;
	private int scrollIndex = 0;
	public int shipArraySize;

	Dictionary<int, Ship[]> groupDictionary = new Dictionary<int, Ship[]>();

	void Awake() {
		foreach (ImageGroup imageGroup in ShipList) {
			groupDictionary.Add (imageGroup.groupID, imageGroup.group);
		}

		Ship[] ships = groupDictionary[0];

		shipArraySize = ships.Length;

	}

	public Ship GetClipFromId(int id) {
		if (groupDictionary.ContainsKey(id)) {
			Ship[] ship = groupDictionary[id];
			return ship[0];
		}
		return null;
	}

	public Ship GetRandomClipFromId(int id) {
		if (groupDictionary.ContainsKey(id)) {
			Ship[] ship = groupDictionary[id];
			return ship[Random.Range(0,ship.Length)];
		}
		// print ("GetRandomClipFromName() fail");
		return null;
	}
		
	public Ship buyCurrentShip(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Ship[] ships = groupDictionary[id]; 
			// print ("buy: " + scrollIndex);

			return ships[scrollIndex];
		}
		// print ("buyCurrentShip() fail");
		return null;
	}


	public Ship getFirstShip(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Ship[] ships = groupDictionary[id]; 
			return ships[0];
		}
		// print ("getFirstShip() fail");
		return null;
	}


	public Ship getPreviousShip(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Ship[] ships = groupDictionary[id]; 

			scrollIndex--;
			if (scrollIndex < 0)
				scrollIndex = shipArraySize-1;

			// print ("scrollIndex: " + scrollIndex);

			return ships[scrollIndex];
		}
		// print ("getPreviousShip() fail");
		return null;
	}


	public Ship getNextShip(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Ship[] ships = groupDictionary[id]; 

			scrollIndex++;
			if (scrollIndex >= shipArraySize)
				scrollIndex = 0;

			// print ("scrollIndex: " + scrollIndex);

			return ships[scrollIndex];
		}
		// print ("getNextShip() fail");
		return null;
	}

	[System.Serializable]
	public class ImageGroup {
		public int groupID;
		public Ship[] group;
	}
}
