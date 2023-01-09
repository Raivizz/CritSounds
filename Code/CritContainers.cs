using Terraria.Audio;
using Terraria.ModLoader;

namespace CritSounds.Code
{
    public static class CritContainers
    {
        // Initiates all of the sound styles used for the built-in crit sounds
        public static readonly SoundStyle MeleeStabCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/MeleeStab/MeleeStab_Crit", 4)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_MeleeStab_Volume
        };
        public static readonly SoundStyle TypeRangedCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeRanged/Type_Ranged", 5)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeRanged_Volume
        };
        public static readonly SoundStyle TypeThrowingCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit", 4)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeThrowing_Volume
        };
        public static readonly SoundStyle TypeMagicCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeMagic/Magic_Crit", 4)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeMagic_Volume
        };
        public static readonly SoundStyle TypeMeleeCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeMelee/Melee_Crit", 4)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeMelee_Volume
        };
        public static readonly SoundStyle TypeSummonCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeSummon/Summon_Crit", 4)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeSummon_Volume
        };
        public static readonly SoundStyle TypeGenericCritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Projectiles/TypeGeneric/Generic_Crit", 6)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeGeneric_Volume
        };
        public static readonly SoundStyle Egg01CritsSound = new($"{nameof(CritSounds)}/Sounds/Crits/Eggs/EggSet01/ES1_", 18)
        {
            PitchRange = (-0.25f, 0.5f),
            Volume = ModContent.GetInstance<CritSoundsConfig>().Mod_Egg01_Volume
        };
    }
}
