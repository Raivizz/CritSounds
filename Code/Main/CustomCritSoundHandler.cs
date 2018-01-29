using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace CritSounds
{
	public class CritModdingFramework
	{
		public string MH_CritModFolder = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds");
		
		public string MSC_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Melee Stab");
		public string TAC_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Arrow Projectile");
		public string TTC_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Throwing Projectile");
		public string TSC_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Spell Projectile");
		public string TBP_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Bullet Projectile");
		public string TMP_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Melee Projectile");
		public string TSuC_P = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Summon Projectile");
		public string TMiC_P = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Misc Projectile");
		public string TUC_P  = (Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Crit Sounds" + Path.DirectorySeparatorChar.ToString() + "Custom" + Path.DirectorySeparatorChar.ToString() +  "Unknown Projectile");
			
		public void CreateDirectories()
		{
			Directory.CreateDirectory(MH_CritModFolder);
			
			char dirSeparator = Path.DirectorySeparatorChar;
			string dSep = dirSeparator.ToString();
			
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

			
