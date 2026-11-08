using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleWolf : BattleWolf
{
    [SerializeField] private Button skillButton1;
    [SerializeField] private Button skillButton2;

    private System.Type skillType1 = typeof(Bite);
    private System.Type skillType2 = typeof(Scratch);
    //private System.Type skillType3 = typeof(Wait);
    //private System.Type skillType4 = typeof(Wait);


    //public PlayerBattleWolf(System.Type skill1, System.Type skill2, System.Type skill3, System.Type skill4,
    //                        int level, float sleep, float hunger, float cleanliness, float bloodthirst)
    //{
    //    skillType1 = skill1;
    //    skillType2 = skill2;
    //    skillType3 = skill3;
    //    skillType4 = skill4;

    //    try
    //    {
    //        using StreamReader reader = new("LevelStatScalings.json");
    //        string levelScalings = reader.ReadToEnd();
    //        Dictionary<int, Dictionary<string, int>> levelScalingsObj = JsonUtility.FromJson<Dictionary<int, Dictionary<string, int>>>(levelScalings);

    //        _baseAtk = levelScalingsObj[level]["Atk"];
    //        _baseDef = levelScalingsObj[level]["Def"];
    //        _baseHP = levelScalingsObj[level]["HP"];
    //    }
    //    catch (IOException e)
    //    {
    //        Console.WriteLine("The 'LevelStatScalings.json' file could not be read:");
    //        Console.WriteLine(e.Message);
    //    }

    //    if (sleep < 0.5f) { _obtainedAtk -= 0.3f; _obtainedDef -= 0.3f; }
    //    if (hunger > 0.75f) { _obtainedAtk -= 0.5f; _obtainedHP -= 0.1f; }
    //    else if (hunger > 0.5f) { _obtainedAtk += 0.1f; _obtainedHP -= 0.1f; }
    //    if (cleanliness < 0.5f) { _obtainedDef += 0.2f; _obtainedHP -= 0.4f; }
    //    if (bloodthirst > 0.5f) { _obtainedAtk += 0.5f; _obtainedDef -= 0.5f; }
    //}

    public void SelectSkill1()
    {
        //selectedSkill = skill1;
        selectedSkill = (Skill)Activator.CreateInstance(skillType1);
        Debug.Log("Player selected Skill 1.");
        battleManager.PlayerSelectedSkill(this);
    }

    public void SelectSkill2()
    {
        //selectedSkill = skill2;
        selectedSkill = (Skill)Activator.CreateInstance(skillType2);
        Debug.Log("Player selected Skill 2.");
        battleManager.PlayerSelectedSkill(this);
    }

    public override void OnAwake()
    {
        skillButton1.onClick.AddListener(SelectSkill1);
        skillButton2.onClick.AddListener(SelectSkill2);

        skillButton1.enabled = false;
        skillButton2.enabled = false;
    }

    public override void SelectSkill()
    {
        skillButton1.enabled = true;
        skillButton2.enabled = true;
    }
}