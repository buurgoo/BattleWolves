using System;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;
    [SerializeField] private GameObject skillMenu;

    public void OnEquipBiteButtonClicked()
    {
        ToggleSkill(typeof(Bite), SkillLevel.Bite);
    }

    public void OnEquipRageButtonClicked()
    {
        ToggleSkill(typeof(Rage), SkillLevel.Rage);
    }

    public void OnEquipGoForTheThroatButtonClicked()
    {
        ToggleSkill(typeof(GoForThroat), SkillLevel.Go_for_the_Throat);
    }

    public void OnEquipBodySlamButtonClicked()
    {
        ToggleSkill(typeof(BodySlam), SkillLevel.Body_Slam);
    }

    public void OnEquipLickWoundsButtonClicked()
    {
        ToggleSkill(typeof(LickWounds), SkillLevel.Lick_your_Wounds);
    }

    public void OnEquipIntimidateButtonClicked()
    {
        ToggleSkill(typeof(Intimidate), SkillLevel.Intimidate);
    }

    public void OnEquipScratchButtonClicked()
    {
        ToggleSkill(typeof(Scratch), SkillLevel.Scratch);
    }

    public void OnEquipStrikeBackButtonClicked()
    {
        ToggleSkill(typeof(PrepareStrike), SkillLevel.Strike_Back);
    }

    public void OnEquipFinishOffButtonClicked()
    {
        ToggleSkill(typeof(FinishOff), SkillLevel.Finish_off_the_Wounded);
    }

    public void OnEquipStrikeButtonClicked()
    {
        ToggleSkill(typeof(Strike), SkillLevel.Strike);
    }

    private void ToggleSkill(Type skillType, SkillLevel skill)
    {
        if (WolfSessionData.skill1 == skillType) WolfSessionData.skill1 = typeof(Wait);
        else if (WolfSessionData.skill2 == skillType) WolfSessionData.skill2 = typeof(Wait);
        else if (WolfSessionData.skill3 == skillType) WolfSessionData.skill3 = typeof(Wait);
        else if (WolfSessionData.skill4 == skillType) WolfSessionData.skill4 = typeof(Wait);

        else if (SkillsInventory.GetSkillLevel(skill) <= 0)
        {
            Debug.Log("Skill is not parchased");
            return;
        }

        else if (WolfSessionData.skill1 == typeof(Wait)) WolfSessionData.skill1 = skillType;
        else if (WolfSessionData.skill2 == typeof(Wait)) WolfSessionData.skill2 = skillType;
        else if (WolfSessionData.skill3 == typeof(Wait)) WolfSessionData.skill3 = skillType;
        else if (WolfSessionData.skill4 == typeof(Wait)) WolfSessionData.skill4 = skillType;

        else
        {
            Debug.Log("All skill slots are occupied");
            return;
        }

        Debug.Log($"Equip status changed: {skill}");
    }

    public void OnCloseButtonClicked()
    {
        CloseMenu();
        wolf.ChangeState(WolfState.Idle);
    }

    public void OpenMenu()
    {
        Debug.Log("Skill menu opened");
        skillMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Debug.Log("Skill menu closed");
        skillMenu.SetActive(false);
    }
}