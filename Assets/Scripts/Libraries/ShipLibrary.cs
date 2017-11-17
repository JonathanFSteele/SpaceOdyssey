using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLibrary : MonoBehaviour {

	public ImageGroup[] imageGroups;
	public Sprite displayImage;

	public int scrollIndex = 0;
	public int shipArraySize;

	Dictionary<string, Sprite[]> groupDictionary = new Dictionary<string, Sprite[]>();

	void Awake() {
		foreach (ImageGroup imageGroup in imageGroups) {
			groupDictionary.Add (imageGroup.groupID, imageGroup.group);
		}

		Sprite[] sounds = groupDictionary ["shop_ships"];
			
		shipArraySize = sounds.Length;
		print ("shipArraySize: " + shipArraySize);
	}


	public Sprite getFirstShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Sprite[] sounds = groupDictionary[name]; 
			return sounds[0];
		}
		print ("getFirstShip() fail");
		return null;
	}


	public Sprite getNextShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Sprite[] sounds = groupDictionary[name]; 

			scrollIndex++;
			if (scrollIndex >= shipArraySize)
				scrollIndex = 0;

			print ("scrollIndex: " + scrollIndex);

			return sounds[scrollIndex];
		}
		print ("getNextShip() fail");
		return null;
	}


	public Sprite getPreviousShip(string name) {
		if (groupDictionary.ContainsKey(name)) {

			Sprite[] sounds = groupDictionary[name]; 

			scrollIndex--;
			if (scrollIndex <= 0)
				scrollIndex = shipArraySize-1;

			print ("scrollIndex: " + scrollIndex);

			return sounds[scrollIndex];
		}
		print ("getPreviousShip() fail");
		return null;
	}






	public Sprite GetClipFromName(string name) {
		if (groupDictionary.ContainsKey(name)) {
			Sprite[] sounds = groupDictionary[name]; 
			return sounds[0];
		}
		print ("GetClipFromName() fail");
		return null;
	}

	public Sprite GetRandomClipFromName(string name) {
		if (groupDictionary.ContainsKey(name)) {
			Sprite[] sounds = groupDictionary[name];
			return sounds[Random.Range(0,sounds.Length)];
		}
		print ("GetRandomClipFromName() fail");
		return null;
	}


	[System.Serializable]
	public class ImageGroup {
		public string groupID;
		public Sprite[] group;
	}
}
