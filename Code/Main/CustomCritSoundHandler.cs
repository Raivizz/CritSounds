using System.IO;
using Terraria;

namespace CritSounds
{
    public class CritModdingFramework
    {

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
            _ = Directory.CreateDirectory(MH_CritModFolder);

            //Creates directories for all projectile categories
            _ = Directory.CreateDirectory(MSC_P);
            _ = Directory.CreateDirectory(TAC_P);
            _ = Directory.CreateDirectory(TTC_P);
            _ = Directory.CreateDirectory(TSC_P);
            _ = Directory.CreateDirectory(TBP_P);
            _ = Directory.CreateDirectory(TMP_P);
            _ = Directory.CreateDirectory(TSuC_P);
            _ = Directory.CreateDirectory(TMiC_P);
            _ = Directory.CreateDirectory(TUC_P);
        }
    }
}