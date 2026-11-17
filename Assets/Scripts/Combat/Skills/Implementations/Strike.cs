using UnityEngine;

public class Strike : Skill
{
    public override int skillId { get { return 10; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public static int damage = 200;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeDirectDamage(damage);
        Debug.Log("Strike");
    }
}