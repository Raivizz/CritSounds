using System.IO;
using Terraria;

namespace CritSounds
{
    public class CritModdingFramework
    {
        public static CritModdingFramework Instance;

        internal string MH_CritModFolder = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds";

        //Melee stab crits - path
        internal string MSC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Melee Stab";

        //Type arrow crits - path
        internal string TAC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Arrow Projectile";

        //Type throwing crits - path
        internal string TTC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Throwing Projectile";

        //Type spell crits - path
        internal string TSC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Spell Projectile";

        //Type bullet crits - path
        internal string TBP_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Bullet Projectile";

        //Type melee crits - path
        internal string TMP_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Melee Projectile";

        //Type summon crits - path
        internal string TSuC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Summon Projectile";

        //Type miscellaneous crits - path
        internal string TMiC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Misc Projectile";

        //Type unknown crits - path
        internal string TUC_P = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() + "Unknown Projectile";

        public void CreateDirectories()
        {
            Directory.CreateDirectory(MH_CritModFolder);

            //Creates directories for all projectile categories
            Directory.CreateDirectory(MSC_P);
            Directory.CreateDirectory(TAC_P);
            Directory.CreateDirectory(TTC_P);
            Directory.CreateDirectory(TSC_P);
            Directory.CreateDirectory(TBP_P);
            Directory.CreateDirectory(TMP_P);
            Directory.CreateDirectory(TSuC_P);
            Directory.CreateDirectory(TMiC_P);
            Directory.CreateDirectory(TUC_P);
        }
    }
}