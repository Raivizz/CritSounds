using ManagedBass;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritSounds
{
    public class StreamType
    {
        internal int MSC_Stream;
        internal int TAC_Stream;
        internal int TTC_Stream;
        internal int TSC_Stream;
        internal int TBP_Stream;
        internal int TMP_Stream;
        internal int TSuC_Stream;
        internal int TMiC_Stream;
        internal int TUC_Stream;
    }

    public class CritSFXHandler : ModPlayer
    {
        //The section where all the basic scripting magic happens.
        //Future updates may include either more sounds or more advanced scripting shenanigans.
        //Anyone is free to use this code for their own needs.

        //Defines lists which are later used to contain file paths of all custom sounds
        internal List<string> MSCFiles;
        internal List<string> TACFiles;
        internal List<string> TTCFiles;
        internal List<string> TSCFiles;
        internal List<string> TBPFiles;
        internal List<string> TMPFiles;
        internal List<string> TSuCFiles;
        internal List<string> TMiCFiles;
        internal List<string> TUCFiles;

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

        public override void OnEnterWorld(Player player)
        {
            CheckDirectoriesForMods();
        }

        private int ProjectileType = 0;

        //The amount of default sound effects for unmodded crit types for magical number minimising
        private readonly int MSC_SFXCount = 4;
        private readonly int Egg1_SFXCount = 18;
        private readonly int TAC_SFXCount = 4;
        private readonly int TTC_SFXCount = 4;
        private readonly int TSC_SFXCount = 4;
        private readonly int TBP_SFXCount = 5;
        private readonly int TMP_SFXCount = 4;
        private readonly int TSuC_SFXCount = 4;
        private readonly int TMiC_SFXCount = 6;
        private readonly int TUC_SFXCount = 5;

        //Melee crits
        //Plays when a player deals a crit to a hostile NPC with a melee weapon.
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            StreamType st = new StreamType();

            if (crit == true && Config.MeleeStabCrits_Enabled == true && item.type != ItemID.TheAxe)
            {
                //No mod files detected
                if (MSCFiles.Count == 0)
                {

                    if (new Random().Next(MSC_SFXCount) == 1)
                    {
                        _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit01"), volumeScale: Config.MeleeStab_Volume);
                    }
                    if (new Random().Next(MSC_SFXCount) == 2)
                    {
                        _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit02"), volumeScale: Config.MeleeStab_Volume);
                    }
                    if (new Random().Next(MSC_SFXCount) == 3)
                    {
                        _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit03"), volumeScale: Config.MeleeStab_Volume);
                    }
                    if (new Random().Next(MSC_SFXCount) == 4)
                    {
                        _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit04"), volumeScale: Config.MeleeStab_Volume);
                    }
                }

                //At least one mod file exists.
                if (MSCFiles != null || MSCFiles.Count != 0)
                {
                    st.MSC_Stream = Bass.CreateStream(MSCFiles[new Random().Next(MSCFiles.Count)]);
                    _ = Bass.ChannelPlay(st.MSC_Stream, false);
                }
                return;
            }

            //Egg 01
            if (crit == true && Config.MeleeStabCrits_Enabled == true && item.type == ItemID.TheAxe)
            {
                if (new Random().Next(Egg1_SFXCount) == 1)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_01"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 2)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_02"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 3)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_03"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 4)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_04"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 5)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_05"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 6)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_06"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 7)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_07"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 8)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_08"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 9)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_09"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 10)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_10"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 11)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_11"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 12)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_12"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 13)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_13"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 14)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_14"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 15)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_15"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 16)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_16"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 17)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_17"), volumeScale: Config.Egg01_Volume);
                }
                if (new Random().Next(Egg1_SFXCount) == 18)
                {
                    _ = Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_18"), volumeScale: Config.Egg01_Volume);
                }
            }
        }

        //Projectile crits
        //Plays when a player deals a crit to a hostile NPC with a projectile.
        //Starting with version 1.1.0, projectiles are now categorized and have respective sounds assigned.
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {

            StreamType st = new StreamType();
            if (proj is null)
            {
                throw new ArgumentNullException(nameof(proj));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if ((crit == true) && (Config.ProjectileCrits_Enabled == true))
            {
                ProjCheck pc = new ProjCheck();
                ProjectileType = pc.ProjIDExists(proj.type);

                switch (ProjectileType)
                {
                    //Arrows
                    case ProjTypeContainer.TypeArrow:

                        if (Config.ProjectileCrits_TypeArrow_Enabled == true)
                        {
                            if (TACFiles.Count == 0)
                            {
                                if (new Random().Next(TTC_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01"), volumeScale: Config.TypeArrow_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02"), volumeScale: Config.TypeArrow_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03"), volumeScale: Config.TypeArrow_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04"), volumeScale: Config.TypeArrow_Volume);
                                }
                            }
                            if (TACFiles.Count != 0)
                            {
                                _ = new StreamType().TAC_Stream;
                                st.TAC_Stream = Bass.CreateStream(TACFiles[new Random().Next(TACFiles.Count)]);

                                //Sets channel's volume, defined by the user using config file or Mod Settings Configurator
                                Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Volume, Config.Mod_TypeArrow_Volume);
                                //Calculates and sets channel's pan
                                Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                //Plays the configured stream.
                                Bass.ChannelPlay(st.TAC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    //Throwing weapons
                    case ProjTypeContainer.TypeThrowing:

                        if (Config.ProjectileCrits_TypeThrowing_Enabled == true)
                        {
                            if (TTCFiles.Count == 0)
                            {
                                if (new Random().Next(TTC_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit01"), volumeScale: Config.TypeThrowing_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit02"), volumeScale: Config.TypeThrowing_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit03"), volumeScale: Config.TypeThrowing_Volume);
                                }
                                if (new Random().Next(TTC_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit04"), volumeScale: Config.TypeThrowing_Volume);
                                }
                            }
                            if (TTCFiles.Count != 0)
                            {
                                _ = new StreamType().TTC_Stream;
                                st.TTC_Stream = Bass.CreateStream(TTCFiles[new Random().Next(TTCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Volume, Config.Mod_TypeThrowing_Volume);
                                Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TTC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    //Spells
                    case ProjTypeContainer.TypeSpell:

                        if (Config.ProjectileCrits_TypeSpell_Enabled == true)
                        {
                            if (TSCFiles.Count == 0)
                            {
                                if (new Random().Next(TSC_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01"), volumeScale: Config.TypeSpell_Volume);
                                }
                                if (new Random().Next(TSC_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02"), volumeScale: Config.TypeSpell_Volume);
                                }
                                if (new Random().Next(TSC_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03"), volumeScale: Config.TypeSpell_Volume);
                                }
                                if (new Random().Next(TSC_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04"), volumeScale: Config.TypeSpell_Volume);
                                }
                                if (new Random().Next(TSC_SFXCount) == 5)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05"), volumeScale: Config.TypeSpell_Volume);
                                }
                                if (new Random().Next(TSC_SFXCount) == 6)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06"), volumeScale: Config.TypeSpell_Volume);
                                }
                            }
                            if (TSCFiles.Count != 0)
                            {
                                _ = new StreamType().TSC_Stream;
                                st.TSC_Stream = Bass.CreateStream(TSCFiles[new Random().Next(TSCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Volume, Config.Mod_TypeSpell_Volume);
                                Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TSC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    //Bullets
                    case ProjTypeContainer.TypeBullet:

                        if (Config.ProjectileCrits_TypeBullet_Enabled == true)
                        {
                            if (TBPFiles.Count == 0)
                            {
                                if (new Random().Next(TBP_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit01"), volumeScale: Config.TypeBullet_Volume);
                                }
                                if (new Random().Next(TBP_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit02"), volumeScale: Config.TypeBullet_Volume);
                                }
                                if (new Random().Next(TBP_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit03"), volumeScale: Config.TypeBullet_Volume);
                                }
                                if (new Random().Next(TBP_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit04"), volumeScale: Config.TypeBullet_Volume);
                                }
                                if (new Random().Next(TBP_SFXCount) == 5)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit05"), volumeScale: Config.TypeBullet_Volume);
                                }
                            }
                            if (TBPFiles.Count != 0)
                            {
                                _ = new StreamType().TBP_Stream;
                                st.TBP_Stream = Bass.CreateStream(TBPFiles[new Random().Next(TBPFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TBP_Stream, ChannelAttribute.Volume, Config.Mod_TypeBullet_Volume);
                                Bass.ChannelSetAttribute(st.TBP_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TBP_Stream);
                            }
                            else
                            {
                                return;
                            }
                        };
                        break;

                    //Melee
                    case ProjTypeContainer.TypeMelee:

                        if (Config.ProjectileCrits_TypeMelee_Enabled == true)
                        {
                            if (TMPFiles.Count == 0)
                            {
                                if (new Random().Next(TMP_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01"), volumeScale: Config.TypeMelee_Volume);
                                }
                                if (new Random().Next(TMP_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02"), volumeScale: Config.TypeMelee_Volume);
                                }
                                if (new Random().Next(TMP_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03"), volumeScale: Config.TypeMelee_Volume);
                                }
                                if (new Random().Next(TMP_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04"), volumeScale: Config.TypeMelee_Volume);
                                }
                            }
                            if (TMPFiles.Count != 0)
                            {
                                _ = new StreamType().TMP_Stream;
                                st.TMP_Stream = Bass.CreateStream(TMPFiles[new Random().Next(TMPFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Volume, Config.Mod_TypeMelee_Volume);
                                Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TMP_Stream);
                            }
                            else
                            {
                                return;
                            }
                        };
                        break;

                    //Summon
                    case ProjTypeContainer.TypeSummon:

                        if (Config.ProjectileCrits_TypeSummon_Enabled == true)
                        {
                            if (TSuCFiles.Count == 0)
                            {
                                if (new Random().Next(TSuC_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit01"), volumeScale: Config.TypeSummon_Volume);
                                }
                                if (new Random().Next(TSuC_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit02"), volumeScale: Config.TypeSummon_Volume);
                                }
                                if (new Random().Next(TSuC_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit03"), volumeScale: Config.TypeSummon_Volume);
                                }
                                if (new Random().Next(TSuC_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit04"), volumeScale: Config.TypeSummon_Volume);
                                }
                            }
                            if (TSuCFiles.Count != 0)
                            {
                                _ = new StreamType().TSuC_Stream;
                                st.TSuC_Stream = Bass.CreateStream(TSuCFiles[new Random().Next(TSuCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TSuC_Stream, ChannelAttribute.Volume, Config.Mod_TypeSummon_Volume);
                                Bass.ChannelSetAttribute(st.TSuC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TSuC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    //Miscellaneous
                    case ProjTypeContainer.TypeMisc:

                        if (Config.ProjectileCrits_TypeMisc_Enabled == true)
                        {
                            if (TMiCFiles.Count == 0)
                            {
                                if (new Random().Next(TMiC_SFXCount) == 1)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit01"), volumeScale: Config.TypeMisc_Volume);
                                }
                                if (new Random().Next(TMiC_SFXCount) == 2)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit02"), volumeScale: Config.TypeMisc_Volume);
                                }
                                if (new Random().Next(TMiC_SFXCount) == 3)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit03"), volumeScale: Config.TypeMisc_Volume);
                                }
                                if (new Random().Next(TMiC_SFXCount) == 4)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit04"), volumeScale: Config.TypeMisc_Volume);
                                }
                                if (new Random().Next(TMiC_SFXCount) == 5)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit05"), volumeScale: Config.TypeMisc_Volume);
                                }
                                if (new Random().Next(TMiC_SFXCount) == 6)
                                {
                                    Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit06"), volumeScale: Config.TypeMisc_Volume);
                                }
                            }
                            if (TMiCFiles.Count != 0)
                            {
                                _ = new StreamType().TMiC_Stream;
                                st.TMiC_Stream = Bass.CreateStream(TMiCFiles[new Random().Next(TMiCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TMiC_Stream, ChannelAttribute.Volume, Config.Mod_TypeMisc_Volume);
                                Bass.ChannelSetAttribute(st.TMiC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TMiC_Stream);
                            }
                            else
                            {
                                return;
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
                                    if (new Random().Next(TAC_SFXCount) == 1)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01"), volumeScale: Config.TypeArrow_Volume);
                                    }
                                    if (new Random().Next(TAC_SFXCount) == 2)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02"), volumeScale: Config.TypeArrow_Volume);
                                    }
                                    if (new Random().Next(TAC_SFXCount) == 3)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03"), volumeScale: Config.TypeArrow_Volume);
                                    }
                                    if (new Random().Next(TAC_SFXCount) == 4)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04"), volumeScale: Config.TypeArrow_Volume);
                                    }
                                }
                                if (TACFiles.Count != 0)
                                {
                                    _ = new StreamType().TAC_Stream;
                                    st.TAC_Stream = Bass.CreateStream(TACFiles[new Random().Next(TACFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Volume, Config.Mod_TypeArrow_Volume);
                                    Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TAC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }

                            if (proj.thrown)
                            {
                                if (TTCFiles.Count == 0)
                                {
                                    if (new Random().Next(TTC_SFXCount) == 1)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit01"), volumeScale: Config.TypeThrowing_Volume);
                                    }
                                    if (new Random().Next(TTC_SFXCount) == 2)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit02"), volumeScale: Config.TypeThrowing_Volume);
                                    }
                                    if (new Random().Next(TTC_SFXCount) == 3)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit03"), volumeScale: Config.TypeThrowing_Volume);
                                    }
                                    if (new Random().Next(TTC_SFXCount) == 4)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowing/Throwing_Crit04"), volumeScale: Config.TypeThrowing_Volume);
                                    }
                                }
                                if (TTCFiles.Count != 0)
                                {
                                    _ = new StreamType().TTC_Stream;
                                    st.TTC_Stream = Bass.CreateStream(TTCFiles[new Random().Next(TTCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Volume, Config.Mod_TypeThrowing_Volume);
                                    Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TTC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }

                            if (proj.magic)
                            {
                                if (TSCFiles.Count == 0)
                                {
                                    if (new Random().Next(TSC_SFXCount) == 1)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                    if (new Random().Next(TSC_SFXCount) == 2)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                    if (new Random().Next(TSC_SFXCount) == 3)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                    if (new Random().Next(TSC_SFXCount) == 4)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                    if (new Random().Next(TSC_SFXCount) == 5)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                    if (new Random().Next(TSC_SFXCount) == 6)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06"), volumeScale: Config.TypeSpell_Volume);
                                    }
                                }
                                if (TSCFiles.Count != 0)
                                {
                                    _ = new StreamType().TSC_Stream;
                                    st.TSC_Stream = Bass.CreateStream(TSCFiles[new Random().Next(TSCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Volume, Config.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TSC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }

                            if (proj.melee)
                            {
                                if (TMPFiles.Count == 0)
                                {
                                    if (new Random().Next(TMP_SFXCount) == 1)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01"), volumeScale: Config.TypeMelee_Volume);
                                    }
                                    if (new Random().Next(TMP_SFXCount) == 2)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02"), volumeScale: Config.TypeMelee_Volume);
                                    }
                                    if (new Random().Next(TMP_SFXCount) == 3)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03"), volumeScale: Config.TypeMelee_Volume);
                                    }
                                    if (new Random().Next(TMP_SFXCount) == 4)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04"), volumeScale: Config.TypeMelee_Volume);
                                    }
                                }
                                if (TMPFiles.Count != 0)
                                {
                                    _ = new StreamType().TMP_Stream;
                                    st.TMP_Stream = Bass.CreateStream(TMPFiles[new Random().Next(TMPFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Volume, Config.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TMP_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }



                            if ((!proj.ranged) && (!proj.melee) && (!proj.thrown) && (!proj.magic))
                            {
                                if (TUCFiles.Count == 0)
                                {
                                    if (new Random().Next(TUC_SFXCount) == 1)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit01"), volumeScale: Config.TypeUnknown_Volume);
                                    }
                                    if (new Random().Next(TUC_SFXCount) == 2)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit02"), volumeScale: Config.TypeUnknown_Volume);
                                    }
                                    if (new Random().Next(TUC_SFXCount) == 3)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit03"), volumeScale: Config.TypeUnknown_Volume);
                                    }
                                    if (new Random().Next(TUC_SFXCount) == 4)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit04"), volumeScale: Config.TypeUnknown_Volume);
                                    }
                                    if (new Random().Next(TUC_SFXCount) == 5)
                                    {
                                        Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit05"), volumeScale: Config.TypeUnknown_Volume);
                                    }
                                }
                                if (TUCFiles.Count != 0)
                                {
                                    _ = new StreamType().TUC_Stream;
                                    st.TUC_Stream = Bass.CreateStream(TUCFiles[new Random().Next(TUCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TUC_Stream, ChannelAttribute.Volume, Config.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TUC_Stream, ChannelAttribute.Pan, ((int)target.position.X - (int)player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TUC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        break;
                    default:
                        mod.Logger.Warn("Default case for projectiles triggered. That's not good.");
                        break;
                }
            }
        }
    }
}