public abstract class AutoBattleWolf : BattleWolfUI
{
    public override PlayerStats playerStats
    {
        get
        {
            return new PlayerStats(10);
        }
    }

    public override void InitBaseStats()
    {
        _baseAtk = LevelScalings.levelScalings[playerStats.level].Atk;
        _baseDef = LevelScalings.levelScalings[playerStats.level].Def;
        _baseHP = LevelScalings.levelScalings[playerStats.level].HP;
    }
}