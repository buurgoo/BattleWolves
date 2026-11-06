public class Pass : Skill
{
    private int _skillId = 0;
    public SkillType Type = SkillType.Defence;

    public string name = "Pass";
    public string description = "Pass your turn.";

    public override void Cast(BattleWolf caster, BattleWolf oponent) { }
}