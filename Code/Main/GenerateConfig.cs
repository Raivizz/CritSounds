using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace CritSounds
{
    public static class Config
    {
        /// <summary>Enable crit sounds on melee stabs.</summary>
        public static bool MeleeStabCrits_Enabled = true;
        /// <summary>Changes the volume of melee stabbing crits</summary>
        public static float MeleeStab_Volume = 1f;

        /// <summary>Enable projectile crit handlers.</summary>
        public static bool ProjectileCrits_Enabled = true;

        /// <summary>Enables crit sounds for arrow projectiles.</summary>
        public static bool ProjectileCrits_TypeArrow_Enabled = true;
        /// <summary>Changes the volume of arrow projectiles or modded ranged weapons</summary>
        public static float TypeArrow_Volume = 1f;

        /// <summary>Enables crit sounds for Throwing projectiles.</summary>
        public static bool ProjectileCrits_TypeThrowing_Enabled = true;
        /// <summary>Changes the volume of throw-able weapons or modded throwing-type weapons</summary>
        public static float TypeThrowing_Volume = 1f;

        /// <summary>Enables crit sounds for magic projectiles.</summary>
        public static bool ProjectileCrits_TypeSpell_Enabled = true;
        /// <summary>Changes the volume of magic-based weapons</summary>
        public static float TypeSpell_Volume = 1f;

        /// <summary>Enables crit sounds for bullet projectiles.</summary>
        public static bool ProjectileCrits_TypeBullet_Enabled = true;
        /// <summary>Changes the volume of bullet-based vanilla weapons</summary>
        public static float TypeBullet_Volume = 1f;

        /// <summary>Enables crit sounds for melee projectiles and weaponry.</summary>
        public static bool ProjectileCrits_TypeMelee_Enabled = true;
        /// <summary>Changes the volume of melee-based ranged weaponry, yoyos, or modded melee-damage-type weapons</summary>
        public static float TypeMelee_Volume = 1f;

        /// <summary>Enables crit sounds for summoned entities.</summary>
        public static bool ProjectileCrits_TypeSummon_Enabled = true;
        /// <summary>Changes the volume of summoned minions and sentries</summary>
        public static float TypeSummon_Volume = 1f;

        /// <summary>Enables crit sounds for miscellaneous projectiles.</summary>
        public static bool ProjectileCrits_TypeMisc_Enabled = true;
        /// <summary>Changes the volume of miscellaneous projectiles, such as seeds and others.</summary>
        public static float TypeMisc_Volume = 1f;

        /// <summary>Enables crit sounds for undefined projectiles.</summary>
        public static bool ProjectileCrits_TypeUnknown_Enabled = true;
        /// <summary>Changes the volume of undefined projectiles, mostly modded weapons with custom damage types or modded summoner weapons.</summary>
        public static float TypeUnknown_Volume = 1f;

        /// <summary>Changes the volume for the Egg 01 batch. If you think I'm gonna spoil it here for ya, you're wrong. Then again, you are reading the code, so you might as well just find where this is looked up and just trace the item ID.</summary>
        public static float Egg01_Volume = 1f;

        //Custom sound volume
        /// <summary>Change the volume of custom melee stabbing crit sounds.</summary>
        public static float Mod_MeleeStab_Volume = 1f;
        /// <summary>Change the volume of custom arrow-based weapon crit sounds.</summary>
        public static float Mod_TypeArrow_Volume = 1f;
        /// <summary>Change the volume of custom throw-able weaponry crit sounds.</summary>
        public static float Mod_TypeThrowing_Volume = 1f;
        /// <summary>Change the volume of custom magic-based weaponry crit sounds.</summary>
        public static float Mod_TypeSpell_Volume = 1f;
        /// <summary>Change the volume of custom bullet-based weaponry crit sounds.</summary>
        public static float Mod_TypeBullet_Volume = 1f;
        /// <summary>Change the volume of custom melee-based crit sounds.</summary>
        public static float Mod_TypeMelee_Volume = 1f;
        /// <summary>Change the volume of custom summoned entity crit sounds</summary>
        public static float Mod_TypeSummon_Volume = 1f;
        /// <summary>Change the volume of custom miscellaneous projectile crit sounds.</summary>
        public static float Mod_TypeMisc_Volume = 1f;
        /// <summary>Change the volume of unknown projectile crit sounds.</summary>
        public static float Mod_TypeUnknown_Volume = 1f;

        /// <summary>Changes the sound frequency used to initialize BASS. Only change if you know what you're doing!</summary>
        public static int BASSDeviceFrequency = 44100;

        /// <summary>Enables AAC addon support for BASS. bass_aac.dll weighs 147KB</summary>
        public static bool BASSAddon_EnableAACAddon = false;
        /// <summary>Enables FLAC addon support for BASS. bassflac.dll weighs 25KB</summary>
        public static bool BASSAddon_EnableFLACAddon = false;
        /// <summary>Enables OPUS addon support for BASS. bassopus.dll weighs 68KB</summary>
        public static bool BASSAddon_EnableOPUSAddon = false;
        /// <summary>Enables WMA addon support for BASS. basswma.dll weighs 18KB</summary>
        public static bool BASSAddon_EnableWMAAddon = false;

        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Crit Sounds v123.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            bool success = ReadConfig();

            if (!success)
            {
                ErrorLogger.Log("Required config missing or unreadable. Creating a new config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("MeleeStabCrits_Enabled", ref MeleeStabCrits_Enabled);

                Configuration.Get("ProjectileCrits_Enabled", ref ProjectileCrits_Enabled);
                Configuration.Get("ProjectileCrits_TypeArrow_Enabled", ref ProjectileCrits_TypeArrow_Enabled);
                Configuration.Get("ProjectileCrits_TypeThrowing_Enabled", ref ProjectileCrits_TypeThrowing_Enabled);
                Configuration.Get("ProjectileCrits_TypeSpell_Enabled", ref ProjectileCrits_TypeSpell_Enabled);
                Configuration.Get("ProjectileCrits_TypeBullet_Enabled", ref ProjectileCrits_TypeBullet_Enabled);
                Configuration.Get("ProjectileCrits_TypeMelee_Enabled", ref ProjectileCrits_TypeMelee_Enabled);
                Configuration.Get("ProjectileCrits_TypeSummon_Enabled", ref ProjectileCrits_TypeSummon_Enabled);
                Configuration.Get("ProjectileCrits_TypeMisc_Enabled", ref ProjectileCrits_TypeMisc_Enabled);
                Configuration.Get("ProjectileCrits_TypeUnknown_Enabled", ref ProjectileCrits_TypeUnknown_Enabled);

                Configuration.Get("BASSDeviceFrequency", ref BASSDeviceFrequency);

                Configuration.Get("MeleeStab_Volume", ref MeleeStab_Volume);
                Configuration.Get("TypeArrow_Volume", ref TypeArrow_Volume);
                Configuration.Get("TypeThrowing_Volume", ref TypeThrowing_Volume);
                Configuration.Get("TypeSpell_Volume", ref TypeSpell_Volume);
                Configuration.Get("TypeBullet_Volume", ref TypeBullet_Volume);
                Configuration.Get("TypeMelee_Volume", ref TypeMelee_Volume);
                Configuration.Get("TypeSummon_Volume", ref TypeSummon_Volume);
                Configuration.Get("TypeMisc_Volume", ref TypeMisc_Volume);
                Configuration.Get("TypeUnknown_Volume", ref TypeUnknown_Volume);

                Configuration.Get("Egg01_Volume", ref Egg01_Volume);

                Configuration.Get("Mod_MeleeStab_Volume", ref Mod_MeleeStab_Volume);
                Configuration.Get("Mod_TypeArrow_Volume", ref Mod_TypeArrow_Volume);
                Configuration.Get("Mod_TypeThrowing_Volume", ref Mod_TypeThrowing_Volume);
                Configuration.Get("Mod_TypeSpell_Volume", ref Mod_TypeSpell_Volume);
                Configuration.Get("Mod_TypeBullet_Volume", ref Mod_TypeBullet_Volume);
                Configuration.Get("Mod_TypeMelee_Volume", ref Mod_TypeMelee_Volume);
                Configuration.Get("Mod_TypeSummon_Volume", ref Mod_TypeSummon_Volume);
                Configuration.Get("Mod_TypeMisc_Volume", ref Mod_TypeMisc_Volume);
                Configuration.Get("Mod_TypeUnknown_Volume", ref Mod_TypeUnknown_Volume);

                Configuration.Get("BASSAddon_EnableAACAddon", ref BASSAddon_EnableAACAddon);
                Configuration.Get("BASSAddon_EnableFLACAddon", ref BASSAddon_EnableFLACAddon);
                Configuration.Get("BASSAddon_EnableOPUSAddon", ref BASSAddon_EnableOPUSAddon);
                Configuration.Get("BASSAddon_EnableWMAAddon", ref BASSAddon_EnableWMAAddon);

                return true;
            }
            return false;
        }

        static void CreateConfig()
        {
            Configuration.Clear();

            Configuration.Put("MeleeStabCrits_Enabled", MeleeStabCrits_Enabled);

            Configuration.Put("ProjectileCrits_Enabled", ProjectileCrits_Enabled);
            Configuration.Put("ProjectileCrits_TypeArrow_Enabled", ProjectileCrits_TypeArrow_Enabled);
            Configuration.Put("ProjectileCrits_TypeThrowing_Enabled", ProjectileCrits_TypeThrowing_Enabled);
            Configuration.Put("ProjectileCrits_TypeSpell_Enabled", ProjectileCrits_TypeSpell_Enabled);
            Configuration.Put("ProjectileCrits_TypeBullet_Enabled", ProjectileCrits_TypeBullet_Enabled);
            Configuration.Put("ProjectileCrits_TypeMelee_Enabled", ProjectileCrits_TypeMelee_Enabled);
            Configuration.Put("ProjectileCrits_TypeSummon_Enabled", ProjectileCrits_TypeSummon_Enabled);
            Configuration.Put("ProjectileCrits_TypeMisc_Enabled", ProjectileCrits_TypeMisc_Enabled);
            Configuration.Put("ProjectileCrits_TypeUnknown_Enabled", ProjectileCrits_TypeUnknown_Enabled);

            Configuration.Put("BASSDeviceFrequency", BASSDeviceFrequency);

            Configuration.Put("MeleeStab_Volume", MeleeStab_Volume);
            Configuration.Put("TypeArrow_Volume", TypeArrow_Volume);
            Configuration.Put("TypeThrowing_Volume", TypeThrowing_Volume);
            Configuration.Put("TypeSpell_Volume", TypeSpell_Volume);
            Configuration.Put("TypeBullet_Volume", TypeBullet_Volume);
            Configuration.Put("TypeMelee_Volume", TypeMelee_Volume);
            Configuration.Put("TypeSummon_Volume", TypeSummon_Volume);
            Configuration.Put("TypeMisc_Volume", TypeMisc_Volume);
            Configuration.Put("TypeUnknown_Volume", TypeUnknown_Volume);

            Configuration.Put("Egg01_Volume", Egg01_Volume);

            Configuration.Put("Mod_MeleeStab_Volume", Mod_MeleeStab_Volume);
            Configuration.Put("Mod_TypeArrow_Volume", Mod_TypeArrow_Volume);
            Configuration.Put("Mod_TypeThrowing_Volume", Mod_TypeThrowing_Volume);
            Configuration.Put("Mod_TypeSpell_Volume", Mod_TypeSpell_Volume);
            Configuration.Put("Mod_TypeBullet_Volume", Mod_TypeBullet_Volume);
            Configuration.Put("Mod_TypeMelee_Volume", Mod_TypeMelee_Volume);
            Configuration.Put("Mod_TypeSummon_Volume", Mod_TypeSummon_Volume);
            Configuration.Put("Mod_TypeMisc_Volume", Mod_TypeMisc_Volume);
            Configuration.Put("Mod_TypeUnknown_Volume", Mod_TypeUnknown_Volume);

            Configuration.Put("BASSAddon_EnableAACAddon", BASSAddon_EnableAACAddon);
            Configuration.Put("BASSAddon_EnableFLACAddon", BASSAddon_EnableFLACAddon);
            Configuration.Put("BASSAddon_EnableOPUSAddon", BASSAddon_EnableOPUSAddon);
            Configuration.Put("BASSAddon_EnableWMAAddon", BASSAddon_EnableWMAAddon);

            Configuration.Save();
        }
    }
}