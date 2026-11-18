using UnityEngine;

public class BodySlam : Skill
{
    public override int skillId { get { return 4; } }
    public override SkillType skillType { get { return SkillType.Intimidating; } }

    public static int damage = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeSkillDamage(caster.CalculateMaxHPSkillDamage((float)damage / (float)100));
    }
}