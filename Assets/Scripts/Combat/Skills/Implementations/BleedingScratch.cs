using UnityEngine;

public class BleedingScratch : LingeringSkill
{
    private int _skillId = 2;
    public SkillType skillType = SkillType.Defence;

    public int totalTicks = 3;
    private bool lingersOnOponent = true;

    public override void CastEffect(BattleWolf caster, BattleWolf oponent)
    {
        Scratch scratch = new Scratch();
        scratch.Cast(caster, oponent);
    }

    public override void TickEffect(BattleWolf wolf)
    {
        wolf.TakeDamage(25);
        Debug.Log("Bleed tick");
    }
}