using UnityEngine;

public abstract class LingeringSkill : Skill
{
    public abstract int totalTicks { get; }
    public int remainingTicks;
    public bool isActive;

    public abstract bool lingersOnOponent { get; }

    public override void Cast(BattleWolf caster, BattleWolf oponent)
    {
        CastEffect(caster, oponent);

        if (lingersOnOponent) { oponent.SetLingeringSkill(this); }
        else { caster.SetLingeringSkill(this); }

        remainingTicks = totalTicks;
        isActive = true;
    }

    public void Tick(BattleWolf wolf) 
    {
        if (remainingTicks == 0)
        {
            Debug.Log("expire");
            isActive = false;
            ExpireEffect(wolf);
        }
        else
        {
            TickEffect(wolf);
            remainingTicks -= 1;
        }
    }

    public abstract void CastEffect(BattleWolf caster, BattleWolf oponent);
    public abstract void TickEffect(BattleWolf wolf);
    public abstract void ExpireEffect(BattleWolf wolf);

}