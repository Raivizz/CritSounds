using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.Audio;
using Un4seen.Bass;

namespace CritSounds
{
    public class StreamType
    {
        public int MSC_Stream;
        public int TAC_Stream;
        public int TTC_Stream;
        public int TSC_Stream;
        public int TBP_Stream;
        public int TMP_Stream;
        public int TSuC_Stream;
        public int TMiC_Stream;
        public int TUC_Stream;
    }

    public class CritSFXHandler : ModPlayer
    {
        //The section where all the basic scripting magic happens.
        //Future updates may include either more sounds or more advanced scripting shenanigans.
        //Anyone is free to use this code for their own needs.

        //Defines lists which are later used to contain file paths of all custom sounds
        public List<string> MSCFiles;

        public List<string> TACFiles;

        public List<string> TTCFiles;

        public List<string> TSCFiles;

        public List<string> TBPFiles;

        public List<string> TMPFiles;

        public List<string> TSuCFiles;

        public List<string> TMiCFiles;

        public List<string> TUCFiles;

        public void CheckDirectoriesForMods()
        {
            CritModdingFramework cmf_check = new CritModdingFramework();

            //Fills the previously-defined lists with path files to all custom sounds
            MSCFiles = new List<string>(Directory.GetFiles(cmf_check.MSC_P));
            TACFiles = new List<string>(Directory.GetFiles(cmf_check.TAC_P));
            TTCFiles = new List<string>(Directory.GetFiles(cmf_check.TTC_P));
            TSCFiles = new List<string>(Directory.GetFiles(cmf_check.TSC_P));
            TBPFiles = new List<string>(Directory.GetFiles(cmf_check.TBP_P));
            TMPFiles = new List<string>(Directory.GetFiles(cmf_check.TMP_P));
            TSuCFiles = new List<string>(Directory.GetFiles(cmf_check.TSuC_P));
            TMiCFiles = new List<string>(Directory.GetFiles(cmf_check.TMiC_P));
            TUCFiles = new List<string>(Directory.GetFiles(cmf_check.TUC_P));
        }

        override public void OnEnterWorld(Player player)
        {
            CheckDirectoriesForMods();

            //Old debugging stuff from experimental version 1.2.0 of Crit Sounds
            //Left here in case it'll be useful again.

            //         if (File.Exists("bassopus.dll") && Config.BASSAddon_EnableOpusAddon)
            //         {
            //             int opusLoad = Bass.BASS_PluginLoad("bassopus.dll");
            //
            //             Main.NewText("opusLoad integer currently holds the value " + opusLoad);
            //             Main.NewText(Bass.BASS_ErrorGetCode());
            //             string TestFile = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Testing" + Path.DirectorySeparatorChar.ToString() + "GameComplete.opus");
            //             int TestFileStream = Bass.BASS_StreamCreateFile(TestFile, 0, 0, BASSFlag.BASS_DEFAULT);
            //             Bass.BASS_ChannelPlay(TestFileStream, false);
            //         }
        }

        int ProjectileType = 0;

        //Melee crits
        //Plays when a player deals a crit to a hostile NPC with a melee weapon.
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            StreamType st = new StreamType();

