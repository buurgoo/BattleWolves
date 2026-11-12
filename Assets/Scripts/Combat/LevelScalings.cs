using System.Collections.Generic;

public static class LevelScalings
{
    public static Dictionary<int, LevelScaling> levelScalings = new Dictionary<int, LevelScaling>()
    {
        {
            10,
            new LevelScaling(100, 100, 1000)
        }
    };
}

public class LevelScaling
{
    public int Atk;
    public int Def;
    public int HP;

    public LevelScaling(int atk, int def, int hp)
    {
        Atk = atk;
        Def = def;
        HP = hp;
    }
}