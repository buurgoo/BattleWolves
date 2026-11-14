using System.Collections.Generic;

public static class SkillDescriptions
{
    public static Dictionary<int, SkillDescription> skillDescriptions = new Dictionary<int, SkillDescription>()
    {
        // Aggressive skills
        { 
            2, 
            new SkillDescription(
            "Bite",
            "Deal 100% of Atk as damage. If HP < 50%, deal 150% of Atk instead."
            ) },
        { 
            3, 
            new SkillDescription(
            "Rage",
            "Increase Atk by 50% and decrease Def by 100% for the rest of the fight."
            ) },
        { 
            8, 
            new SkillDescription(
            "Go for the Throat",
            "Sick",
            "Deal 250% of Atk as damage. If Def < 10%, has a 10% chance to inflict sickness. Has a 10% chance to miss."
            ) },

        // Intimidating skills
        { 
            4, 
            new SkillDescription(
            "Body Slam",
            "Deal 50% of current HP as damage."
            ) },
        { 
            5, 
            new SkillDescription(
            "Lick your Wounds",
            "Restore 10% of Max HP. Remove all active effects."
            ) },
        { 
            7, 
            new SkillDescription(
            "Intimidate",
            "Decrease oponent Atk by 25%. Increase oponent Def by 10%."
            ) },

        // Conniving skills
        { 
            0, 
            new SkillDescription(
            "Wait",
            "Pass your turn."
            ) },
        { 
            1, 
            new SkillDescription(
            "Scratch",
            "Bleed",
            "Deal 25% of Atk as damage. Inflict bleed for the next 3 turns. Bleed: Deal 25 direct damage."
            ) },
        { 
            6, 
            new SkillDescription(
            "Prepare to Strike Back",
            "Defensive Stance",
            "Increase Def by 70% for this turn. If damage taken this turn, start your next turn with Strike."
            ) },
        { 
            9, 
            new SkillDescription(
             "Finish off the Wounded",
            "Deal 20% of Atk as damage. For every 10% of oponent Max HP missing, deal an additional 10%."
            ) },
        { 
            10, 
            new SkillDescription(
            "Strike",
            "Deal 25 direct damage."
            ) }
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