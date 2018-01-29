using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace CritSounds
{
    public class CritSFXHandler : ModPlayer
    {
		//The section where all the basic scripting magic happens.
		//Future updates may include either more sounds or more advanced scripting shenanigans.
		//Anyone is free to use this code for their own needs.
		
		int ProjectileType = 0;
		
		//Melee crits
		//Plays when a player deals a crit to a hostile NPC with a melee weapon.
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			if ((crit == true) && (Config.MeleeStabCrits_Enabled == true) && (item.type != 1305))
			{
				int MSRand = new Random().Next(1, 4);
				
				if (MSRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit01")); }
				if (MSRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit02")); }
				if (MSRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit03")); }
				if (MSRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Melee_Stab/MeleeStab_Crit04")); }
			}
			
			//Egg 01
			if ((crit == true) && (Config.MeleeStabCrits_Enabled == true) && (item.type == 1305))
			{
				int Egg1Rand = new Random().Next(1, 18);
				
				if (Egg1Rand == 1)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_01")); }
				if (Egg1Rand == 2)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_02")); }
				if (Egg1Rand == 3)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_03")); }
				if (Egg1Rand == 4)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_04")); }
				if (Egg1Rand == 5)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_05")); }
				if (Egg1Rand == 6)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_06")); }
				if (Egg1Rand == 7)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_07")); }
				if (Egg1Rand == 8)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_08")); }
				if (Egg1Rand == 9)  { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_09")); }
				if (Egg1Rand == 10) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_10")); }
				if (Egg1Rand == 11) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_11")); }
				if (Egg1Rand == 12) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_12")); }
				if (Egg1Rand == 13) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_13")); }
				if (Egg1Rand == 14) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_14")); }
				if (Egg1Rand == 15) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_15")); }
				if (Egg1Rand == 16) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_16")); }
				if (Egg1Rand == 17) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_17")); }
				if (Egg1Rand == 18) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Eggs/EggSet01/ES1_18")); }
			}
		}
		
		//Projectile crits
		//Plays when a player deals a crit to a hostile NPC with a projectile.
		//Starting with version 1.1.0, projectiles are now categorized and have respective sounds assigned.
		public override void OnHitNPCWithProj (Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if ((crit == true) && (Config.ProjectileCrits_Enabled == true))
			{
				ProjCheck pc1 = new ProjCheck();
				
				ProjectileType = (pc1.ProjIDExists(proj.type));
				switch (ProjectileType)
				{
					//Arrows
					case ProjTypeContainer.TypeArrow:

					if (Config.ProjectileCrits_TypeArrow_Enabled == true)
					{
						int ARRand = new Random().Next(1, 4);
						if (ARRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01")); }
						if (ARRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02")); }
						if (ARRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03")); }
						if (ARRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04")); }
					}
					break;

					//Throwables
					case ProjTypeContainer.TypeThrowable:
					
					if (Config.ProjectileCrits_TypeThrowable_Enabled == true)
					{
						int THRand = new Random().Next(1, 4);
						if (THRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit01")); }
						if (THRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit02")); }
						if (THRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit03")); }
						if (THRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit04")); }
					}
					break;
					
					//Spells
					case ProjTypeContainer.TypeSpell:
					
					if (Config.ProjectileCrits_TypeSpell_Enabled == true)
					{
						int SPRand = new Random().Next(1, 6);
						if (SPRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01")); }
						if (SPRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02")); }
						if (SPRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03")); }
						if (SPRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04")); }
						if (SPRand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05")); }
						if (SPRand == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06")); }
					}
					break;
					
					//Bullets
					case ProjTypeContainer.TypeBullet:
					
					if (Config.ProjectileCrits_TypeBullet_Enabled == true)
					{
						int BURand = new Random().Next(1, 5);
						if (BURand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit01")); }
						if (BURand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit02")); }
						if (BURand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit03")); }
						if (BURand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit04")); }
						if (BURand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeBullet/Bullet_Crit05")); }
					}
					break;
				
					//Melee
					case ProjTypeContainer.TypeMelee:
					
					if (Config.ProjectileCrits_TypeMelee_Enabled == true)
					{
						int MERand = new Random().Next(1, 4);
						if (MERand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01")); }
						if (MERand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02")); }
						if (MERand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03")); }
						if (MERand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04")); }
					}
					break;
				
					//Summon
					case ProjTypeContainer.TypeSummon:
					
					if (Config.ProjectileCrits_TypeSummon_Enabled == true)
					{
						int SURand = new Random().Next(1, 4);
						if (SURand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit01")); }
						if (SURand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit02")); }
						if (SURand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit03")); }
						if (SURand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSummon/Summon_Crit04")); }
					}
					break;
				
					//Miscellaneous
					case ProjTypeContainer.TypeMisc:
					
					if (Config.ProjectileCrits_TypeMisc_Enabled == true)
					{
						int MIRand = new Random().Next(1, 6);
						if (MIRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit01")); }
						if (MIRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit02")); }
						if (MIRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit03")); }
						if (MIRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit04")); }
						if (MIRand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit05")); }
						if (MIRand == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMisc/Misc_Crit06")); }
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
							int U_ARRand = new Random().Next(1, 4);
							if (U_ARRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit01")); }
							if (U_ARRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit02")); }
							if (U_ARRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit03")); }
							if (U_ARRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeArrow/Arrow_Crit04")); }
						}
						
						if (proj.melee)
						{
							int U_MERand = new Random().Next(1, 4);
							if (U_MERand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit01")); }
							if (U_MERand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit02")); }
							if (U_MERand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit03")); }
							if (U_MERand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeMelee/Melee_Crit04")); }
						}
						
						if (proj.thrown)
						{
							int U_THRand = new Random().Next(1, 4);
							if (U_THRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit01")); }
							if (U_THRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit02")); }
							if (U_THRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit03")); }
							if (U_THRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeThrowable/Throwable_Crit04")); }
						}
						
						if (proj.magic)
						{
							int U_SPRand = new Random().Next(1, 6);
							if (U_SPRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit01")); }
							if (U_SPRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit02")); }
							if (U_SPRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit03")); }
							if (U_SPRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit04")); }
							if (U_SPRand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit05")); }
							if (U_SPRand == 6) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeSpell/Spell_Crit06")); }
						}
						
						if ((!proj.ranged) && (!proj.melee) && (!proj.thrown) && (!proj.magic))
						{
							int UNRand = new Random().Next(1, 5);
							if (UNRand == 1) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit01")); }
							if (UNRand == 2) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit02")); }
							if (UNRand == 3) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit03")); }
							if (UNRand == 4) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit04")); }
							if (UNRand == 5) { Main.PlaySound(50, (int)target.position.X, (int)target.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Crits/Projectiles/TypeUnknown/Unknown_Crit05")); }
						}
					}
					break;
				}
			}			
		}
	}
}