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
        private int _meleeStabCritsStream;
        private int _rangedCritsStream;
        private int _throwingCritsStream;
        private int _magicCritsStream;
        private int _meleeCritsStream;
        private int _summonCritsStream;
        private int _genericCritsStream;
        public class CritSfxHandler : ModPlayer
        {
            //Defines lists which are later used to contain file paths of all custom sounds
            private List<string> _meleeStabCritsFiles;
            private List<string> _rangedCritsFiles;
            private List<string> _throwingCritsFiles;
            private List<string> _magicCritsFiles;
            private List<string> _meleeCritsFiles;
            private List<string> _summonCritsFiles;
            private List<string> _genericCritsFiles;

            public void CheckDirectoriesForMods()
            {
                CritModdingDirectories csDirFill = new();

                //Fills the previously-defined lists with path files to all custom sounds
                _meleeStabCritsFiles =  new List<string>(Directory.GetFiles(csDirFill.MeleeStabCrits_Path));
                _rangedCritsFiles =     new List<string>(Directory.GetFiles(csDirFill.TypeRangedCrits_Path));
                _throwingCritsFiles =   new List<string>(Directory.GetFiles(csDirFill.TypeThrowingCrits_Path));
                _magicCritsFiles =      new List<string>(Directory.GetFiles(csDirFill.TypeMagicCrits_Path));
                _meleeCritsFiles =      new List<string>(Directory.GetFiles(csDirFill.TypeMeleeCrits_Path));
                _summonCritsFiles =     new List<string>(Directory.GetFiles(csDirFill.TypeSummonCrits_Path));
                _genericCritsFiles =    new List<string>(Directory.GetFiles(csDirFill.TypeGenericCrits_Path));
            }

            public override void OnEnterWorld(Player player)
            {
                if (!Directory.Exists(Main.SavePath + Path.DirectorySeparatorChar + "Crit Sounds" +
                                                      Path.DirectorySeparatorChar + "Custom"))
                    {
                        CritModdingDirectories csDirCheck = new();
                        csDirCheck.CreateDirectories();
                    }
                CheckDirectoriesForMods();
            }

            //Melee hitbox (stab) crits
            public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
            {
                StreamType st = new();

                bool meleeStabCritsEnabled = ModContent.GetInstance<CritSoundsConfig>().MeleeStabCrits_Enabled;

                if (crit && meleeStabCritsEnabled && item.type != ItemID.TheAxe)
                {
                    float meleeStabCritsVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_MeleeStab_Volume;

                    //No mod files detected
                    if (_meleeStabCritsFiles.Count == 0)
                    {
                        SoundEngine.PlaySound(CritSounds.MeleeStabCrits_Sound, target.position);
                    }

                    //At least one mod file exists.
                    if (_meleeStabCritsFiles.Count != 0)
                    {
                        _ = new StreamType()._meleeStabCritsStream;
                        st._meleeStabCritsStream = Bass.CreateStream(_meleeStabCritsFiles[new Random().Next(_meleeStabCritsFiles.Count)]);

                        Bass.ChannelSetAttribute(st._meleeStabCritsStream, ChannelAttribute.Volume, meleeStabCritsVolume);
                        Bass.ChannelPlay(st._meleeStabCritsStream);
                    }
                }
                if (crit && meleeStabCritsEnabled && item.type == ItemID.TheAxe)
                {
                    SoundEngine.PlaySound(CritSounds.Egg01Crits_Sound, target.position);
                }
            }

            public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
            {
                StreamType st = new();

                bool projectileCritsEnabled = ModContent.GetInstance<CritSoundsConfig>().ProjectileCrits_Enabled;

                if (crit && projectileCritsEnabled)
                {
                    if (proj.DamageType == DamageClass.Ranged)
                    {
                        float rangedVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeRanged_Volume;

                        if (_rangedCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeRangedCrits_Sound, target.position);
                        }

                        if (_rangedCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._rangedCritsStream;
                            st._rangedCritsStream = Bass.CreateStream(_rangedCritsFiles[new Random().Next(_rangedCritsFiles.Count)]);

                            //Introduction of hard limits to the position of the damaged enemy so that BASS doesn't reset itself to 0
                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._rangedCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._rangedCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._rangedCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._rangedCritsStream, ChannelAttribute.Volume, rangedVolume);
                            Bass.ChannelPlay(st._rangedCritsStream);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (proj.DamageType == DamageClass.Throwing)
                    {
                        float throwingVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeThrowing_Volume;

                        if (_throwingCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeThrowingCrits_Sound, target.position);
                        }

                        if (_throwingCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._throwingCritsStream;
                            st._throwingCritsStream = Bass.CreateStream(_throwingCritsFiles[new Random().Next(_throwingCritsFiles.Count)]);

                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._throwingCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._throwingCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._throwingCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._throwingCritsStream, ChannelAttribute.Volume, throwingVolume);
                            Bass.ChannelPlay(st._throwingCritsStream);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (proj.DamageType == DamageClass.Magic)
                    {
                        var magicVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeMagic_Volume;

                        if (_magicCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeMagicCrits_Sound, target.position);
                        }

                        if (_magicCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._magicCritsStream;
                            st._magicCritsStream = Bass.CreateStream(_magicCritsFiles[new Random().Next(_magicCritsFiles.Count)]);

                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._magicCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._magicCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._magicCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._magicCritsStream, ChannelAttribute.Volume, magicVolume);
                            Bass.ChannelPlay(st._magicCritsStream);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (proj.DamageType == DamageClass.Melee)
                    {
                        float meleeVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeMelee_Volume;

                        if (_meleeCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeMeleeCrits_Sound, target.position);
                        }

                        if (_meleeCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._meleeCritsStream;
                            st._meleeCritsStream = Bass.CreateStream(_meleeCritsFiles[new Random().Next(_meleeCritsFiles.Count)]);

                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._meleeCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._meleeCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._meleeCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._meleeCritsStream, ChannelAttribute.Volume, meleeVolume);
                            Bass.ChannelPlay(st._meleeCritsStream);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (proj.DamageType == DamageClass.Summon)
                    {
                        float summonVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeSummon_Volume;

                        if (_summonCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeSummonCrits_Sound, target.position);
                        }

                        if (_summonCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._summonCritsStream;
                            st._summonCritsStream = Bass.CreateStream(_summonCritsFiles[new Random().Next(_summonCritsFiles.Count)]);


                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._summonCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._summonCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._summonCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._summonCritsStream, ChannelAttribute.Volume, summonVolume);
                            Bass.ChannelPlay(st._summonCritsStream);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (proj.DamageType == DamageClass.Generic)
                    {
                        float genericVolume = ModContent.GetInstance<CritSoundsConfig>().Mod_TypeGeneric_Volume;

                        if (_genericCritsFiles.Count == 0)
                        {
                            SoundEngine.PlaySound(CritSounds.TypeGenericCrits_Sound, target.position);
                        }

                        if (_genericCritsFiles.Count != 0)
                        {
                            _ = new StreamType()._genericCritsStream;
                            st._genericCritsStream = Bass.CreateStream(_genericCritsFiles[new Random().Next(_genericCritsFiles.Count)]);

                            var critPosition = (target.position.X - Player.position.X) / (Main.screenWidth / 2);
                            switch (critPosition)
                            {
                                case > 1:
                                    Bass.ChannelSetAttribute(st._genericCritsStream, ChannelAttribute.Pan, 1);
                                    break;
                                case < -1:
                                    Bass.ChannelSetAttribute(st._genericCritsStream, ChannelAttribute.Pan, -1);
                                    break;
                                case > -1 and < 1:
                                    Bass.ChannelSetAttribute(st._genericCritsStream, ChannelAttribute.Pan, critPosition);
                                    break;
                            }

                            Bass.ChannelSetAttribute(st._genericCritsStream, ChannelAttribute.Volume, genericVolume);
                            Bass.ChannelPlay(st._genericCritsStream);
                        }
                    }
                }
            }
        }
    }
}