using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{

    //Varibles that change the output text on screen
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

    //Stat Controllers
    public Text cb;
    public Text mc;
    public Text md;
    public Text ch;

    public Text a1;
    public Text a2;
    public Text a3;

    //Description Body Controller
    public Text Body;

    // Update is called once per frame
    void Update()
    {
        //updates Stats
        cb.text = Combat.ToString();
        mc.text = Mechanics.ToString();
        md.text = Medicine.ToString();
        ch.text = Charisma.ToString();

        //Update Skills
        a1.text = SkillName1 + SkillValue1.ToString();
        a2.text = SkillName2 + SkillValue2.ToString();
        a3.text = SkillName3 + SkillValue3.ToString();

        //updates Log Description
        Body.text = "Name:" + CrewName + "\n" + Description;
    }
}

