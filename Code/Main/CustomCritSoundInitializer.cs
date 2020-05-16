using ManagedBass;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Terraria.ModLoader;

namespace CritSounds
{
	public class CheckModSounds : ModWorld
	{
		//Bit shenanigans
		private readonly SHA256 Sha256 = SHA256.Create();
		internal bool is64BitTerraria = false;

		//SHA256 hashes
		private readonly string SHA256_Bass32 = "3cd00f456f51829eda119e0e133acc1e45a5930d61fc335a2e9aa688a836a24d";
		private readonly string SHA256_Bass64 = "c5d61ec9f9d16ebafd4403a270896226bb30bf28d3e9462e38ebb97b86c3f115";
		private readonly string SHA256_BassAAC32 = "194d955b383513ed30238f033459c8bef99f0448fdd0d85c0faf13638d9b7ec5";
		private readonly string SHA256_BassAAC64 = "cf10fa23afb6ca5dc8db4cb525078f58c91bfaf8e3f2d575c81495019fe27ed8";
		private readonly string SHA256_BassFLAC32 = "03507e3fb3b2dfda8a79fbd4a745b1d401cde8c9f939fefd48678c42f211dcdb";
		private readonly string SHA256_BassFLAC64 = "9fbb108be78e6227705b5585100ba089b8d5a4bec3d86e765f8ddb5cb45b72a2";
		private readonly string SHA256_BassOPUS32 = "78f73fffa607004aa4a85279e8c670894363ed0354e2d20c56cc0dfea73c6d51";
		private readonly string SHA256_BassOPUS64 = "38a368951303dc95a600ceaeb9a34add6a7573433a10be98a81d81b3938e14ed";
		private readonly string SHA256_BassWMA32 = "a844247b7cdcac1a5f61c604e4db111b274616c0eb19a70cdfb073c8c2f3b375";
		private readonly string SHA256_BassWMA64 = "63feaeda2a371c93e5d7bc8a34fb0bf247a3ca77b33219f3a3a5d4d1eff129f8";

		internal int Addon_AAC = 0;
		internal int Addon_AC3 = 0;
		internal int Addon_ADX = 0;
		internal int Addon_AIX = 0;
		internal int Addon_APE = 0;
		internal int Addon_MPC = 0;
		internal int Addon_SPX = 0;
		internal int Addon_TTA = 0;
		internal int Addon_FLAC = 0;
		internal int Addon_OPUS = 0;
		internal int Addon_WMA = 0;
		internal int Addon_WV = 0;

		//Hash calculation stuff
		private byte[] GetHashSha256(string filename)
		{
			using (FileStream stream = File.OpenRead(filename))
			{
				return Sha256.ComputeHash(stream);
			}
		}
		public static string BytesToString(byte[] bytes)
		{
			string result = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				byte b = bytes[i];
				result += b.ToString("x2");
			}

			return result;
		}

		//64-bit process check
		private bool Is64Bit()
		{
			if (IntPtr.Size == 8)
			{
				is64BitTerraria = true;
				return true;
			}
			else
			{
				is64BitTerraria = false;
				return false;
			}
		}

		public override void Initialize()
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			using (WebClient client = new WebClient())
			{
				CritSFXHandler csh = new CritSFXHandler();

				csh.CheckDirectoriesForMods();
				Is64Bit();

				//If bass.dll exists and Terraria process is 32-bit, checks for the file hash and re-downloads it if it's not the proper 32-bit library.
				if (File.Exists("bass.dll") && is64BitTerraria == false)
				{
					if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass32)
					{
						mod.Logger.InfoFormat("{0} | bass.dll hash code matches for a 32-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} | bass.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bass.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");
					}
				}

				//If bass.dll exists and Terraria process is 64-bit, checks for the file hash and re-downloads it if it's not the proper 64-bit library.
				if (File.Exists("bass.dll") && is64BitTerraria == true)
				{
					if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass64)
					{
						mod.Logger.InfoFormat("{0} bass.dll hash code matches for a 64-bit process", mod.Name);
						Bass.Init();
					}
					else
					{
						mod.Logger.InfoFormat("{0} bass.dll for 64-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bass.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
					}
				}
				//Downloads the 32-bit BASS library if it doesn't exist
				if (!File.Exists("bass.dll") && is64BitTerraria == false)
				{
					mod.Logger.InfoFormat("{0} bass.dll for 32-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");
				}

