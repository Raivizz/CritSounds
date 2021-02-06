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
		/// <summary>Enables crit sounds for throwable projectiles.</summary>
		public static bool ProjectileCrits_TypeThrowable_Enabled = true;
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
		
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Crit Sounds v110.json");
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
				Configuration.Get("MeleeStabCrits_Enabled", 					ref MeleeStabCrits_Enabled);
				
				Configuration.Get("ProjectileCrits_Enabled", 					ref ProjectileCrits_Enabled);
				Configuration.Get("ProjectileCrits_TypeArrow_Enabled", 			ref ProjectileCrits_TypeArrow_Enabled);
				Configuration.Get("ProjectileCrits_TypeThrowable_Enabled", 		ref ProjectileCrits_TypeThrowable_Enabled);
				Configuration.Get("ProjectileCrits_TypeSpell_Enabled", 			ref ProjectileCrits_TypeSpell_Enabled);
				Configuration.Get("ProjectileCrits_TypeBullet_Enabled", 		ref ProjectileCrits_TypeBullet_Enabled);
				Configuration.Get("ProjectileCrits_TypeMelee_Enabled", 			ref ProjectileCrits_TypeMelee_Enabled);
				Configuration.Get("ProjectileCrits_TypeSummon_Enabled", 		ref ProjectileCrits_TypeSummon_Enabled);
				Configuration.Get("ProjectileCrits_TypeMisc_Enabled", 			ref ProjectileCrits_TypeMisc_Enabled);
				Configuration.Get("ProjectileCrits_TypeUnknown_Enabled", 		ref ProjectileCrits_TypeUnknown_Enabled);
				
				return true;
            }
            return false;
        }

        static void CreateConfig()
        {
            Configuration.Clear();
					
			Configuration.Put("MeleeStabCrits_Enabled", 				MeleeStabCrits_Enabled);
			Configuration.Put("ProjectileCrits_Enabled", 				ProjectileCrits_Enabled);
			Configuration.Put("ProjectileCrits_TypeArrow_Enabled", 		ProjectileCrits_TypeArrow_Enabled);
			Configuration.Put("ProjectileCrits_TypeThrowable_Enabled", 	ProjectileCrits_TypeThrowable_Enabled);
			Configuration.Put("ProjectileCrits_TypeSpell_Enabled", 		ProjectileCrits_TypeSpell_Enabled);
			Configuration.Put("ProjectileCrits_TypeBullet_Enabled", 	ProjectileCrits_TypeBullet_Enabled);
			Configuration.Put("ProjectileCrits_TypeMelee_Enabled", 		ProjectileCrits_TypeMelee_Enabled);
			Configuration.Put("ProjectileCrits_TypeSummon_Enabled", 	ProjectileCrits_TypeSummon_Enabled);
			Configuration.Put("ProjectileCrits_TypeMisc_Enabled", 		ProjectileCrits_TypeMisc_Enabled);
			Configuration.Put("ProjectileCrits_TypeUnknown_Enabled", 	ProjectileCrits_TypeUnknown_Enabled);
			
            Configuration.Save();
        }
    }
}