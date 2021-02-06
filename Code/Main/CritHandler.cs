using ManagedBass;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
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

            CritSoundsConfig csc = new CritSoundsConfig();
            StreamType st = new StreamType();

            if (crit == true && csc.MeleeStabCrits_Enabled == true && item.type != ItemID.TheAxe)
            {
                //No mod files detected
                if (MSCFiles.Count == 0)
                {
                    SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                }
                //At least one mod file exists.
                if (MSCFiles.Count != 0)
                {
                    _ = new StreamType().MSC_Stream;
                    st.MSC_Stream = Bass.CreateStream(MSCFiles[new Random().Next(MSCFiles.Count)]);
                    Bass.ChannelSetAttribute(st.MSC_Stream, ChannelAttribute.Volume, csc.Mod_MeleeStab_Volume);
                    Bass.ChannelPlay(st.MSC_Stream);
                }
                return;
            }
        }

        //           //Egg 01
        //           if (crit == true && csc.MeleeStabCrits_Enabled == true && item.type == ItemID.TheAxe)
        //           {
        //               if (new Random().Next(Egg1_SFXCount) == 1)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_01"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 2)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_02"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 3)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_03"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 4)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_04"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 5)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_05"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 6)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_06"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 7)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_07"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 8)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_08"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 9)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_09"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 10)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_10"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 11)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_11"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 12)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_12"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 13)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_13"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 14)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_14"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 15)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_15"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 16)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_16"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 17)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_17"), volumeScale: csc.Egg01_Volume);
        //               }
        //               if (new Random().Next(Egg1_SFXCount) == 18)
        //               {
        //                   Main.PlaySound(50, x: (int)target.position.X, y: (int)target.position.Y, Style: mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_18"), volumeScale: csc.Egg01_Volume);
        //               }
        //           }
        //       }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {

            StreamType st = new StreamType();
            CritSoundsConfig csc = new CritSoundsConfig();
            if (proj is null)
            {
                throw new ArgumentNullException(nameof(proj));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if ((crit == true) && (csc.ProjectileCrits_Enabled == true))
            {
                ProjCheck pc = new ProjCheck();
                ProjectileType = pc.ProjIDExists(proj.type);

                switch (ProjectileType)
                {
                    case ProjTypeContainer.TypeArrow:

                        if (csc.ProjectileCrits_TypeArrow_Enabled == true)
                        {
                            if (TACFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TACFiles.Count != 0)
                            {
                                _ = new StreamType().TAC_Stream;
                                st.TAC_Stream = Bass.CreateStream(TACFiles[new Random().Next(TACFiles.Count)]);

                                //Sets channel's volume, defined by the user
                                Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Volume, csc.Mod_TypeArrow_Volume);
                                //Calculates and sets channel's pan
                                Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                //Plays the configured stream.
                                Bass.ChannelPlay(st.TAC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case ProjTypeContainer.TypeThrowing:

                        if (csc.ProjectileCrits_TypeThrowing_Enabled == true)
                        {
                            if (TTCFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TTCFiles.Count != 0)
                            {
                                _ = new StreamType().TTC_Stream;
                                st.TTC_Stream = Bass.CreateStream(TTCFiles[new Random().Next(TTCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Volume, csc.Mod_TypeThrowing_Volume);
                                Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TTC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case ProjTypeContainer.TypeSpell:

                        if (csc.ProjectileCrits_TypeSpell_Enabled == true)
                        {
                            if (TSCFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TSCFiles.Count != 0)
                            {
                                _ = new StreamType().TSC_Stream;
                                st.TSC_Stream = Bass.CreateStream(TSCFiles[new Random().Next(TSCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Volume, csc.Mod_TypeSpell_Volume);
                                Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TSC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case ProjTypeContainer.TypeBullet:

                        if (csc.ProjectileCrits_TypeBullet_Enabled == true)
                        {
                            if (TBPFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TBPFiles.Count != 0)
                            {
                                _ = new StreamType().TBP_Stream;
                                st.TBP_Stream = Bass.CreateStream(TBPFiles[new Random().Next(TBPFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TBP_Stream, ChannelAttribute.Volume, csc.Mod_TypeBullet_Volume);
                                Bass.ChannelSetAttribute(st.TBP_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TBP_Stream);
                            }
                            else
                            {
                                return;
                            }
                        };
                        break;

                    case ProjTypeContainer.TypeMelee:

                        if (csc.ProjectileCrits_TypeMelee_Enabled == true)
                        {
                            if (TMPFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TMPFiles.Count != 0)
                            {
                                _ = new StreamType().TMP_Stream;
                                st.TMP_Stream = Bass.CreateStream(TMPFiles[new Random().Next(TMPFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Volume, csc.Mod_TypeMelee_Volume);
                                Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TMP_Stream);
                            }
                            else
                            {
                                return;
                            }
                        };
                        break;

                    case ProjTypeContainer.TypeSummon:

                        if (csc.ProjectileCrits_TypeSummon_Enabled == true)
                        {
                            if (TSuCFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TSuCFiles.Count != 0)
                            {
                                _ = new StreamType().TSuC_Stream;
                                st.TSuC_Stream = Bass.CreateStream(TSuCFiles[new Random().Next(TSuCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TSuC_Stream, ChannelAttribute.Volume, csc.Mod_TypeSummon_Volume);
                                Bass.ChannelSetAttribute(st.TSuC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TSuC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case ProjTypeContainer.TypeMisc:

                        if (csc.ProjectileCrits_TypeMisc_Enabled == true)
                        {
                            if (TMiCFiles.Count == 0)
                            {
                                SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                            }
                            if (TMiCFiles.Count != 0)
                            {
                                _ = new StreamType().TMiC_Stream;
                                st.TMiC_Stream = Bass.CreateStream(TMiCFiles[new Random().Next(TMiCFiles.Count)]);

                                Bass.ChannelSetAttribute(st.TMiC_Stream, ChannelAttribute.Volume, csc.Mod_TypeMisc_Volume);
                                Bass.ChannelSetAttribute(st.TMiC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                Bass.ChannelPlay(st.TMiC_Stream);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case ProjTypeContainer.TypeUnknown:

                        if (csc.ProjectileCrits_TypeUnknown_Enabled == true)
                        {
                            if (proj.DamageType == DamageClass.Ranged)
                            {
                                if (TACFiles.Count == 0)
                                {
                                    SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                                }
                                if (TACFiles.Count != 0)
                                {
                                    _ = new StreamType().TAC_Stream;
                                    st.TAC_Stream = Bass.CreateStream(TACFiles[new Random().Next(TACFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Volume, csc.Mod_TypeArrow_Volume);
                                    Bass.ChannelSetAttribute(st.TAC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TAC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (proj.DamageType == DamageClass.Throwing)
                            {
                                {
                                    {
                                        SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                                    }
                                }
                                if (TTCFiles.Count != 0)
                                {
                                    _ = new StreamType().TTC_Stream;
                                    st.TTC_Stream = Bass.CreateStream(TTCFiles[new Random().Next(TTCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Volume, csc.Mod_TypeThrowing_Volume);
                                    Bass.ChannelSetAttribute(st.TTC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TTC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (proj.DamageType == DamageClass.Magic)
                            {
                                {
                                    if (TSCFiles.Count == 0)
                                    {
                                    }
                                    SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                                }
                                if (TSCFiles.Count != 0)
                                {
                                    _ = new StreamType().TSC_Stream;
                                    st.TSC_Stream = Bass.CreateStream(TSCFiles[new Random().Next(TSCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Volume, csc.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TSC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TSC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (proj.DamageType == DamageClass.Melee)
                            {
                                {
                                    {
                                        SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                                    }
                                }
                                if (TMPFiles.Count != 0)
                                {
                                    _ = new StreamType().TMP_Stream;
                                    st.TMP_Stream = Bass.CreateStream(TMPFiles[new Random().Next(TMPFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Volume, csc.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TMP_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TMP_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (proj.DamageType == DamageClass.Generic)
                            {
                                if (TUCFiles.Count == 0)
                                {
                                    SoundEngine.PlaySound(SoundID.CoinPickup, (int)target.position.X, (int)target.position.Y);
                                }
                                if (TUCFiles.Count != 0)
                                {
                                    _ = new StreamType().TUC_Stream;
                                    st.TUC_Stream = Bass.CreateStream(TUCFiles[new Random().Next(TUCFiles.Count)]);

                                    Bass.ChannelSetAttribute(st.TUC_Stream, ChannelAttribute.Volume, csc.Mod_TypeSpell_Volume);
                                    Bass.ChannelSetAttribute(st.TUC_Stream, ChannelAttribute.Pan, ((float)target.position.X - (float)Player.position.X) / (Main.screenWidth / 2));
                                    Bass.ChannelPlay(st.TUC_Stream);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}