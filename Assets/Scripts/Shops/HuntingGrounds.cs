using UnityEngine;
using System;

public enum HuntingGroundsItems
{
    // Feel free to add whatever you want
    Rabbit,
    Chicken,
    Turkey,
    Pork,
    Beef,
    Potato,
    Sausage,
    Dumplings,
    Varenyky,
    Borscht,
    Tea,
    Medicine_10,
    Medicine_20,
    Medicine_30
}

public class HuntingGrounds : MonoBehaviour
{
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
        Debug.Log($"Bought: {food}. Money left: {WolfSessionData.Money}");
    }
}