using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleWolf : BattleWolf
{
    [SerializeField] private Button skillButton1;
    [SerializeField] private Button skillButton2;

    private System.Type skillType1 = typeof(Bite);
    private System.Type skillType2 = typeof(Scratch);

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