public class AutoBattleWolf : BattleWolfUI
{
    public override void SelectSkill()
    {
        selectedSkill = new Bite();
        battleManager.PlayerSelectedSkill(this);
    }
}