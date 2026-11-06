public class Scratch : Skill
{
    private int _skillId = 1;
    public SkillType Type = SkillType.Attack;

    public string name = "Scratch";
    public string description = "Deal 50% of Attack as damage.";

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeDamage(caster.CalculateSkillDamage(0.5f));
    }
}