using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewLibrary : MonoBehaviour {

	public ImageGroup[] CrewList;
	private int ScrollIndex = 0;
	public int CrewArraySize;

	Dictionary<int, Crew[]> groupDictionary = new Dictionary<int, Crew[]>();

	void Awake() {
		foreach (ImageGroup imageGroup in CrewList) {
			groupDictionary.Add (imageGroup.groupID, imageGroup.group);
		}

		Crew[] crew = groupDictionary[0];

		CrewArraySize = crew.Length;
	}

	public Crew GetClipFromId(int id) {
		if (groupDictionary.ContainsKey(id)) {
			Crew[] crew = groupDictionary[id];
			return crew[0];
		}
		return null;
	}

	public Crew HireCurrentCrew(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Crew[] crew = groupDictionary[id]; 
			// print ("buy: " + scrollIndex);

			return crew[ScrollIndex];
		}
		// print ("buyCurrentShip() fail");
		return null;
	}
		
	public Crew GetFirstCrew(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Crew[] crew = groupDictionary[id]; 
			return crew[0];
		}
		// print ("getFirstShip() fail");
		return null;
	}
		
	public Crew getPreviousCrew(int id) {
		if (groupDictionary.ContainsKey(id)) {

			Crew[] crew = groupDictionary[id]; 

			ScrollIndex--;
			if (ScrollIndex < 0)
				ScrollIndex = CrewArraySize-1;

			// print ("scrollIndex: " + scrollIndex);

			return crew[ScrollIndex];
		}
		// print ("getPreviousShip() fail");
		return null;
	}


		public Crew GetNextCrew(int id) {
			if (groupDictionary.ContainsKey(id)) {

				Crew[] crew = groupDictionary[id]; 

				ScrollIndex++;
				if (ScrollIndex >= CrewArraySize)
					ScrollIndex = 0;

				// print ("scrollIndex: " + scrollIndex);

				return crew[ScrollIndex];
			}
			// print ("getNextShip() fail");
			return null;
		}

	[System.Serializable]
	public class ImageGroup {
		public int groupID;
		public Crew[] group;
	}
}