				//Downloads the 64-bit BASS library if it doesn't exist
				if (!File.Exists("bass.dll") && is64BitTerraria == true)
				{
					mod.Logger.InfoFormat("{0} bass.dll for 64-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
				}

				//Add-on support
				//AAC - 32 bit - file exists
				if (File.Exists("bass_aac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
				{
					if (BytesToString(GetHashSha256("bass_aac.dll")) == SHA256_BassAAC32)
					{
						mod.Logger.InfoFormat("{0} bass_aac.dll hash code matches for a 32-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bass_aac.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bass_aac.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_aac.dll", "bass_aac.dll");
					}
				}
				//AAC - 64 bit - if file exists
				if (File.Exists("bass_aac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
				{
					if (BytesToString(GetHashSha256("bass_aac.dll")) == SHA256_BassAAC64)
					{
						mod.Logger.InfoFormat("{0} bass_aac.dll hash code matches for a 64-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bass_aac.dll for 64-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bass_aac.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bass_aac.dll", "bass_aac.dll");
					}
				}
				//AAC - 32 bit - file does not exist
				if (!File.Exists("bass_aac.dll") && is64BitTerraria == false)
				{
					mod.Logger.InfoFormat("{0} bass_aac.dll for 32-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_aac.dll", "bass_aac.dll");
				}
				//AAC - 64 bit - file does not exist
				if (!File.Exists("bass_aac.dll") && is64BitTerraria == true)
				{
					mod.Logger.InfoFormat("{0} bass_aac.dll for 64-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bass_aac.dll", "bass_aac.dll");
				}

				//FLAC - 32 bit - file exists
				if (File.Exists("bassflac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
				{
					if (BytesToString(GetHashSha256("bassflac.dll")) == SHA256_BassFLAC32)
					{
						mod.Logger.InfoFormat("{0} bassflac.dll hash code matches for a 32-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bassflac.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bassflac.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_flac.dll", "bass_flac.dll");
					}
				}
				//FLAC - 64 bit - file exists
				if (File.Exists("bassflac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
				{
					if (BytesToString(GetHashSha256("bassflac.dll")) == SHA256_BassFLAC64)
					{
						mod.Logger.InfoFormat("{0} bassflac.dll hash code matches for a 64-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bass_flac.dll for 64-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bassflac.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassflac.dll", "bassflac.dll");
					}
				}
				//FLAC - 32 bit - file does not exist
				if (!File.Exists("bassflac.dll") && is64BitTerraria == false)
				{
					mod.Logger.InfoFormat("{0} bassflac.dll for 32-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassflac.dll", "bassflac.dll");
				}
				//FLAC - 64 bit - file does not exist
				if (!File.Exists("bassflac.dll") && is64BitTerraria == true)
				{
					mod.Logger.InfoFormat("{0} bassflac.dll for 64-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassflac.dll", "bassflac.dll");
				}

				//OPUS - 32 bit - file exists
				if (File.Exists("bassopus.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
				{
					if (BytesToString(GetHashSha256("bassopus.dll")) == SHA256_BassOPUS32)
					{
						mod.Logger.InfoFormat("{0} bassopus.dll hash code matches for a 32-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bassopus.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bassopus.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassopus.dll", "bassopus.dll");
					}
				}
				//OPUS - 64 bit - file exists
				if (File.Exists("bassopus.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
				{
					if (BytesToString(GetHashSha256("bassopus.dll")) == SHA256_BassOPUS64)
					{
						mod.Logger.InfoFormat("{0} bassopus.dll hash code matches for a 64-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} bassopus.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("bassopus.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassopus.dll", "bassopus.dll");
					}
				}
				//OPUS - 32 bit - file does not exist
				if (!File.Exists("bassopus.dll") && is64BitTerraria == false)
				{
					mod.Logger.InfoFormat("{0} bassopus.dll for 32-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassopus.dll", "bassopus.dll");
				}
				//OPUS - 64 bit - file does not exist
				if (!File.Exists("bassopus.dll") && is64BitTerraria == true)
				{
					mod.Logger.InfoFormat("{0} bassopus.dll for 64-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassopus.dll", "bassopus.dll");
				}

				//WMA - 32 bit - file exists
				if (File.Exists("basswma.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
				{
					if (BytesToString(GetHashSha256("basswma.dll")) == SHA256_BassWMA32)
					{
						mod.Logger.InfoFormat("{0} basswma.dll hash code matches for a 32-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} basswma.dll for 32-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("basswma.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/basswma.dll", "basswma.dll");
					}
				}
				//WMA - 64 bit - file exists
				if (File.Exists("basswma.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
				{
					if (BytesToString(GetHashSha256("basswma.dll")) == SHA256_BassWMA64)
					{
						mod.Logger.InfoFormat("{0} basswma.dll hash code matches for a 64-bit process", mod.Name);
					}
					else
					{
						mod.Logger.InfoFormat("{0} basswma.dll for 64-bit process does not match hash, redownloading...", mod.Name);
						File.Delete("basswma.dll");
						client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/basswma.dll", "basswma.dll");
					}
				}
				//WMA - 32 bit - file does not exist
				if (!File.Exists("basswma.dll") && is64BitTerraria == false)
				{
					mod.Logger.InfoFormat("{0} basswma.dll for 32-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/basswma.dll", "basswma.dll");
				}
				//WMA - 64 bit - file does not exist
				if (!File.Exists("basswma.dll") && is64BitTerraria == true)
				{
					mod.Logger.InfoFormat("{0} basswma.dll for 64-bit process not found, downloading...", mod.Name);
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/basswma.dll", "basswma.dll");
				}
			}
			AddonHandler.LoadAvailableAddons();
			Bass.Init();
		}
	}
}