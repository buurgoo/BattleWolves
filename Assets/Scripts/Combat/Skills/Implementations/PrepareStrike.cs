public class PrepareStrike : LingeringSkill
{
    private int _skillId = 6;
    public SkillType skillType = SkillType.Conniving;

    public int totalTicks = 0;
    private bool lingersOnOponent = false;

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