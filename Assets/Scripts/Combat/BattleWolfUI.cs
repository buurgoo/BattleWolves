using UnityEngine;

public abstract class BattleWolfUI : BattleWolf
{
    [SerializeField] protected CombatUI ui;
    [SerializeField] public bool playerId;

    public override int TakeSkillDamage(int attackDamage) 
    { 
        int damage = base.TakeSkillDamage(attackDamage);
        ui.displayDamage.Invoke(damage, playerId, true);
        ui.displayHP.Invoke(CurrentHP(), MaxHP(), playerId);

        if (CurrentHP() == 0) { ui.displayGameOver.Invoke(!playerId); }

        return damage;
    }

    public override void TakeDirectDamage(int attackDamage)
    {
        base.TakeDirectDamage(attackDamage);
        ui.displayDamage.Invoke(attackDamage, playerId, true);
        ui.displayHP.Invoke(CurrentHP(), MaxHP(), playerId);

        if (CurrentHP() == 0) { ui.displayGameOver.Invoke(!playerId); }
    }

    public override int Heal(float heal)
    {
        int healValue = base.Heal(heal);
        ui.displayDamage.Invoke(healValue, playerId, false);
        ui.displayHP.Invoke(CurrentHP(), MaxHP(), playerId);

        return healValue;
    }

    public override void Heal(int heal)
    {
        base.Heal(heal);
        ui.displayDamage.Invoke(heal, playerId, false);
        ui.displayHP.Invoke(CurrentHP(), MaxHP(), playerId);
    }
}