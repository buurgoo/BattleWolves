public class PrepareStrike : LingeringSkill
{
    public override int skillId { get { return 6; } }
    public override SkillType skillType { get { return SkillType.Conniving; } }

    public override int totalTicks { get { return 0; } }
    public override bool lingersOnOponent { get { return false; } }

    private int castHP;
    private int expireHP;

    public override void CastEffect(BattleWolf caster, BattleWolf oponent)
    {
        caster.ModifyDef(0.7f);
        castHP = caster.GetCurrentHP();
    }

    public override void TickEffect(BattleWolf wolf) { }

    public override void ExpireEffect(BattleWolf wolf) 
    { 
        expireHP = wolf.GetCurrentHP();
        if (expireHP < castHP) 
        {
            wolf.selectedSkill = new Strike();
        }
    }
}