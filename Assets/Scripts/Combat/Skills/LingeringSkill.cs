public abstract class LingeringSkill : Skill
{
    int totalTicks;
    public int remainingTicks;
    public bool isActive;

    bool lingersOnOponent;

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
        TickEffect(wolf);
        remainingTicks -= 1;

        if (remainingTicks == 0) { isActive = false; }
    }

    public abstract void TickEffect(BattleWolf wolf);
    public abstract void CastEffect(BattleWolf caster, BattleWolf oponent);
}