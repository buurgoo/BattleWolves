public class Bite : Skill
{
    private int _skillId = 2;
    public SkillType Type = SkillType.Aggressive;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        if (caster.GetRemainingHP() < 0.5f)
        {
            oponent.TakeSkillDamage(caster.CalculateSkillDamage(1.5f));
        }
        else
        {
            oponent.TakeSkillDamage(caster.CalculateSkillDamage(1f));
        }
    }
}