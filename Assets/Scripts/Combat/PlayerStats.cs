public class PlayerStats
{
    public int level;

    public System.Type skill1;
    public System.Type skill2;
    public System.Type skill3;
    public System.Type skill4;

    public float sleep;
    public float hunger;
    public float cleanliness;
    public float bloodthirst;

    public PlayerStats(System.Type skill1, System.Type skill2, System.Type skill3, System.Type skill4,
                            int level, float sleep, float hunger, float cleanliness, float bloodthirst)
    {
        this.level = level;

        this.skill1 = skill1;
        this.skill2 = skill2;
        this.skill3 = skill3;
        this.skill4 = skill4;
        
        this.sleep = sleep;
        this.hunger = hunger; 
        this.cleanliness = cleanliness;
        this.bloodthirst = bloodthirst;
    }

    public PlayerStats(int level)
    {
        this.level = level;
    }
    
    public void UpdateStatsFromHome(float sleepy, float hungry, float stinky, float bloodthirst)
    {
        this.sleep = 1f - Mathf.Clamp01(sleepy / 100f);
        this.hunger = Mathf.Clamp01(hungry / 100f);
        this.cleanliness = 1f - Mathf.Clamp01(stinky / 100f);
        this.bloodthirst = Mathf.Clamp01(bloodthirst / 100f);
    }
    
    public static PlayerStats GetHomeStats(Type skill1, Type skill2, Type skill3, Type skill4,
        int level, float sleepy, float hungry, float stinky, float bloodthirst)
    {
        PlayerStats stats = new PlayerStats(level)
        {
            skill1 = skill1,
            skill2 = skill2,
            skill3 = skill3,
            skill4 = skill4
        };
        
        stats.UpdateStatsFromHome(sleepy, hungry, stinky, bloodthirst);
        return stats;
    }
}