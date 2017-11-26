using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Log : MonoBehaviour 
{
    //Varibles that change the output text on screen
    public Sprite CaptainImage;
    public String CaptainName = "Joe";
    public String Description = "Words";
    public int Combat = 0;
    public int Mechanics = 0;
    public int Medicine = 0;
    public int Charisma = 0;

    public String Mission = "Place";
    public int Reward = 0;
    public int Difficulty = 0;

    public int skillValue1 = 0;
    public int skillValue2 = 0;
    public int skillValue3 = 0;
    public int skillValue4 = 0;
    public String SkillName1 = "x";
    public String SkillName2 = "x";
    public String SkillName3 = "x";
    public String SkillName4 = "x";

    private SpriteRenderer spriteRenderer;

    //Description Body Controller
    public Text Body;

    //Stat Controllers
    public Text CV;
    public Text MV;
    public Text MDV;
    public Text CHV;

    //Mission Controllers
    public Text M;
    public Text R;
    public Text D;

    //Skill Controllers
    public Text S1;
    public Text S2;
    public Text S3;
    public Text S4;

    void Update()
    {
        //updates Log Description
        Body.text = "Name:" + CaptainName + "\n" + Description;

        //updates Stats
        CV.text =  Combat.ToString();
        MV.text = Mechanics.ToString();
        MDV.text = Medicine.ToString();
        CHV.text = Charisma.ToString();

        //Update Mission
        M.text = Mission;
        R.text = Reward.ToString() + " Credits";
        D.text = Difficulty.ToString() + " Star";

        //Update Skills
        S1.text = SkillName1 +skillValue1.ToString();
        S2.text = SkillName2 + skillValue2.ToString();
        S3.text = SkillName3 + skillValue3.ToString();
        S4.text = SkillName4 + skillValue4.ToString();

        //spriteRenderer.sprite = CaptainImage;
    }

}
