using UnityEngine;

public class Strike : Skill
{
    public override int skillId { get { return 10; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeDirectDamage(25);
        Debug.Log("Strike");
    }
}