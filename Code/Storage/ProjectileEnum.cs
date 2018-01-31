using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace CritSounds
{
    public static class ProjTypeContainer
    {
        //Used in this class' only function, which returns the type of projectile.
        public const int TypeArrow = 1;
        public const int TypeThrowing = 2;
        public const int TypeSpell = 3;
        public const int TypeBullet = 4;
        public const int TypeMelee = 5;
        public const int TypeSummon = 6;
        public const int TypeMisc = 7;
        public const int TypeUnknown = 8;
    }

    public class ProjCheck
    {
        //A messy definition of all player-created projectile types.
        //Might be incomplete and therefore terrible.
        //All projectile names are defined in respective order and are separated by the hundreds.

        int[] arrow = new int[] {
        1, 2, 4, 5, 41, 91, 																																		//Wooden arrow, Fire arrow, Unholy arrow, Jester's arrow, Hellfire arrow, Holy Arrow
		103, 117, 120, 172,             																															//Cursed arrow, Bone arrow, Frost arrow, Frostburn arrow
		225, 278, 282,                  																															//Chlorophyte arrow, Ichor arrow, Venom arrow
		357,                            																															//Pulse Bolt
		469, 485, 495,             																																	//Bee arrow, Hellwing bat, Shadowflame arrow
		639, 640,                       																															//Lunar arrow, Lunar arrow trail
		706, 710                        																															//Phoenix Bow's projectile, Aerial Bane's projectile
		};

        int[] throwing = new int[] {
        3, 6, 19, 21, 24, 28, 29, 30, 33, 37, 48, 50, 52, 54,                                           															//Shuriken, Enchanted Boomerang, Flamarang, Bone, Spiky Ball, Bomb, Dynamite, Grenade, Thorn Chakram, Sticky Bomb, Throwing Knife, Glowstick, Wooden Boomerang, Poisoned Knife
		106, 113, 166, 183,                                                                                 														//Light Disc, Ice Boomerang, Snowball, Beenade
		272,                                                                                                														//Bananarang
		318, 320, 330, 333, 370, 397, 399,                                                                  														//Rotten Egg, Bloody Machete, Star Anise, Fruitcake Chakram, Love Potion, Sticky Grenade, Molotov Cocktail
		400, 401, 402,                                                                                      														//Molotov fire 1, 2 and 3
		507, 516, 517, 519, 520, 532, 598, 599,                                                             														//Javelin, Bouncy Bomb, Bouncy Grenade, Bomb Fish, Frost Daggerfish, Bone Glove, Bone Javelin, Bone Dagger
		637                                                                                                 														//Bouncy Dynamite
		};

        int[] spell = new int[] {
        7, 8, 15, 16, 22, 27, 34, 45, 76, 77, 78, 79, 88, 93, 94, 95,                                       														//Vilethorn base and tip, Ball of Fire, Magic Missile, Water Stream, Water Bolt, Flamelash, Demon Scythe, Quarter Note, Eighth Note, Tied Eighth Note, Rainbow Rod, Purple Laser, Magic Dagger, Crystal Storm, Cursed Flame
		114, 118, 121, 122, 123, 124, 125, 126, 150, 151, 152, 189,                                    																//Unholy Trident, Ice Bolt, Amethyst Bolt, Topaz Bolt, Sapphire Bolt, Emerald Bolt, Ruby Bolt, Diamond Bolt, Nettle Burst, Wasp
		237, 238, 239, 243, 244, 245, 250, 251, 253, 254, 255, 265, 270, 280, 294, 295, 296, 297,         															//Rain Cloud, Blood Cloud, Rainbow Gun, Ball of Frost, Magnet Sphere, Poison Fang, Skull, Golden Shower, Shadow Beam, Inferno, Lost Soul
        336, 337, 355, 359,                                                                                 														//Pine Needle, Blizzard, Venom Fang, Frostbolt Staff
		409, 410, 424, 425, 426, 440, 459, 460, 461, 476, 493, 494, 496,                                       														//Typhoon, Bubble, Meteor, Laser Machine Gun, Blaster, Soul Drain, Crystal Vile Shard, Shadowflame Hex Doll
		510, 511, 512, 513, 521, 522, 536, 597,                                                             														//Toxic Flast, Crystal Pulse, Medusa Head, Amber Bolt
		617, 619, 620, 632, 633, 634, 635, 635, 659, 660,                                                   														//Nebula Arcanum, Last Prism, Nebula Blaze, Spirit Flame, Sky Fracture
		704, 711                                                                                       																//Whirlwind of Infinite Wisdom, Betsy's Wrath
		};

        int[] bullet = new int[] {
        14, 36, 89, 90,                                                                                    															//Musket Ball, Meteor Shot, Crystal Bullet, Crystal Shard
		104, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 158, 159, 160, 161,               															//Cursed Bullet, Grenades and rockets, Coins
		207, 246, 249,                                                                                     															//Chlorophyte Bullet, Stynger
		338, 339, 340, 341,                                                                                															//Snowman Cannon
		443, 498,                                                                                          															//Electrosphere, Nail Gun
		661                                                                                                															//Onyx Blaster
		};

        int[] melee = new int[] {
        9, 25, 26, 35, 46, 47, 49, 57, 58, 59, 60, 61, 62, 63, 64, 66, 97,                                                                                          //Starfury, Ball O' Hurt, Blue Moon, Sunfury, Dark Lance, Trident, Spear, Chainsaws, Mythril Halberd, Adamantite Glaive, Cobalt Naginata
		105, 107, 116, 119, 130, 131, 132, 153, 154, 156, 157, 173, 182,                                                                                            //Gungnir, Drax, Beam Sword, Frostbrand, Mushroom Spear, Terra Blade, The Rotted Fork, The Meatball, True Excalibur, True Night's Edge, Enchanted Sword, Possessed Hatchet
		212, 213, 214, 215, 216, 217, 218, 219, 220, 222, 223, 224, 229, 247, 248, 252, 262, 263, 271, 273, 274,                                                    //Palladium weapons, Orichalcum weapons, Titanium weapons, Chlorophye weapons, Flower Pow, Chlorophyte Jachkammer, Golem Fist, Ice Sickle, KO Cannon, Chain Knife, Death Sickle
		301, 304, 306, 307, 321, 335, 342, 343, 344, 367, 368, 369, 383,                                                                                            //Paladin's Hammer, Vampire Knife, Scourge of the Corruptor, The Horseman's Blade, Christmas Tree Sword, North Pole, Obsidian Swordfish, Swordfish, Sawtooth Shark, Anchor
		404, 405, 427, 428, 429, 430, 431, 432, 445, 451, 481, 483, 484, 491, 497,                                                                                  //Flairon, Vortex weapons, Nebula weapons, Solar Flare weapons, Laser Drill, Influx Waver, Chain Guillotines, Seedler, Flying Knife, Shadowflame Knife
		502, 503, 509, 524, 534, 541, 542, 534, 544, 545, 546, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 595,       //Meowmere, Star Wrath, Butcher's Chainsaw, Bladetongue, All yoyos, Arkhalis
		603, 604, 609, 610, 611, 612, 636, 684, 697, 698, 699,                                                                                                      //Terrarian, Stardust weapons, Solar Eruption, Daybreak, Flying Dragon, Sleepy Octopod, Octopus Staff, Ghastly Glaive
		700, 707, 708, 709                                                                                                                                          //Ghastly Glaive, Sky Dragon's Fury
		};

        int[] summon = new int[] {
        191, 192, 193, 194, 195,                                                                                                                                    //Pygmies
		266,                                                                                                                                                        //Baby Slime
		308, 309, 317, 373, 374, 375, 376, 377, 378, 379, 387, 388, 389, 390, 391, 392, 393, 394, 395,                                                              //Frost Hydra, Ravens, Hornets, Imps, Queen Spider Turret,Spiders, Retanimini, Spazmamini, More spiders, Pirates
		407, 408, 423, 433,                                                                                                                                    		//Sharknado, UF
		533,                                                                                                                                                        //Deadly Sphere
		625, 626, 627, 628, 643, 644, 664, 666, 668, 680, 688, 689, 690, 694, 695, 696                                                                            	//Stardust Dragon, Rainbow Crystal, Flameburst Tower, Ballista, Lightning Aura, Explosive Trap
		};

        int[] misc = new int[] {
        12, 23, 42, 51, 65, 68, 85, 92, 99,                                                                                                                         //Falling Star, Harpoon, Sandgun, Seed, Flamethrower, Hallow Star, Boulder
		162, 163, 164, 181, 184, 190, 206, 221, 227, 240, 267, 281,                                                                                                 //Cannonball, Flare, Landmine, Bee, Poison Dart, Piranha Gun, Leaf Crystal, Flower Petal, Crystal Leaf, Poison Dart, Explosive Bunny
		310, 354,                                                                                                                                                   //Blue Flare
		434, 477, 478, 479, 480,                                                                                                                                    //Scutlix, Crystal Dart, Cursed Dart, Ichor Dart
		566, 567, 568, 569, 570, 571, 587, 591                                                                                                                      //Large Bee, Spore Sac, Paintball Gun, Mechanical Card
		};

        public int ProjIDExists(int ProjectileID)
        {
            //Runs through arrays, checking if any of them have the projectile that just hit an enemy
            //If none of the arrays contain the item ID, Unknown Type is returned and a damage type check is ran in the Crit Handler script
            if (ProjectileID != 0)
            {
                if (arrow.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeArrow;
                }

                if (throwing.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeThrowing;
                }

                if (spell.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeSpell;
                }

                if (bullet.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeBullet;
                }

                if (melee.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeMelee;
                }

                if (summon.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeSummon;
                }

                if (misc.Contains(ProjectileID))
                {
                    return ProjTypeContainer.TypeMisc;
                }
            }
            return ProjTypeContainer.TypeUnknown;
        }
    }
}