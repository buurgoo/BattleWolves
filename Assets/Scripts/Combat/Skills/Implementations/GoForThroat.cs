using UnityEngine;

public class GoForThroat : Skill
{
    public override int skillId { get { return 8; } }
    public override SkillType skillType { get { return SkillType.Aggressive; } }

    public static int damage = 250;
    public static int defDebuff = 10;

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        if (Random.Range(0f, 1f) > 0.1f)
        {
            oponent.TakeSkillDamage(caster.CalculateAtkSkillDamage((float)damage / 100));

            if ((caster.Def() * 2 < caster.Atk()) && (Random.Range(0f, 1f) > 0.9f))
            {
                oponent.ModifyDef((float)-defDebuff / 100);
            }
        }
    }
}