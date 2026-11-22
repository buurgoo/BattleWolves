using UnityEngine;

public class FinishOff : Skill
{
    public override int skillId { get { return 9; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public static int baseDamage = 20;
    public static int bonusDamage = 10;
    public static int HPThreshold = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        int extraTicks = (int)(100 - oponent.RemainingHP() * 100) / HPThreshold;
        oponent.TakeSkillDamage(caster.CalculateDefSkillDamage((float)baseDamage / (float)100));
        for (int i = 0; i < extraTicks; i++) 
        {
            oponent.TakeSkillDamage(caster.CalculateDefSkillDamage((float)bonusDamage / (float)100));
        }
    }
}