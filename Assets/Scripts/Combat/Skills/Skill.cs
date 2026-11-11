public abstract class Skill
{
    public abstract int skillId { get; }
    public abstract SkillType skillType { get; }

    public abstract void Cast(BattleWolf caster, BattleWolf oponent);
}
