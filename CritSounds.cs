using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using Terraria.ModLoader.IO;

namespace CritSounds
{
	class CritSounds : Mod
	{
		public bool LoadedFKTModSettings = false;
		
		public CritSounds()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadSounds = true
			};
		}
		public override void Load()
		{
			Config.Load();
			
			LoadedFKTModSettings = ModLoader.GetMod ("FKTModSettings") != null;
            if (LoadedFKTModSettings)
            {
                try { LoadModSettings(); }
                catch { }
            }
		}
		private void LoadModSettings()
        {
            FKTModSettings.ModSetting setting = FKTModSettings.ModSettingsAPI.CreateModSettingConfig(this);
            setting.EnableAutoConfig();

			setting.AddComment("Welcome to the Critical Tweakery Menu!");
			
            setting.AddBool("MeleeStabCrits_Enabled", 					"Enable crit sounds for melee stabs", false);
			setting.AddBool("ProjectileCrits_Enabled", 					"Enable projectile crits", false);
			
			setting.AddComment("If projectile crits are enabled, the settings below can be used to toggle crit sounds for specific projectile types");
			
			setting.AddBool("ProjectileCrits_TypeArrow_Enabled", 		"Enable crit sounds for arrow-based weapons", false);
			setting.AddBool("ProjectileCrits_TypeThrowable_Enabled", 	"Enable crit sounds for throw-able weapons",	false);
			setting.AddBool("ProjectileCrits_TypeSpell_Enabled", 		"Enable crit sounds for magic weapons",	false);
			setting.AddBool("ProjectileCrits_TypeBullet_Enabled", 		"Enable crit sounds for bullet-based weapons",	false);
			setting.AddBool("ProjectileCrits_TypeMelee_Enabled", 		"Enable crit sounds for projectile-based ranged weaponry",	false);
			setting.AddBool("ProjectileCrits_TypeSummon_Enabled", 		"Enable crit sounds for summoned entities",	false);
			setting.AddBool("ProjectileCrits_TypeMisc_Enabled", 		"Enable crit sounds for miscellaneous projectiles",	false);
			setting.AddBool("ProjectileCrits_TypeUnknown_Enabled", 		"Enable crit sounds for undefined projectiles",	false);
        }
		public override void PostUpdateInput()
        {
            if (LoadedFKTModSettings && !Main.gameMenu)
            {
                try { UpdateModSettings(); }
                catch { }
            }
        }
		private void UpdateModSettings()
        {
            FKTModSettings.ModSetting setting;
			
            if (FKTModSettings.ModSettingsAPI.TryGetModSetting (this, out setting))
            {
				setting.Get("MeleeStabCrits_Enabled", 						ref Config.MeleeStabCrits_Enabled);
				setting.Get("ProjectileCrits_Enabled", 						ref Config.ProjectileCrits_Enabled);
				setting.Get("ProjectileCrits_TypeArrow_Enabled", 			ref Config.ProjectileCrits_TypeArrow_Enabled);
				setting.Get("ProjectileCrits_TypeThrowable_Enabled", 		ref Config.ProjectileCrits_TypeThrowable_Enabled);
				setting.Get("ProjectileCrits_TypeSpell_Enabled", 			ref Config.ProjectileCrits_TypeSpell_Enabled);
				setting.Get("ProjectileCrits_TypeBullet_Enabled", 			ref Config.ProjectileCrits_TypeBullet_Enabled);
				setting.Get("ProjectileCrits_TypeMelee_Enabled", 			ref Config.ProjectileCrits_TypeMelee_Enabled);
				setting.Get("ProjectileCrits_TypeSummon_Enabled", 			ref Config.ProjectileCrits_TypeSummon_Enabled);
				setting.Get("ProjectileCrits_TypeMisc_Enabled", 			ref Config.ProjectileCrits_TypeMisc_Enabled);
				setting.Get("ProjectileCrits_TypeUnknown_Enabled", 			ref Config.ProjectileCrits_TypeUnknown_Enabled);
            }
        }
	}
}
