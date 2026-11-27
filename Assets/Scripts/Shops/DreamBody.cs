using UnityEngine;
using System;
using TMPro;

public enum SkillLevel
{
    Bite = 0,
    Rage = 1,
    Go_for_the_Throat = 2,
    Body_Slam = 3,
    Lick_your_Wounds = 4,
    Intimidate = 5,
    Scratch = 6,
    Strike_Back = 7,
    Finish_off_the_Wounded = 8,
    Strike = 9,
}

public class DreamBody : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    private void Start()
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = WolfSessionData.Money.ToString();
    }

    public int GetPrice(SkillLevel skill)
    {
        return skill switch
        {
            SkillLevel.Bite => 25,
            SkillLevel.Rage => 20,
            SkillLevel.Go_for_the_Throat => 30,
            SkillLevel.Body_Slam => 25,
            SkillLevel.Lick_your_Wounds => 15,
            SkillLevel.Intimidate => 35,
            SkillLevel.Scratch => 10,
            SkillLevel.Strike_Back => 20,
            SkillLevel.Finish_off_the_Wounded => 40,
            SkillLevel.Strike => 30,
            _ => 0
        };
    }

    public void Buy(SkillLevel skill)
    {
        int price = GetPrice(skill);
        if (WolfSessionData.Money < price) return;

        WolfSessionData.Money -= price;
        SkillsInventory.Add(skill);
        UpdateMoneyText();
        Debug.Log($"Bought: {skill}. Money left: {WolfSessionData.Money}");
    }

    public void BuyItem(int itemIndex)
    {
        Buy((SkillLevel)itemIndex);
    }
}