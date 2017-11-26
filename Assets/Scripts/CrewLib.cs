using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class CrewLib : MonoBehaviour {

   
    public Sprite CrewImage;
    public String CrewName = "Joe";
    public String Description = "Words";
    public int Combat = 0;
    public int Mechanics = 0;
    public int Medicine = 0;
    public int Charisma = 0;

    public String SkillName1 = "x";
    public String SkillName2 = "x";
    public String SkillName3 = "x";
    public int SkillValue1 = 0;
    public int SkillValue2 = 0;
    public int SkillValue3 = 0;


    // Update is called once per frame
    void Update () {

        if (CrewName.Equals("Garfield"))
        {
            Combat = 10;
            Mechanics = 3 + SkillValue3;
            Medicine = 4 + SkillValue2;
            Charisma = 2 + SkillValue1;

            SkillName1 = "Green Alien";
            SkillName2 = "Dirty";
            SkillName3 = "Bionic Implant";

            SkillValue1 = 6;
            SkillValue2 = -1;
            SkillValue3 = 2;


        }//end of if

        if (CrewName.Equals("Jeremy"))
        {
            Combat = 1 + SkillValue2;
            Mechanics = 1;
            Medicine = 10 + SkillValue3;
            Charisma = 5 + SkillValue1;

            SkillName1 = "Grossout Charisma";
            SkillName2 = "Muscle";
            SkillName3 = "Germ All knowing";

            SkillValue1 = -1;
            SkillValue2 = 2;
            SkillValue3 = -6;

        }//end of if

        if (CrewName.Equals("Jose"))
        {
            Combat = 7 + SkillValue1;
            Mechanics = 10 + SkillValue2;
            Medicine = 3;
            Charisma = 6 + SkillValue3;

            SkillName1 = "Red Shirt";
            SkillName2 = "Smart";
            SkillName3 = "Blind";

            SkillValue1 = -5;
            SkillValue2 = 4;
            SkillValue3 = 3;

        }//end of if

      





    }
}
