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
            $"Deal {Bite.highHPMotionValue}% of Atk as damage. If HP < {Bite.HPThreshold}%, deal {Bite.highHPMotionValue}% of Atk instead."
            ) },
        { 
            3, 
            new SkillDescription(
            "Rage",
            $"Lose {Rage.selfDamage}% of Max HP. Increase Atk by {Rage.atkBonus}% and decrease Def by {Rage.defDebuff}% for the rest of the fight."
            ) },
        { 
            8, 
            new SkillDescription(
            "Go for the Throat",
            $"Deal {GoForThroat.damage}% of Atk as damage. Has a 10% chance to miss. If Def < 50% of Atk, has a 10% chance to decrease oponent Max HP by {GoForThroat.HPDebuff}% for the rest of the fight."
            ) },

        // Intimidating skills
        { 
            4, 
            new SkillDescription(
            "Body Slam",
            $"Deal {BodySlam.damage}% of current HP as damage."
            ) },
        { 
            5, 
            new SkillDescription(
            "Lick your Wounds",
            $"Restore {LickWounds.heal}% of Max HP. Remove all active effects."
            ) },
        { 
            7, 
            new SkillDescription(
            "Intimidate",
            $"Decrease oponent Atk by {Intimidate.atkDebuff}%. Increase oponent Def by {Intimidate.defDonus}%."
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
            $"Deal {Scratch.damage}% of Atk as damage. Inflict bleed for the next 3 turns. Bleed: Deal {Scratch.bleedDamage} direct damage."
            ) },
        { 
            6, 
            new SkillDescription(
            "Prepare to Strike Back",
            "Defensive Stance",
            $"Increase Def by {PrepareStrike.defBonus}% for this turn. If damage taken this turn, start your next turn with Strike."
            ) },
        { 
            9, 
            new SkillDescription(
            "Finish off the Wounded",
            $"Deal {FinishOff.baseDamage}% of Def as damage. For every {FinishOff.HPThreshold}% of oponent Max HP missing, deal an additional {FinishOff.bonusDamage}%."
            ) },
        { 
            10, 
            new SkillDescription(
            "Strike",
            $"Deal {Strike.damage} direct damage."
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