using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
/*
public class SaveAndLoad : MonoBehaviour 
{
	public List<int> list1 = new List<int>();
	public Vector3 xyz = new Vector3();


	// Use this for initialization
	void Start () {
		Load();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			Save();
		}

	}

	public void Save()
	{
		if (!Directory.Exists (Application.dataPath + "/Saves")) 
		{
			Directory.CreateDirectory(Application.dataPath + "/Saves");
		}
		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Create(Application.dataPath + "/save/saveData.dat");

		CopySaveData();

		bf.Serialize (file, data);
		file.Close();

	}

	public void CopySaveData()
	{
		data.list1.Clear();

		foreach(int i in list1)
		{
			data.list1.Add(i);
		}

		data.position = SerVector3ToSerVector3(xyz);
	}

	public void Load()
	{
		if (File.Exists(Application.dataPath + "/save/saveData.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.dataPath + "/save/saveData.dat", File.Open);
			data = (saveData)bf.Deserialize(file);

			CopyLoadData();

			file.Close();
		}
	}

	public void CopyLoadData()
	{
		data.list1.Clear();

		foreach(int i in list1)
		{
			data.list1.Add (i);
		}
			
		xyz = SerVector3ToSerVector3(data.position);
	}

	public static SerVector3 SerVector3ToSerVector3(Vector3 V3)
	{
		SerVector3 SV3 = new SerVector3();

		SV3.x = V3.x;
		SV3.y = V3.y;
		SV3.z = V3.z;

		return SV3;
	}

	public static Vector3 SerVector3ToVector(SerVector3 SV3)
	{
		Vector3 V3 = new Vector3();

		V3.x = SV3.x;
		V3.y = SV3.y;
		V3.z = SV3.z;

		return V3;

	}

}

[System.Serializable]
public class saveData
{
	public SerVector3 position;


	public List<int> list1 = new List<int>();


}

[System.Serializable]
public class SerVector3
{
	public float x;
	public float y;
	public float z;
}
*/