using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CritSounds
{
    [Label("Crit Sounds Configuration")]
    public class CritSoundsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("The Crit Switch Palace")]

        [Label("Melee Stab Crits")]
        [Tooltip("If disabled, melee stabs will no longer play any crit sounds")]
        [DefaultValue(true)]
        public bool MeleeStabCrits_Enabled = true;

        [Label("General Projectile Crits")]
        [Tooltip("If disabled, projectile crits will no longer play any crit sounds")]
        [DefaultValue(true)]
        public bool ProjectileCrits_Enabled = true;

        [Label("Arrow Projectile Crits")]
        [Tooltip("Enables sounds for ranged damage type weapon crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeRanged_Enabled = true;

        [Label("Throwing Projectile Crits")]
        [Tooltip("Enables sounds for throwing damage type weapon crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeThrowing_Enabled = true;

        [Label("Magic Projectile Crits")]
        [Tooltip("Enables sounds for magic damage type weapon crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeMagic_Enabled = true;

        [Label("Melee Projectile Crits")]
        [Tooltip("Enables sounds for melee damage type, projectile based weapon crits (e.g. yoyos, shortswords, sword projectiles etc")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeMelee_Enabled = true;

        [Label("Summoning Projectile Crits")]
        [Tooltip("Enables crit sounds for summoned entities and whips")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeSummon_Enabled = true;

        [Label("Generic Projectile Crits")]
        [Tooltip("Enables crit sounds for generic damage type weapon crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeMisc_Enabled = true;

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
    }
}
