using UnityEngine;

public class PrepareStrike : LingeringSkill
{
    public override int skillId { get { return 6; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public override int totalTicks { get { return 0; } }
    public override bool lingersOnOponent { get { return false; } }

    public static int defBonus = 200;

    private int castHP;
    private int expireHP;

    public override void CastEffect(BattleWolf caster, BattleWolf oponent)
    {
        caster.ModifyDef((float)defBonus / (float)100);
        castHP = caster.CurrentHP();
    }

    public override void TickEffect(BattleWolf wolf) { }

    public override void ExpireEffect(BattleWolf wolf) 
    { 
        expireHP = wolf.CurrentHP();
        if (expireHP < castHP) 
        {
            wolf.selectedSkill = new Strike();
        }
        wolf.ModifyDef((float)-defBonus / (float)100);
    }
}