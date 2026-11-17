using UnityEngine;

public class LickWounds : Skill
{
    public override int skillId { get { return 5; } }
    public override SkillType skillType { get { return SkillType.Intimidating; } }

    public static int heal = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        caster.Heal((float)heal / (float)100);
        caster.lingeringSkills = new LingeringSkill[3];
    }
}