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
        /// <summary>Enable projectile crit handlers.</summary>
        public static bool ProjectileCrits_Enabled = true;

        /// <summary>Enables crit sounds for arrow projectiles.</summary>
        public static bool ProjectileCrits_TypeArrow_Enabled = true;
        /// <summary>Enables crit sounds for Throwing projectiles.</summary>
        public static bool ProjectileCrits_TypeThrowing_Enabled = true;
        /// <summary>Enables crit sounds for magic projectiles.</summary>
        public static bool ProjectileCrits_TypeSpell_Enabled = true;
        /// <summary>Enables crit sounds for bullet projectiles.</summary>
        public static bool ProjectileCrits_TypeBullet_Enabled = true;
        /// <summary>Enables crit sounds for melee projectiles and weaponry.</summary>
        public static bool ProjectileCrits_TypeMelee_Enabled = true;
        /// <summary>Enables crit sounds for summoned entities.</summary>
        public static bool ProjectileCrits_TypeSummon_Enabled = true;
        /// <summary>Enables crit sounds for miscellaneous projectiles.</summary>
        public static bool ProjectileCrits_TypeMisc_Enabled = true;
        /// <summary>Enables crit sounds for undefined projectiles.</summary>
        public static bool ProjectileCrits_TypeUnknown_Enabled = true;

        /// <summary>Changes the sound frequency used to initialize BASS. Only change if you know what you're doing!</summary>
        public static int BASSDeviceFrequency = 44100;

        /// <summary>Enables AAC addon support for BASS. bass_aac.dll weighs 147KB</summary>
        public static bool BASSAddon_EnableAACAddon = false;
        /// <summary>Enables AC3 addon support for BASS. bass_ac3.dll weighs 16KB</summary>
        public static bool BASSAddon_EnableAC3Addon = false;
        /// <summary>Enables ADX addon support for BASS. bass_adx.dll weighs 15KB</summary>
        public static bool BASSAddon_EnableADXAddon = false;
        /// <summary>Enables AIX addon support for BASS. bass_aix.dll weighs 20KB</summary>
        public static bool BASSAddon_EnableAIXAddon = false;
        /// <summary>Enables APE addon support for BASS. bass_ape.dll weighs 29KB</summary>
        public static bool BASSAddon_EnableAPEAddon = false;
        /// <summary>Enables MPC addon support for BASS. bass_mpc.dll weighs 21KB</summary>
        public static bool BASSAddon_EnableMPCAddon = false;
        /// <summary>Enables SPX addon support for BASS. bass_spx.dll weighs 36KB</summary>
        public static bool BASSAddon_EnableSPXAddon = false;
        /// <summary>Enables TTA addon support for BASS. bass_tta.dll weighs 8KB</summary>
        public static bool BASSAddon_EnableTTAAddon = false;
        /// <summary>Enables FLAC addon support for BASS. bassflac.dll weighs 25KB</summary>
        public static bool BASSAddon_EnableFLACAddon = false;
        /// <summary>Enables OPUS addon support for BASS. bassopus.dll weighs 68KB</summary>
        public static bool BASSAddon_EnableOPUSAddon = false;
        /// <summary>Enables WMA addon support for BASS. basswma.dll weighs 18KB</summary>
        public static bool BASSAddon_EnableWMAAddon = false;
        /// <summary>Enables WV addon support for BASS. basswv.dll weighs 35KB</summary>
        public static bool BASSAddon_EnableWVAddon = false;
        /// <summary>Enables ZXTune addon support for BASS. basszxtune.dll weighs 10,792KB</summary>
        //  public static bool BASSAddon_EnableZXTuneAddon = false;

        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Crit Sounds v120.json");
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

                Configuration.Get("BASSAddon_EnableAACAddon", ref BASSAddon_EnableAACAddon);
                Configuration.Get("BASSAddon_EnableAC3Addon", ref BASSAddon_EnableAC3Addon);
                Configuration.Get("BASSAddon_EnableADXAddon", ref BASSAddon_EnableADXAddon);
                Configuration.Get("BASSAddon_EnableAIXAddon", ref BASSAddon_EnableAIXAddon);
                Configuration.Get("BASSAddon_EnableAPEAddon", ref BASSAddon_EnableAPEAddon);
                Configuration.Get("BASSAddon_EnableMPCAddon", ref BASSAddon_EnableMPCAddon);
                Configuration.Get("BASSAddon_EnableSPXAddon", ref BASSAddon_EnableSPXAddon);
                Configuration.Get("BASSAddon_EnableTTAAddon", ref BASSAddon_EnableTTAAddon);
                Configuration.Get("BASSAddon_EnableFLACAddon", ref BASSAddon_EnableFLACAddon);
                Configuration.Get("BASSAddon_EnableOPUSAddon", ref BASSAddon_EnableOPUSAddon);
                Configuration.Get("BASSAddon_EnableWMAAddon", ref BASSAddon_EnableWMAAddon);
                Configuration.Get("BASSAddon_EnableWVAddon", ref BASSAddon_EnableWVAddon);
                //Configuration.Get("BASSAddon_EnableZXTuneAddon", ref BASSAddon_EnableZXTuneAddon);

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

            Configuration.Put("BASSAddon_EnableAACAddon", BASSAddon_EnableAACAddon);
            Configuration.Put("BASSAddon_EnableAC3Addon", BASSAddon_EnableAC3Addon);
            Configuration.Put("BASSAddon_EnableADXAddon", BASSAddon_EnableADXAddon);
            Configuration.Put("BASSAddon_EnableAIXAddon", BASSAddon_EnableAIXAddon);
            Configuration.Put("BASSAddon_EnableAPEAddon", BASSAddon_EnableAPEAddon);
            Configuration.Put("BASSAddon_EnableMPCAddon", BASSAddon_EnableMPCAddon);
            Configuration.Put("BASSAddon_EnableSPXAddon", BASSAddon_EnableSPXAddon);
            Configuration.Put("BASSAddon_EnableTTAAddon", BASSAddon_EnableTTAAddon);
            Configuration.Put("BASSAddon_EnableFLACAddon", BASSAddon_EnableFLACAddon);
            Configuration.Put("BASSAddon_EnableOPUSAddon", BASSAddon_EnableOPUSAddon);
            Configuration.Put("BASSAddon_EnableWMAAddon", BASSAddon_EnableWMAAddon);
            Configuration.Put("BASSAddon_EnableWVAddon", BASSAddon_EnableWVAddon);
            //Configuration.Put("BASSAddon_EnableZXTuneAddon", BASSAddon_EnableZXTuneAddon);

            Configuration.Save();
        }
    }
}