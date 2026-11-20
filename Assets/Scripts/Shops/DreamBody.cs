using UnityEngine;
using System;
using TMPro;

public enum SkillLevel
{
    // I don't rememder wath we need here
    skill_1 = 0,
    skill_2 = 1,
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
            SkillLevel.skill_1 => 25,
            SkillLevel.skill_2 => 20,
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