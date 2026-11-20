using UnityEngine;
using System;
using TMPro;

public enum HuntingGroundsItems
{
    // Feel free to add whatever you want
    Rabbit = 0,
    Chicken = 1,
    Turkey = 2,
    Pork = 3,
    Beef = 4,
    Potato = 5,
    Sausage = 6,
    Dumplings = 7,
    Varenyky = 8,
    Borscht = 9,
    Tea = 10,
    Medicine_10 = 11,
    Medicine_20 = 12,
    Medicine_30 = 13
}

public class HuntingGrounds : MonoBehaviour
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

    public int GetPrice(HuntingGroundsItems food)
    {
        return food switch
        {
            HuntingGroundsItems.Rabbit => 25,
            HuntingGroundsItems.Chicken => 20,
            HuntingGroundsItems.Turkey => 20,
            HuntingGroundsItems.Pork => 30,
            HuntingGroundsItems.Beef => 30,
            HuntingGroundsItems.Potato => 5,
            HuntingGroundsItems.Sausage => 15,
            HuntingGroundsItems.Dumplings => 10,
            HuntingGroundsItems.Varenyky => 30,
            HuntingGroundsItems.Borscht => 30,
            HuntingGroundsItems.Tea => 5,
            HuntingGroundsItems.Medicine_10 => 50,
            HuntingGroundsItems.Medicine_20 => 70,
            HuntingGroundsItems.Medicine_30 => 100,
            _ => 0
        };
    }

    public void Buy(HuntingGroundsItems food)
    {
        int price = GetPrice(food);
        if (WolfSessionData.Money < price) return;

        WolfSessionData.Money -= price;
        FridgeInventory.Add(food);
        UpdateMoneyText();
        Debug.Log($"Bought: {food}. Money left: {WolfSessionData.Money}");
    }

    public void BuyItem(int itemIndex)
    {
        Buy((HuntingGroundsItems)itemIndex);
    }
}