            if ((crit == true) && (Config.MeleeStabCrits_Enabled == true) && (item.type != 1305))
            {
                //No mod files detected
                if (MSCFiles.Count == 0)
                {
                    int MSRand_NoMod = new Random().Next(1, 4);
                    if (MSRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit01"), Config.MeleeStab_Volume); }
                    if (MSRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit02"), Config.MeleeStab_Volume); }
                    if (MSRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit03"), Config.MeleeStab_Volume); }
                    if (MSRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit04"), Config.MeleeStab_Volume); }
                }

                //At least one mod file exists.
                if (MSCFiles.Count != 0)
                {
                    int MSRand_Mod = new Random().Next(0, MSCFiles.Count);
                    string MSRand_Result = MSCFiles[MSRand_Mod];

                    st.MSC_Stream = Bass.BASS_StreamCreateFile(MSRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                    Bass.BASS_ChannelSetAttribute(st.MSC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_MeleeStab_Volume);

                    Bass.BASS_ChannelPlay(st.MSC_Stream, false);
                }
            }

            //Egg 01
            if ((crit == true) && (Config.MeleeStabCrits_Enabled == true) && (item.type == 1305))
            {
                int Egg1Rand = new Random().Next(1, 18);
                if (Egg1Rand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_01"), Config.Egg01_Volume); }
                if (Egg1Rand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_02"), Config.Egg01_Volume); }
                if (Egg1Rand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_03"), Config.Egg01_Volume); }
                if (Egg1Rand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_04"), Config.Egg01_Volume); }
                if (Egg1Rand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_05"), Config.Egg01_Volume); }
                if (Egg1Rand == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_06"), Config.Egg01_Volume); }
                if (Egg1Rand == 7) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_07"), Config.Egg01_Volume); }
                if (Egg1Rand == 8) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_08"), Config.Egg01_Volume); }
                if (Egg1Rand == 9) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_09"), Config.Egg01_Volume); }
                if (Egg1Rand == 10) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_10"), Config.Egg01_Volume); }
                if (Egg1Rand == 11) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_11"), Config.Egg01_Volume); }
                if (Egg1Rand == 12) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_12"), Config.Egg01_Volume); }
                if (Egg1Rand == 13) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_13"), Config.Egg01_Volume); }
                if (Egg1Rand == 14) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_14"), Config.Egg01_Volume); }
                if (Egg1Rand == 15) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_15"), Config.Egg01_Volume); }
                if (Egg1Rand == 16) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_16"), Config.Egg01_Volume); }
                if (Egg1Rand == 17) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_17"), Config.Egg01_Volume); }
                if (Egg1Rand == 18) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_18"), Config.Egg01_Volume); }
            }
        }

        //Projectile crits
        //Plays when a player deals a crit to a hostile NPC with a projectile.
        //Starting with version 1.1.0, projectiles are now categorized and have respective sounds assigned.
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            StreamType st = new StreamType();

            if ((crit == true) && (Config.ProjectileCrits_Enabled == true))
            {
                ProjCheck pc = new ProjCheck();

                ProjectileType = (pc.ProjIDExists(proj.type));
                switch (ProjectileType)
                {
                    //Arrows
                    case ProjTypeContainer.TypeArrow:

                        if (Config.ProjectileCrits_TypeArrow_Enabled == true)
                        {
                            if (TACFiles.Count == 0)
                            {
                                int ARRand_NoMod = new Random().Next(1, 4);
                                if (ARRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01"), Config.TypeArrow_Volume); Main.NewText((int)target.position.X); Main.NewText("  " + (int)target.position.Y); }
                                if (ARRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02"), Config.TypeArrow_Volume); Main.NewText((int)target.position.X); Main.NewText("  " + (int)target.position.Y); }
                                if (ARRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03"), Config.TypeArrow_Volume); Main.NewText((int)target.position.X); Main.NewText("  " + (int)target.position.Y); }
                                if (ARRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04"), Config.TypeArrow_Volume); Main.NewText((int)target.position.X); Main.NewText("  " + (int)target.position.Y); }
                            }
                            if (TACFiles.Count != 0)
                            {
                                //Randomly selects one of the sounds in the corresponding directory
                                int ARRand_Mod = new Random().Next(0, TACFiles.Count);
                                string ARRand_Result = TACFiles[ARRand_Mod];

                                //Creates a BASS stream with the randomized string selected from the list.
                                st.TAC_Stream = Bass.BASS_StreamCreateFile(ARRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                //Sets channel's volume, defined by the user using config file or Mod Settings Configurator
                                Bass.BASS_ChannelSetAttribute(st.TAC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeArrow_Volume);

                                //Calculates pan
                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TAC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                //Plays the configured stream.
                                Bass.BASS_ChannelPlay(st.TAC_Stream, false);
                            }
                        }
                        break;

                    //Throwing weapons
                    case ProjTypeContainer.TypeThrowing:

                        if (Config.ProjectileCrits_TypeThrowing_Enabled == true)
                        {
                            if (TTCFiles.Count == 0)
                            {
                                int THRand_NoMod = new Random().Next(1, 4);
                                if (THRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit01"), Config.TypeThrowing_Volume); }
                                if (THRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit02"), Config.TypeThrowing_Volume); }
                                if (THRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit03"), Config.TypeThrowing_Volume); }
                                if (THRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit04"), Config.TypeThrowing_Volume); }
                            }
                            if (TTCFiles.Count != 0)
                            {
                                int THRand_Mod = new Random().Next(0, TTCFiles.Count);
                                string THRand_Result = TACFiles[THRand_Mod];
                                st.TTC_Stream = Bass.BASS_StreamCreateFile(THRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TTC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeThrowing_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TTC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TTC_Stream, false);
                            }
                        }
                        break;

                    //Spells
                    case ProjTypeContainer.TypeSpell:

                        if (Config.ProjectileCrits_TypeSpell_Enabled == true)
                        {
                            if (TSCFiles.Count == 0)
                            {
                                int SPRand_NoMod = new Random().Next(1, 6);
                                if (SPRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01"), Config.TypeSpell_Volume); }
                                if (SPRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02"), Config.TypeSpell_Volume); }
                                if (SPRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03"), Config.TypeSpell_Volume); }
                                if (SPRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04"), Config.TypeSpell_Volume); }
                                if (SPRand_NoMod == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05"), Config.TypeSpell_Volume); }
                                if (SPRand_NoMod == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06"), Config.TypeSpell_Volume); }
                            }
                            if (TSCFiles.Count != 0)
                            {
                                int SPRand_Mod = new Random().Next(0, TSCFiles.Count);
                                string SPRand_Result = TSCFiles[SPRand_Mod];
                                st.TSC_Stream = Bass.BASS_StreamCreateFile(SPRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TSC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeSpell_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TSC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TSC_Stream, false);
                            }
                        }
                        break;

                    //Bullets
                    case ProjTypeContainer.TypeBullet:

                        if (Config.ProjectileCrits_TypeBullet_Enabled == true)
                        {
                            if (TBPFiles.Count == 0)
                            {
                                int BURand_NoMod = new Random().Next(1, 5);
                                if (BURand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit01"), Config.TypeBullet_Volume); }
                                if (BURand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit02"), Config.TypeBullet_Volume); }
                                if (BURand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit03"), Config.TypeBullet_Volume); }
                                if (BURand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit04"), Config.TypeBullet_Volume); }
                                if (BURand_NoMod == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit05"), Config.TypeBullet_Volume); }
                            }
                            if (TBPFiles.Count != 0)
                            {
                                int BURand_Mod = new Random().Next(0, TBPFiles.Count);
                                string BURand_Result = TBPFiles[BURand_Mod];
                                st.TBP_Stream = Bass.BASS_StreamCreateFile(BURand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TBP_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeBullet_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TBP_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TBP_Stream, false);
                            }
                        }
                        break;

                    //Melee
                    case ProjTypeContainer.TypeMelee:

                        if (Config.ProjectileCrits_TypeMelee_Enabled == true)
                        {
                            if (TMPFiles.Count == 0)
                            {
                                int MERand_NoMod = new Random().Next(1, 4);
                                if (MERand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01"), Config.TypeMelee_Volume); }
                                if (MERand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02"), Config.TypeMelee_Volume); }
                                if (MERand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03"), Config.TypeMelee_Volume); }
                                if (MERand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04"), Config.TypeMelee_Volume); }
                            }
                            if (TMPFiles.Count != 0)
                            {
                                int MERand_Mod = new Random().Next(0, TMPFiles.Count);
                                string MERand_Result = TMPFiles[MERand_Mod];
                                st.TMP_Stream = Bass.BASS_StreamCreateFile(MERand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TMP_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeMelee_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TMP_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TMP_Stream, false);
                            }
                        }
                        break;

                    //Summon
                    case ProjTypeContainer.TypeSummon:

                        if (Config.ProjectileCrits_TypeSummon_Enabled == true)
                        {
                            if (TSuCFiles.Count == 0)
                            {
                                int SURand_NoMod = new Random().Next(1, 4);
                                if (SURand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit01"), Config.TypeSummon_Volume); }
                                if (SURand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit02"), Config.TypeSummon_Volume); }
                                if (SURand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit03"), Config.TypeSummon_Volume); }
                                if (SURand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit04"), Config.TypeSummon_Volume); }
                            }
                            if (TSuCFiles.Count != 0)
                            {
                                int SURand_Mod = new Random().Next(0, TSuCFiles.Count);
                                string SURand_Result = TSuCFiles[SURand_Mod];
                                st.TSuC_Stream = Bass.BASS_StreamCreateFile(SURand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TSuC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeSummon_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TSuC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TSuC_Stream, false);
                            }
                        }
                        break;

                    //Miscellaneous
                    case ProjTypeContainer.TypeMisc:

                        if (Config.ProjectileCrits_TypeMisc_Enabled == true)
                        {
                            if (TMiCFiles.Count == 0)
                            {
                                int MIRand_NoMod = new Random().Next(1, 6);
                                if (MIRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit01"), Config.TypeMisc_Volume); }
                                if (MIRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit02"), Config.TypeMisc_Volume); }
                                if (MIRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit03"), Config.TypeMisc_Volume); }
                                if (MIRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit04"), Config.TypeMisc_Volume); }
                                if (MIRand_NoMod == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit05"), Config.TypeMisc_Volume); }
                                if (MIRand_NoMod == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit06"), Config.TypeMisc_Volume); }
                            }
                            if (TMiCFiles.Count != 0)
                            {
                                int MIRand_Mod = new Random().Next(0, TMiCFiles.Count);
                                string MIRand_Result = TMiCFiles[MIRand_Mod];
                                st.TMiC_Stream = Bass.BASS_StreamCreateFile(MIRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                Bass.BASS_ChannelSetAttribute(st.TMiC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeMisc_Volume);

                                int Difference = ((int)target.position.X - (int)player.position.X);
                                float PanSet = (Difference / (Main.screenWidth / 2));
                                Bass.BASS_ChannelSetAttribute(st.TMiC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                Bass.BASS_ChannelPlay(st.TMiC_Stream, false);
                            }
                        }
                        break;

                    //Unknown handler
                    //Judges what sound to play by specific item bools instead of projectile ID.
                    //Mainly meant for mods or me being a silly goose and forgetting to add IDs to arrays.
                    //Sadly, this means that limitations apply, such as all ranged weaponry, no matter what ammo they use, using a standard arrow crit sound.
                    case ProjTypeContainer.TypeUnknown:

                        if (Config.ProjectileCrits_TypeUnknown_Enabled == true)
                        {
                            if (proj.ranged)
                            {
                                if (TACFiles.Count == 0)
                                {
                                    int ARRand_NoMod = new Random().Next(1, 4);
                                    if (ARRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01"), Config.TypeArrow_Volume); }
                                    if (ARRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02"), Config.TypeArrow_Volume); }
                                    if (ARRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03"), Config.TypeArrow_Volume); }
                                    if (ARRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04"), Config.TypeArrow_Volume); }
                                }
                                if (TACFiles.Count != 0)
                                {
                                    int ARRand_Mod = new Random().Next(0, TACFiles.Count);
                                    string ARRand_Result = TACFiles[ARRand_Mod];
                                    st.TAC_Stream = Bass.BASS_StreamCreateFile(ARRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                    Bass.BASS_ChannelSetAttribute(st.TAC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeArrow_Volume);

                                    int Difference = ((int)target.position.X - (int)player.position.X);
                                    float PanSet = (Difference / (Main.screenWidth / 2));
                                    Bass.BASS_ChannelSetAttribute(st.TAC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                    Bass.BASS_ChannelPlay(st.TAC_Stream, false);
                                }
                            }

                            if (proj.thrown)
                            {
                                if (TTCFiles.Count == 0)
                                {
                                    int THRand_NoMod = new Random().Next(1, 4);
                                    if (THRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit01"), Config.TypeThrowing_Volume); }
                                    if (THRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit02"), Config.TypeThrowing_Volume); }
                                    if (THRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit03"), Config.TypeThrowing_Volume); }
                                    if (THRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit04"), Config.TypeThrowing_Volume); }
                                }
                                if (TTCFiles.Count != 0)
                                {
                                    int THRand_Mod = new Random().Next(0, TTCFiles.Count);
                                    string THRand_Result = TTCFiles[THRand_Mod];
                                    st.TTC_Stream = Bass.BASS_StreamCreateFile(THRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                    Bass.BASS_ChannelSetAttribute(st.TTC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeThrowing_Volume);

                                    int Difference = ((int)target.position.X - (int)player.position.X);
                                    float PanSet = (Difference / (Main.screenWidth / 2));
                                    Bass.BASS_ChannelSetAttribute(st.TTC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                    Bass.BASS_ChannelPlay(st.TTC_Stream, false);
                                }
                            }

                            if (proj.magic)
                            {
                                if (TSCFiles.Count == 0)
                                {
                                    int SPRand_NoMod = new Random().Next(1, 6);
                                    if (SPRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01"), Config.TypeSpell_Volume); }
                                    if (SPRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02"), Config.TypeSpell_Volume); }
                                    if (SPRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03"), Config.TypeSpell_Volume); }
                                    if (SPRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04"), Config.TypeSpell_Volume); }
                                    if (SPRand_NoMod == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05"), Config.TypeSpell_Volume); }
                                    if (SPRand_NoMod == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06"), Config.TypeSpell_Volume); }
                                }
                                if (TSCFiles != null || TSCFiles.Count != 0)
                                {
                                    int SPRand_Mod = new Random().Next(0, TSCFiles.Count);
                                    string SPRand_Result = TSCFiles[SPRand_Mod];
                                    st.TSC_Stream = Bass.BASS_StreamCreateFile(SPRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                    Bass.BASS_ChannelSetAttribute(st.TSC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeSpell_Volume);

                                    int Difference = ((int)target.position.X - (int)player.position.X);
                                    float PanSet = (Difference / (Main.screenWidth / 2));
                                    Bass.BASS_ChannelSetAttribute(st.TSC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                    Bass.BASS_ChannelPlay(st.TSC_Stream, false);
                                }
                            }

                            if (proj.melee)
                            {
                                if (TMPFiles.Count == 0)
                                {
                                    int MERand_NoMod = new Random().Next(1, 4);
                                    if (MERand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01"), Config.TypeMelee_Volume); }
                                    if (MERand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02"), Config.TypeMelee_Volume); }
                                    if (MERand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03"), Config.TypeMelee_Volume); }
                                    if (MERand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04"), Config.TypeMelee_Volume); }
                                }
                                if (TMPFiles != null || TMPFiles.Count != 0)
                                {
                                    int MERand_Mod = new Random().Next(0, TMPFiles.Count);
                                    string MERand_Result = TMPFiles[MERand_Mod];
                                    st.TMP_Stream = Bass.BASS_StreamCreateFile(MERand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                    Bass.BASS_ChannelSetAttribute(st.TMP_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeMelee_Volume);

                                    int Difference = ((int)target.position.X - (int)player.position.X);
                                    float PanSet = (Difference / (Main.screenWidth / 2));
                                    Bass.BASS_ChannelSetAttribute(st.TMP_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                    Bass.BASS_ChannelPlay(st.TMP_Stream, false);
                                }
                            }

                            if ((!proj.ranged) && (!proj.melee) && (!proj.thrown) && (!proj.magic))
                            {
                                if (TUCFiles.Count == 0)
                                {
                                    int UNRand_NoMod = new Random().Next(1, 5);
                                    if (UNRand_NoMod == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit01"), Config.TypeUnknown_Volume); }
                                    if (UNRand_NoMod == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit02"), Config.TypeUnknown_Volume); }
                                    if (UNRand_NoMod == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit03"), Config.TypeUnknown_Volume); }
                                    if (UNRand_NoMod == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit04"), Config.TypeUnknown_Volume); }
                                    if (UNRand_NoMod == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit05"), Config.TypeUnknown_Volume); }
                                }
                                if (TUCFiles.Count != 0)
                                {
                                    int UNRand_Mod = new Random().Next(0, TUCFiles.Count);
                                    string UNRand_Result = TUCFiles[UNRand_Mod];
                                    st.TUC_Stream = Bass.BASS_StreamCreateFile(UNRand_Result, 0, 0, BASSFlag.BASS_DEFAULT);

                                    Bass.BASS_ChannelSetAttribute(st.TUC_Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Mod_TypeUnknown_Volume);

                                    int Difference = ((int)target.position.X - (int)player.position.X);
                                    float PanSet = (Difference / (Main.screenWidth / 2));
                                    Bass.BASS_ChannelSetAttribute(st.TUC_Stream, BASSAttribute.BASS_ATTRIB_PAN, PanSet);

                                    Bass.BASS_ChannelPlay(st.TUC_Stream, false);
                                }
                            }
                        }
                        break;
                }
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            //Frees BASS resources whenever the player character dies
            Bass.BASS_Free();
            return true;
        }
    }
}