using UnityEngine;

public class Bite : Skill
{
    public override int skillId { get { return 2; } }
    public override SkillType skillType { get { return SkillType.Aggressive; } }

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        //Debug.Log($"Caster hp: {caster.GetRemainingHP()}");
        if (caster.GetRemainingHP() < 0.5f)
        {
            oponent.TakeSkillDamage(caster.CalculateSkillDamage(1.5f));
        }
        else
        {
            oponent.TakeSkillDamage(caster.CalculateSkillDamage(1f));
        }
    }
}