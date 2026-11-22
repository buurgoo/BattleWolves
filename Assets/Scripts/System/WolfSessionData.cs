using UnityEngine;
using System.Collections.Generic;

namespace System
{
    public static class WolfSessionData
    {
        public static int level = 10;
        public static int Money = 10000; // Temp value for debug
        
        public static float currentXP = 0f;
        public static float requiredXP = 100f;

        public static Type skill1 = typeof(Bite);
        public static Type skill2 = typeof(Scratch);
        public static Type skill3 = typeof(LickWounds);
        public static Type skill4 = typeof(BodySlam);

        public static float sleepy = 0f;
        public static float hungry = 0f;
        public static float stinky = 0f;
        public static float bloodthirst = 0f;

        public static void SaveNeeds(float currentSleepy, float currentHungry, float currentStinky, float currentBloodthirst)
        {
            sleepy = Mathf.Clamp(currentSleepy, 0f, 100f);
            hungry = Mathf.Clamp(currentHungry, 0f, 100f);
            stinky = Mathf.Clamp(currentStinky, 0f, 100f);
            bloodthirst = Mathf.Clamp(currentBloodthirst, 0f, 100f);
        }
        
        public static void AddRewards(float xpGain, int moneyGain)
        {
            currentXP += xpGain;
            Money += moneyGain;

            while (currentXP >= requiredXP)
            {
                currentXP -= requiredXP;
                level++;
                requiredXP *= 1.2f;
            }
        }

        public static PlayerStats BuildBattleStats()
        {
            return PlayerStats.GetHomeStats(
                skill1, skill2, skill3, skill4,
                level, sleepy, hungry, stinky, bloodthirst
            );
        }
    }
}