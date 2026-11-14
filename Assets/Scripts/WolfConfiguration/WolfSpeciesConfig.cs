using UnityEngine;

namespace WolfConfiguration
{
    [CreateAssetMenu(fileName = "StandardWolf", menuName = "BattleWolves/Wolf Species Config")]
    public class WolfSpeciesConfig : ScriptableObject
    {
        [Header("Species Info")]
        public string speciesName = "Gray Wolf";
        public int defaultLevel = 10;

        // anythingg sleep retaled here
        [Header("Needs & Modifiers")]
        [Range(0f, 1f)] public float lowSleepThreshold = 0.5f;
        public float lowSleepAtkMod = -0.3f;
        public float lowSleepDefMod = -0.3f;

        // hungeeer
        [Range(0f, 1f)] public float starvingHungerThreshold = 0.75f;
        public float starvingAtkMod = -0.5f;
        public float starvingHpMod = -0.1f;

        [Range(0f, 1f)] public float hungryThreshold = 0.5f;
        public float hungryAtkMod = 0.1f;
        public float hungryHpMod = -0.1f;

        // cleanliness
        [Range(0f, 1f)] public float dirtyCleanlinessThreshold = 0.5f;
        public float dirtyDefMod = 0.2f;
        public float dirtyHpMod = -0.4f;
    
        // blood
        [Range(0f, 1f)] public float highBloodthirstThreshold = 0.5f;
        public float highBloodthirstAtkMod = 0.5f;
        public float highBloodthirstDefMod = -0.5f;

        public void ApplyNeedModifiers(PlayerStats stats, ref float obtainedAtk, ref float obtainedDef, ref float obtainedHP)
        {
            if (stats.sleep < lowSleepThreshold)
            {
                obtainedAtk += lowSleepAtkMod;
                obtainedDef += lowSleepDefMod;
            }

            if (stats.hunger > starvingHungerThreshold)
            {
                obtainedAtk += starvingAtkMod;
                obtainedHP += starvingHpMod;
            }
            else if (stats.hunger > hungryThreshold)
            {
                obtainedAtk += hungryAtkMod;
                obtainedHP += hungryHpMod;
            }

            if (stats.cleanliness < dirtyCleanlinessThreshold)
            {
                obtainedDef += dirtyDefMod;
                obtainedHP += dirtyHpMod;
            }

            if (stats.bloodthirst > highBloodthirstThreshold)
            {
                obtainedAtk += highBloodthirstAtkMod;
                obtainedDef += highBloodthirstDefMod;
            }
        }
    }
}