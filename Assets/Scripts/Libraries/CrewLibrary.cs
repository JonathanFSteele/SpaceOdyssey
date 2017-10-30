using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewLibrary : MonoBehaviour {

	public ImageGroup[] imageGroups;

	Dictionary<string, Sprite> groupDictionary = new Dictionary<string, Sprite>();

	void Awake() {
		foreach (ImageGroup imageGroup in imageGroups) {
			groupDictionary.Add (imageGroup.groupID, imageGroup.group);
		}
	}

	public Sprite GetClipFromName(string name) {
		if (groupDictionary.ContainsKey(name)) {
			return groupDictionary[name];;
		}
		return null;
	}

	[System.Serializable]
	public class ImageGroup {
		public string groupID;
		public Sprite group;
	}
}
