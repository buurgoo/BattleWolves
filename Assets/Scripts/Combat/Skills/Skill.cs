public abstract class Skill
{
    int _skillId;
    SkillType skillType;

    public abstract void Cast(BattleWolf caster, BattleWolf oponent);
}
