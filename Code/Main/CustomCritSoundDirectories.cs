using System.IO;
using Terraria;

namespace CritSounds
{
    public class CritModdingDirectories
    {
        internal string CritModFolder = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds";

        //Melee stab crits - path
        internal string MeleeStabCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Melee Stab";

        //Type ranged crits - path
        internal string TypeRangedCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Ranged Projectile";

        //Type throwing crits - path
        internal string TypeThrowingCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Throwing Projectile";

        //Type magic crits - path
        internal string TypeMagicCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Magic Projectile";

        //Type melee crits - path
        internal string TypeMeleeCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Melee Projectile";

        //Type summon crits - path
        internal string TypeSummonCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Summon Projectile";

        //Type generic crits - path
        internal string TypeGenericCrits_Path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Generic Projectile";

        public void CreateDirectories()
        {
            Directory.CreateDirectory(CritModFolder);

            //Creates directories for all projectile categories
            Directory.CreateDirectory(MeleeStabCrits_Path);
            Directory.CreateDirectory(TypeRangedCrits_Path);
            Directory.CreateDirectory(TypeThrowingCrits_Path);
            Directory.CreateDirectory(TypeMagicCrits_Path);
            Directory.CreateDirectory(TypeMeleeCrits_Path);
            Directory.CreateDirectory(TypeSummonCrits_Path);
            Directory.CreateDirectory(TypeGenericCrits_Path);
        } 
    }
}