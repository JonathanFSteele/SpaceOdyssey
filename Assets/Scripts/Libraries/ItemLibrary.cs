using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour {

	public Item_List[] itemList;
	public int itemArraySize;

	Dictionary<string, Item[]> groupDictionary = new Dictionary<string, Item[]>();

//not applicable
	// public Sprite GetClipFromName(string name) {
	// 	if (groupDictionary.ContainsKey(name)) {
	// 		return groupDictionary[name];;
	// 	}
	// 	return null;
	// }


	void Awake() {
		foreach (Item_List foo in itemList) {
			groupDictionary.Add (foo.groupID, foo.group);

			Item[] items = groupDictionary ["market_supplies"];

			itemArraySize = items.Length;
			print ("itemArraySize: " + itemArraySize);
		}
	}


	[System.Serializable]
	public class Item_List {
		public string groupID;
		public Item[] group;
	}
}
