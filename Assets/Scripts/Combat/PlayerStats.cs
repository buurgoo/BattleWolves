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
}