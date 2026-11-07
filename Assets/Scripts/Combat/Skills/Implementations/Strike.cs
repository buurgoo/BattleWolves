using UnityEngine;

public class Strike : Skill
{
    private int _skillId = 10;
    public SkillType Type = SkillType.Conniving;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeDirectDamage(25);
        Debug.Log("Strike");
    }
}