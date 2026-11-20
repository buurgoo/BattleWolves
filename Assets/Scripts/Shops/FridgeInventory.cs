using System.Collections.Generic;

public static class FridgeInventory
{
    private static readonly Dictionary<HuntingGroundsItems, int> items = new();

    public static void Add(HuntingGroundsItems food)
    {
        if (!items.ContainsKey(food)) items[food] = 0;
        items[food]++;
    }

    public static int GetCount(HuntingGroundsItems food)
    {
        return items.GetValueOrDefault(food, 0);
    }

    public static bool Remove(HuntingGroundsItems food)
    {
        if (GetCount(food) <= 0) return false;

        items[food]--;
        return true;
    }
}