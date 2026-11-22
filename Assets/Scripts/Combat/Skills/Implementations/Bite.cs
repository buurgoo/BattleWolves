using UnityEngine;

public class Bite : Skill
{
    public override int skillId { get { return 2; } }
    public override SkillType skillType { get { return SkillType.Aggressive; } }

    public static int HPThreshold = 50;
    public static int lowHPMotionValue = 150;
    public static int highHPMotionValue = 100;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        if (caster.RemainingHP() < ((float)HPThreshold / (float)100))
        {
            oponent.TakeSkillDamage(caster.CalculateAtkSkillDamage((float)lowHPMotionValue / (float)100));
        }
        else
        {
            oponent.TakeSkillDamage(caster.CalculateAtkSkillDamage((float)highHPMotionValue / (float)100));
        }
    }
}