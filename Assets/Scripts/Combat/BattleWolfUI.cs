using UnityEngine;

public abstract class BattleWolfUI : BattleWolf
{
    [SerializeField] private CombatUI ui;
    [SerializeField] public bool playerId;

    public override int TakeSkillDamage(int attackDamage) 
    { 
        int damage = base.TakeSkillDamage(attackDamage);
        ui.displayDamage.Invoke(damage, playerId);
        ui.displayHP.Invoke(GetCurrentHP(), GetMaxHP(), playerId);
        return damage;
    }

    public override void TakeDirectDamage(int attackDamage)
    {
        base.TakeDirectDamage(attackDamage);
        ui.displayDamage.Invoke(attackDamage, playerId);
        ui.displayHP.Invoke(GetCurrentHP(), GetMaxHP(), playerId);
    }
}