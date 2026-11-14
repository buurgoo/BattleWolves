public class BasicAttack : Skill
{
    private int _skillId = 1;

    public string name = "Basic Attack";
    public string description = "Deal 50% of Attack as damage.";

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        oponent.TakeDamage(caster.CalculateSkillDamage(0.5f));
    }
}