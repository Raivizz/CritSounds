using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CritSounds
{
    [Label("Crit Sounds Configuration")]
    public class CritSoundsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static CritSoundsConfig Instance;

        [Header("Crit Toggles")]

        [Label("Melee Stab Crits")]
        [Tooltip("Enable crit sounds for melee stabs")]
        [DefaultValue(true)]
        public bool MeleeStabCrits_Enabled = true;

        [Label("General Projectile Crits")]
        [Tooltip("Enable projectile crit handlers")]
        [DefaultValue(true)]
        public bool ProjectileCrits_Enabled = true;

        [Label("Arrow Projectile Crits")]
        [Tooltip("Enable crit sounds for arrow projectiles")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeArrow_Enabled = true;

        [Label("Throwing Projectile Crits")]
        [Tooltip("Enable crit sounds for throwing projectile crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeThrowing_Enabled = true;

        [Label("Magic Projectile Crits")]
        [Tooltip("Enable crit sounds for magic projectile crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeSpell_Enabled = true;

        [Label("Bullet Projectile Crits")]
        [Tooltip("Enable crit sounds for bullet projectile crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeBullet_Enabled = true;

        [Label("Melee Projectile Crits")]
        [Tooltip("Enable crit sounds for melee projectile and weaponry crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeMelee_Enabled = true;

        [Label("Summoning Projectile Crits")]
        [Tooltip("Enable crit sounds for summoned entities and whips")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeSummon_Enabled = true;

        [Label("Miscellaneous Projectile Crits")]
        [Tooltip("Enable crit sounds for miscellaneous projectile crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeMisc_Enabled = true;

        [Label("Unknown Projectile Crits")]
        [Tooltip("Enable crit sounds for undefined projectile crits")]
        [DefaultValue(true)]
        public bool ProjectileCrits_TypeUnknown_Enabled = true;

        [Header("Built-in Crit Sounds Volume")]

        [Label("Melee Stab Crits - Volume")]
        [Tooltip("Volume of melee stab crits")]
        [DefaultValue(1f)]
        public float MeleeStab_Volume = 1f;

        [Label("Arrow Projectile Crits - Volume")]
        [Tooltip("Volume of arrow projectile or modded ranged weapon crits")]
        [DefaultValue(1f)]
        public float TypeArrow_Volume = 1f;

        [Label("Throwing Projectile Crits - Volume")]
        [Tooltip("Volume of throwable weapon or modded throwing-type weapon crits")]
        [DefaultValue(1f)]
        public float TypeThrowing_Volume = 1f;

        [Label("Magic Projectile Crits - Volume")]
        [Tooltip("Volume of magic-based weapon crits")]
        [DefaultValue(1f)]
        public float TypeSpell_Volume = 1f;

        [Label("Bullet Projectile Crits - Volume")]
        [Tooltip("Volume of bullet-based vanilla weapon crits")]
        [DefaultValue(1f)]
        public float TypeBullet_Volume = 1f;

        [Label("Melee Projectile Crits - Volume")]
        [Tooltip("Volume of melee-based ranged weaponry, yoyo or modded melee-damage-type weapon crits")]
        [DefaultValue(1f)]
        public float TypeMelee_Volume = 1f;

        [Label("Summoning Projectile Crits - Volume")]
        [Tooltip("Volume of summoned entity and whip crits")]
        [DefaultValue(1f)]
        public float TypeSummon_Volume = 1f;

        [Label("Miscellaneous Projectile Crits - Volume")]
        [Tooltip("Volume of miscellaneous projectile, such as seeds, and other such type crits")]
        [DefaultValue(1f)]
        public float TypeMisc_Volume = 1f;

        [Label("Unknown Projectile Crits - Volume")]
        [Tooltip("Volume of undefined projectile crits")]
        [DefaultValue(1f)]
        public float TypeUnknown_Volume = 1f;

        [Label("Egg 01 Crits - Volume")]
        [Tooltip("Volume of Easter Egg Set 01 crits")]
        [DefaultValue(1f)]
        public float Egg01_Volume = 1f;

        [Header("Custom Crit Sounds Volume")]

        [Label("Custom Melee Stab Crits - Volume")]
        [Tooltip("Volume of custom melee stabbing crits")]
        [DefaultValue(1f)]
        public float Mod_MeleeStab_Volume = 1f;

        [Label("Custom Arrow Crits - Volume")]
        [Tooltip("Volume of custom arrow-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeArrow_Volume = 1f;

        [Label("Custom Throwing Crits - Volume")]
        [Tooltip("Volume of custom throwing-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeThrowing_Volume = 1f;

        [Label("Custom Magic Crits- - Volume")]
        [Tooltip("Volume of custom magic-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeSpell_Volume = 1f;

        [Label("Custom Bullet Crits - Volume")]
        [Tooltip("Volume of custom bullet-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeBullet_Volume = 1f;

        [Label("Custom Melee Crits - Volume")]
        [Tooltip("Volume of custom melee-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeMelee_Volume = 1f;

        [Label("Custom Summon Crits - Volume")]
        [Tooltip("Volume of custom summon-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeSummon_Volume = 1f;

        [Label("Custom Misc Crits - Volume")]
        [Tooltip("Volume of custom misc-based weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeMisc_Volume = 1f;

        [Label("Custom Unknown Crits - Volume")]
        [Tooltip("Volume of custom unknown weapon crits")]
        [DefaultValue(1f)]
        public float Mod_TypeUnknown_Volume = 1f;
    }
}