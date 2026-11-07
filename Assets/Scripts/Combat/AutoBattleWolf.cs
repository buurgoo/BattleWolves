public class AutoBattleWolf : BattleWolf
{
    public override void SelectSkill()
    {
        selectedSkill = new Bite();
        battleManager.PlayerSelectedSkill(this);
    }
}