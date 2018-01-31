using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Policy;
using Terraria.ModLoader.IO;
using Un4seen.Bass;

namespace CritSounds
{
    class CritSounds : Mod
    {
        public bool LoadedFKTModSettings = false;

        public CritSounds()
        {
            CritModdingFramework critDir = new CritModdingFramework();
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadSounds = true
            };

            critDir.CreateDirectories();
        }

        public override void Load()
        {
            Config.Load();

            LoadedFKTModSettings = ModLoader.GetMod("FKTModSettings") != null;
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

            setting.AddBool("MeleeStabCrits_Enabled", "Enable crit sounds for melee stabs", false);
            setting.AddFloat("MeleeStab_Volume", "Change the volume of melee stab crits", 0f, 1f, false);
            setting.AddBool("ProjectileCrits_Enabled", "Enable projectile crits", false);

            setting.AddComment("If projectile crits are enabled, the settings below can be used to toggle and change the volume of crit sounds for specific projectile types");

            setting.AddBool("ProjectileCrits_TypeArrow_Enabled", "Enable crit sounds for arrow-based weapons", false);
            setting.AddBool("ProjectileCrits_TypeThrowing_Enabled", "Enable crit sounds for throw-able weapons", false);
            setting.AddBool("ProjectileCrits_TypeSpell_Enabled", "Enable crit sounds for magic weapons", false);
            setting.AddBool("ProjectileCrits_TypeBullet_Enabled", "Enable crit sounds for bullet-based weapons", false);
            setting.AddBool("ProjectileCrits_TypeMelee_Enabled", "Enable crit sounds for projectile-based ranged weaponry", false);
            setting.AddBool("ProjectileCrits_TypeSummon_Enabled", "Enable crit sounds for summoned entities", false);
            setting.AddBool("ProjectileCrits_TypeMisc_Enabled", "Enable crit sounds for miscellaneous projectiles", false);
            setting.AddBool("ProjectileCrits_TypeUnknown_Enabled", "Enable crit sounds for undefined projectiles", false);

            //Vanilla volume
            setting.AddComment("Pack-in sounds - volume section");
            setting.AddFloat("TypeArrow_Volume", "Changes the volume of arrow crits", 0f, 1f, false);
            setting.AddFloat("TypeThrowing_Volume", "Change the volume of throw-able crits", 0f, 1f, false);
            setting.AddFloat("TypeSpell_Volume", "Change the volume of magic crits", 0f, 1f, false);
            setting.AddFloat("TypeBullet_Volume", "Change the volume of bullet crits", 0f, 1f, false);
            setting.AddFloat("TypeMelee_Volume", "Change the volume of melee projectile crits", 0f, 1f, false);
            setting.AddFloat("TypeSummon_Volume", "Change the volume of summon crits", 0f, 1f, false);
            setting.AddFloat("TypeMisc_Volume", "Change the volume of miscellaneous crits", 0f, 1f, false);
            setting.AddFloat("Egg01_Volume", "Change the volume of Egg 01", 0f, 1f, false);

            //Mod volume
            setting.AddComment("Custom sounds - volume section");
            setting.AddFloat("Mod_MeleeStab_Volume", "Change the volume of custom melee stab crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeArrow_Volume", "Change the volume of custom arrow crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeThrowing_Volume", "Change the volume of custom throw-able crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeSpell_Volume", "Change the volume of custom magic crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeBullet_Volume", "Change the volume of custom bullet crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeMelee_Volume", "Change the volume of custom melee projectile crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeSummon_Volume", "Change the volume of custom summon crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeMisc_Volume", "Change the volume of custom miscellaneous crits", 0f, 1f, false);
            setting.AddFloat("Mod_TypeUnknown_Volume", "Change the volume of custom unknown projectile crits", 0f, 1f, false);
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

            if (FKTModSettings.ModSettingsAPI.TryGetModSetting(this, out setting))
            {
                setting.Get("MeleeStabCrits_Enabled", ref Config.MeleeStabCrits_Enabled);
                setting.Get("MeleeStab_Volume", ref Config.MeleeStab_Volume);
                setting.Get("ProjectileCrits_Enabled", ref Config.ProjectileCrits_Enabled);
                setting.Get("ProjectileCrits_TypeArrow_Enabled", ref Config.ProjectileCrits_TypeArrow_Enabled);
                setting.Get("TypeArrow_Volume", ref Config.TypeArrow_Volume);
                setting.Get("ProjectileCrits_TypeThrowing_Enabled", ref Config.ProjectileCrits_TypeThrowing_Enabled);
                setting.Get("TypeThrowing_Volume", ref Config.TypeThrowing_Volume);
                setting.Get("ProjectileCrits_TypeSpell_Enabled", ref Config.ProjectileCrits_TypeSpell_Enabled);
                setting.Get("TypeSpell_Volume", ref Config.TypeSpell_Volume);
                setting.Get("ProjectileCrits_TypeBullet_Enabled", ref Config.ProjectileCrits_TypeBullet_Enabled);
                setting.Get("TypeBullet_Volume", ref Config.TypeBullet_Volume);
                setting.Get("ProjectileCrits_TypeMelee_Enabled", ref Config.ProjectileCrits_TypeMelee_Enabled);
                setting.Get("TypeMelee_Volume", ref Config.TypeMelee_Volume);
                setting.Get("ProjectileCrits_TypeSummon_Enabled", ref Config.ProjectileCrits_TypeSummon_Enabled);
                setting.Get("TypeSummon_Volume", ref Config.TypeSummon_Volume);
                setting.Get("ProjectileCrits_TypeMisc_Enabled", ref Config.ProjectileCrits_TypeMisc_Enabled);
                setting.Get("TypeMisc_Volume", ref Config.TypeMisc_Volume);
                setting.Get("ProjectileCrits_TypeUnknown_Enabled", ref Config.ProjectileCrits_TypeUnknown_Enabled);
                setting.Get("TypeUnknown_Volume", ref Config.TypeUnknown_Volume);

                setting.Get("Egg01_Volume", ref Config.Egg01_Volume);

                setting.Get("Mod_MeleeStab_Volume", ref Config.Mod_MeleeStab_Volume);
                setting.Get("Mod_TypeArrow_Volume", ref Config.Mod_TypeArrow_Volume);
                setting.Get("Mod_TypeThrowing_Volume", ref Config.Mod_TypeThrowing_Volume);
                setting.Get("Mod_TypeSpell_Volume", ref Config.Mod_TypeSpell_Volume);
                setting.Get("Mod_TypeBullet_Volume", ref Config.Mod_TypeBullet_Volume);
                setting.Get("Mod_TypeMelee_Volume", ref Config.Mod_TypeMelee_Volume);
                setting.Get("Mod_TypeSummon_Volume", ref Config.Mod_TypeSummon_Volume);
                setting.Get("Mod_TypeMisc_Volume", ref Config.Mod_TypeMisc_Volume);
                setting.Get("Mod_TypeUnknown_Volume", ref Config.Mod_TypeUnknown_Volume);
            }
        }

        public override void PreSaveAndQuit()
        {
            Bass.BASS_Free();
            AddonHandler.UnloadAddons();
        }
    }
}