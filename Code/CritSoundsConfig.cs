using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CritSounds
{
    [Label("Crit Sounds Configuration")]
    public abstract class CritSoundsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("The Crit Switch Palace")]
        [Label("Melee Stab Crits")]
        [Tooltip("If disabled, melee stabs will no longer play any crit sounds")]
        [DefaultValue(true)]
        public bool MeleeStabCrits_Enabled = true;

        [Label("Projectile Crits")]
        [Tooltip("If disabled, projectile crits will no longer play any crit sounds")]
        [DefaultValue(true)]
        public bool ProjectileCrits_Enabled = true;

        [Header("Custom Crit Sounds - Volume")]
        [Label("Custom Melee Stab Crits - Volume")]
        [Tooltip("Volume of custom melee stabbing crits")]
        [DefaultValue(1f)]
        public float Mod_MeleeStab_Volume = 1f;

        [Label("Custom Ranged Crits - Volume")]
        [Tooltip("Volume of custom ranged damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeRanged_Volume = 1f;

        [Label("Custom Throwing Crits - Volume")]
        [Tooltip("Volume of custom throwing damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeThrowing_Volume = 1f;

        [Label("Custom Magic Crits - Volume")]
        [Tooltip("Volume of custom magic damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeMagic_Volume = 1f;

        [Label("Custom Melee Crits - Volume")]
        [Tooltip("Volume of custom melee damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeMelee_Volume = 1f;

        [Label("Custom Summon Crits - Volume")]
        [Tooltip("Volume of custom summon damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeSummon_Volume = 1f;

        [Label("Custom Generic Crits - Volume")]
        [Tooltip("Volume of custom generic damage type weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeGeneric_Volume = 1f;

        [Label("Custom Egg 01 Crits - Volume")] 
        [Tooltip("Volume of custom Egg 01 weapon crits")] 
        [DefaultValue(1f)]  
        public float Mod_Egg01_Volume = 1f;
    }
}
