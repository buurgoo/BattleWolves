using System.Collections.Generic;

public static class SkillDescriptions
{
    public static Dictionary<int, SkillDescription> skillDescriptions = new Dictionary<int, SkillDescription>()
    {
        {1, new SkillDescription(
            "Scratch", 
            "Bleed", 
            "Deal 25% of Atk as damage. Inflict bleed for the next 3 turns. Bleed: Deal 25 direct damage."
            ) },
    };
}

public class SkillDescription
{
    public string name;
    public string effect_name;
    public string description;

    public SkillDescription(string name, string effect_name, string description)
    {
        this.name = name;
        this.effect_name = effect_name;
        this.description = description;
    }

    public SkillDescription(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
} 