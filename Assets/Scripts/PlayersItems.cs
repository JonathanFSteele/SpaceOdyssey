using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class PlayersItems  {

//	public Item_List[] itemList;
	public int itemArraySize;
	private int scrollIndex = -1;

//	Dictionary<string, Item[]> groupDictionary = new Dictionary<string, Item[]>();



	// void Awake() {
	// 	foreach (Item_List foo in itemList) {
	// 		groupDictionary.Add (foo.groupID, foo.group);

	// 		Item[] items = groupDictionary ["market_supplies"];

	// 		itemArraySize = items.Length;
	// 		print ("itemArraySize: " + itemArraySize);
	// 	}
	// }


	// public Item getNextItem(string name) {
	// 	if (groupDictionary.ContainsKey(name)) {

	// 		Item[] items = groupDictionary[name]; 

	// 		scrollIndex++;
	// 		if (scrollIndex >= itemArraySize)
	// 		scrollIndex = 0;

	// 		print ("scrollIndex: " + scrollIndex);

	// 		return items[scrollIndex];
	// 	}
	// 	print ("getNextItem() fail");
	// 	return null;
	// }	


	// [System.Serializable]
	// public class Item_List {
	// 	public string groupID;
	// 	public Item[] group;
	// }
}
