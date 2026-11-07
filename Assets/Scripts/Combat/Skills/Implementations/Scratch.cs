using UnityEngine;

public class Scratch : LingeringSkill
{
    private int _skillId = 1;
    public SkillType skillType = SkillType.Conniving;

    public int totalTicks = 3;
    private bool lingersOnOponent = true;

    public override void CastEffect(BattleWolf caster, BattleWolf oponent)
    {
        Bite scratch = new Bite();
        scratch.Cast(caster, oponent);
    }

    public override void TickEffect(BattleWolf wolf)
    {
        wolf.TakeSkillDamage(25);
        Debug.Log("Bleed tick");
    }

    public override void ExpireEffect(BattleWolf wolf) { }
}