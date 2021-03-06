using System.Linq;

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
        //Definition list of all player-created projectile types.

        private readonly int[] arrow = new int[] {
        1, 2, 4, 5, 41, 91,
        103, 117, 120, 172,
        225, 278, 282,
        357,
        469, 485, 495,
        639, 640,
        706, 710
        };

        private readonly int[] throwing = new int[] {
        3, 6, 19, 21, 24, 28, 29, 30, 33, 37, 48, 50, 52, 54,
        106, 113, 166, 183,
        272,
        318, 320, 330, 333, 370, 397, 399,
        400, 401, 402,
        507, 516, 517, 519, 520, 532, 598, 599,
        637
        };

        private readonly int[] spell = new int[] {
        7, 8, 15, 16, 22, 27, 34, 45, 76, 77, 78, 79, 88, 93, 94, 95,
        114, 118, 121, 122, 123, 124, 125, 126, 150, 151, 152, 189,
        237, 238, 239, 243, 244, 245, 250, 251, 253, 254, 255, 265, 270, 280, 294, 295, 296, 297,
        336, 337, 355, 359,
        409, 410, 424, 425, 426, 440, 459, 460, 461, 476, 493, 494, 496,
        510, 511, 512, 513, 521, 522, 536, 597,
        617, 619, 620, 632, 633, 634, 635, 635, 659, 660,
        704, 711
        };

        private readonly int[] bullet = new int[] {
        14, 36, 89, 90,
        104, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 158, 159, 160, 161,
        207, 246, 249,
        338, 339, 340, 341,
        443, 498,
        661
        };

        private readonly int[] melee = new int[] {
        9, 25, 26, 35, 46, 47, 49, 57, 58, 59, 60, 61, 62, 63, 64, 66, 97,
        105, 107, 116, 119, 130, 131, 132, 153, 154, 156, 157, 173, 182,
        212, 213, 214, 215, 216, 217, 218, 219, 220, 222, 223, 224, 229, 247, 248, 252, 262, 263, 271, 273, 274,
        301, 304, 306, 307, 321, 335, 342, 343, 344, 367, 368, 369, 383,
        404, 405, 427, 428, 429, 430, 431, 432, 445, 451, 481, 483, 484, 491, 497,
        502, 503, 509, 524, 534, 541, 542, 534, 544, 545, 546, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 595,
        603, 604, 609, 610, 611, 612, 636, 684, 697, 698, 699,
        700, 707, 708, 709
        };

        private readonly int[] summon = new int[] {
        191, 192, 193, 194, 195,
        266,
        308, 309, 317, 373, 374, 375, 376, 377, 378, 379, 387, 388, 389, 390, 391, 392, 393, 394, 395,
        407, 408, 423, 433,
        533,
        625, 626, 627, 628, 643, 644, 664, 666, 668, 680, 688, 689, 690, 694, 695, 696
        };

        private readonly int[] misc = new int[] {
        12, 23, 42, 51, 65, 68, 85, 92, 99,
        162, 163, 164, 181, 184, 190, 206, 221, 227, 240, 267, 281,
        310, 354,
        434, 477, 478, 479, 480,
        566, 567, 568, 569, 570, 571, 587, 591
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