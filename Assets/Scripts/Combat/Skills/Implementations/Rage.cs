using UnityEngine;

public class Rage : Skill
{
    public override int skillId { get { return 3; } }
    public override SkillType skillType { get { return SkillType.Aggressive; } }

    public static int atkBonus = 50;
    public static int defDebuff = 100;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        caster.ModifyAtk((float)atkBonus / 100);
        caster.ModifyDef((float)-defDebuff / 100);
    }
}