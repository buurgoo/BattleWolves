using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleWolf : BattleWolfUI
{
    [SerializeField] private Button skillButton1;
    [SerializeField] private Button skillButton2;
    [SerializeField] private Button skillButton3;
    [SerializeField] private Button skillButton4;

    private System.Type skillType1 = typeof(Bite);
    private System.Type skillType2 = typeof(Scratch);
    private System.Type skillType3 = typeof(Wait);
    private System.Type skillType4 = typeof(Wait);

    public override PlayerStats playerStats 
    { 
        get { return WolfSessionData.BuildBattleStats(); }
    }

    public override void InitBaseStats()
    {
        PlayerStats stats = playerStats;
        
        skillType1 = playerStats.skill1;
        skillType2 = playerStats.skill2;
        skillType3 = playerStats.skill3;
        skillType4 = playerStats.skill4;

        ui.SetSkillButtonText(skillType1, skillType2, skillType3, skillType4);

        _baseAtk = LevelScalings.levelScalings[playerStats.level].Atk;
        _baseDef = LevelScalings.levelScalings[playerStats.level].Def;
        _baseHP = LevelScalings.levelScalings[playerStats.level].HP;

        _obtainedAtk = (stats.sleep < 0.5f) ? -0.4f : 0f;
        _obtainedHP = (stats.hunger > 0.5f) ? -0.4f : 0f;
        _obtainedDef = (stats.cleanliness < 0.5f) ? -0.4f : 0f;
        _bloodthirstBonus = (stats.bloodthirst > 0.5f) ? 0.5f : 0f;
    }

    public void SelectSkill1()
    {
        selectedSkill = (Skill)Activator.CreateInstance(skillType1);
        Debug.Log("Player selected Skill 1.");
        battleManager.PlayerSelectedSkill(this);
    }

    public void SelectSkill2()
    {
        selectedSkill = (Skill)Activator.CreateInstance(skillType2);
        Debug.Log("Player selected Skill 2.");
        battleManager.PlayerSelectedSkill(this);
    }

    public void SelectSkill3()
    {
        selectedSkill = (Skill)Activator.CreateInstance(skillType3);
        Debug.Log("Player selected Skill 3.");
        battleManager.PlayerSelectedSkill(this);
    }
    public void SelectSkill4()
    {
        selectedSkill = (Skill)Activator.CreateInstance(skillType4);
        Debug.Log("Player selected Skill 4.");
        battleManager.PlayerSelectedSkill(this);
    }

    public override void OnAwake()
    {
        skillButton1.onClick.AddListener(SelectSkill1);
        skillButton2.onClick.AddListener(SelectSkill2);
        skillButton3.onClick.AddListener(SelectSkill3);
        skillButton4.onClick.AddListener(SelectSkill4);

        skillButton1.enabled = false;
        skillButton2.enabled = false;
        skillButton3.enabled = false;
        skillButton4.enabled = false;
    }

    public override void SelectSkill()
    {
        skillButton1.enabled = true;
        skillButton2.enabled = true;
        skillButton3.enabled = true;
        skillButton4.enabled = true;
    }
}