using UnityEngine;

public class Intimidate : Skill
{
    public override int skillId { get { return 7; } }
    public override SkillType skillType { get { return SkillType.Intimidating; } }

    public static int atkDebuff = 25;
    public static int defDonus = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.ModifyAtk((float)-atkDebuff / 100);
        oponent.ModifyDef((float)defDonus / 100);
    }
}