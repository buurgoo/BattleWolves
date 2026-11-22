using UnityEngine;

public class Rage : Skill
{
    public override int skillId { get { return 3; } }
    public override SkillType skillType { get { return SkillType.Aggressive; } }

    public static int atkBonus = 50;
    public static int defDebuff = 100;
    public static int selfDamage = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        caster.TakeDirectDamage((int)(caster.MaxHP() * ((float)selfDamage / (float)100)));
        caster.ModifyAtk((float)atkBonus / (float)100);
        caster.ModifyDef((float)-defDebuff / (float)100);
    }
}