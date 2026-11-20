using UnityEngine;
using System;

public enum SkillLevel
{
    // I don't rememder wath we need here
}

public class DreamBody : MonoBehaviour
{
    public void Buy(SkillLevel skill, int price)
    {
        if (WolfSessionData.Money < price) return;

        WolfSessionData.Money -= price;
        SkillsInventory.Add(skill);
    }
}