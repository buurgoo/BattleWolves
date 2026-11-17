using UnityEngine;

public class Scratch : LingeringSkill
{
    public override int skillId { get { return 1; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public override int totalTicks { get { return 3; } }
    public override bool lingersOnOponent { get { return true; } }

    public static int damage = 25;
    public static int bleedDamage = 25;

    public override void CastEffect(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeSkillDamage(caster.CalculateAtkSkillDamage((float)damage / 100));
    }

    public override void TickEffect(BattleWolf wolf)
    {
        wolf.TakeDirectDamage(bleedDamage);
        Debug.Log("Bleed tick");
    }

    public override void ExpireEffect(BattleWolf wolf) { }
}