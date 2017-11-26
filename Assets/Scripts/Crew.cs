using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[Serializable]
public class Crew {
	public int CrewPrice;
    public String CrewImage;
    public String CrewName;
    public String Description;
    public int Combat;
    public int Medicine;
    public int Charisma;

//	public int Mechanics;
//    public String SkillName1 = "x";
//    public String SkillName2 = "x";
//    public String SkillName3 = "x";
//    public int SkillValue1 = 0;
//    public int SkillValue2 = 0;
//    public int SkillValue3 = 0;
}
