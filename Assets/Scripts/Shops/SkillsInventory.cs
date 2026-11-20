using System.Collections.Generic;

public static class SkillsInventory
{
    private static readonly Dictionary<SkillLevel, int> items = new();

    public static void Add(SkillLevel skill)
    {
        if (!items.ContainsKey(skill)) items[skill] = 0;
        items[skill]++;
    }

    public static int GetCount(SkillLevel skill)
    {
        return items.GetValueOrDefault(skill, 0);
    }
}