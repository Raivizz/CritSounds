using System;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Un4seen.Bass;

namespace CritSounds
{
    public class CheckModSounds : ModWorld
    {
		//Bit shenanigans
		private SHA256 Sha256 = SHA256.Create();
		public bool is64BitTerraria = false;
		
		//SHA256 hashes
		string SHA256_Bass32 = "6303f205127c3b16d9cf1bdf4617c96109a03c5f2669341fbc0e1d37cd776b29";
		string SHA256_Bass64 = "4231a54713aa4403f05f719aa76a845dd178e5f70f6a6ed6f217805e513251c7";
		string SHA256_BassAAC32 = "194d955b383513ed30238f033459c8bef99f0448fdd0d85c0faf13638d9b7ec5";
		string SHA256_BassAAC64 = "cf10fa23afb6ca5dc8db4cb525078f58c91bfaf8e3f2d575c81495019fe27ed8";
		string SHA256_BassFLAC32 = "03507e3fb3b2dfda8a79fbd4a745b1d401cde8c9f939fefd48678c42f211dcdb";
		string SHA256_BassFLAC64 = "9fbb108be78e6227705b5585100ba089b8d5a4bec3d86e765f8ddb5cb45b72a2";
		string SHA256_BassOPUS32 = "78f73fffa607004aa4a85279e8c670894363ed0354e2d20c56cc0dfea73c6d51";
		string SHA256_BassOPUS64 = "38a368951303dc95a600ceaeb9a34add6a7573433a10be98a81d81b3938e14ed";
		string SHA256_BassWMA32 = "a844247b7cdcac1a5f61c604e4db111b274616c0eb19a70cdfb073c8c2f3b375";
		string SHA256_BassWMA64 = "63feaeda2a371c93e5d7bc8a34fb0bf247a3ca77b33219f3a3a5d4d1eff129f8";
		
        public int Addon_AAC = 0;
        public int Addon_AC3 = 0;
        public int Addon_ADX = 0;
        public int Addon_AIX = 0;
        public int Addon_APE = 0;
        public int Addon_MPC = 0;
        public int Addon_SPX = 0;
        public int Addon_TTA = 0;
        public int Addon_FLAC = 0;
        public int Addon_OPUS = 0;
        public int Addon_WMA = 0;
        public int Addon_WV = 0;
		
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
			foreach (byte b in bytes) result += b.ToString("x2");
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
            WebClient client = new WebClient();
            CritSFXHandler csh = new CritSFXHandler();

            csh.CheckDirectoriesForMods();
			Is64Bit();

            //If bass.dll exists and Terraria process is 32-bit, checks for the file hash and re-downloads it if it's not the proper 32-bit library.
			if (File.Exists("bass.dll") && is64BitTerraria == false)
			{
				if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass32)
				{
					ErrorLogger.Log("[Crit Sounds] bass.dll hash code matches for a 32-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bass.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("bass.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");
				}			
			}
			
			//If bass.dll exists and Terraria process is 64-bit, checks for the file hash and re-downloads it if it's not the proper 64-bit library.
			if (File.Exists("bass.dll") && is64BitTerraria == true)
			{
				if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass64)
				{
					ErrorLogger.Log("bass.dll hash code matches for a 64-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("bass.dll for 64-bit process does not match hash, redownloading...");
					File.Delete("bass.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
				}			
			}
			//Downloads the 32-bit BASS library if it doesn't exist
			if (!File.Exists("bass.dll") && is64BitTerraria == false)
			{
					ErrorLogger.Log("[Crit Sounds] bass.dll for 32-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");	
			}
			
			//Downloads the 64-bit BASS library if it doesn't exist
			if (!File.Exists("bass.dll") && is64BitTerraria == true)
			{
					ErrorLogger.Log("bass.dll for 64-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");		
			}
	
            //Add-on support
            //AAC - 32 bit - file exists
            if (File.Exists("bass_aac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
            {
				if (BytesToString(GetHashSha256("bass_aac.dll")) == SHA256_BassAAC32)
				{
					ErrorLogger.Log("[Crit Sounds] bass_aac.dll hash code matches for a 32-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bass_aac.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("bass_aac.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_aac.dll", "bass_aac.dll");
				}
			}
			//AAC - 64 bit - if file exists
            if (File.Exists("bass_aac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
            {
				if (BytesToString(GetHashSha256("bass_aac.dll")) == SHA256_BassAAC64)
				{
					ErrorLogger.Log("bass_aac.dll hash code matches for a 64-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("bass_aac.dll for 64-bit process does not match hash, redownloading...");
					File.Delete("bass_aac.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bass_aac.dll", "bass_aac.dll");
				}
			}
			//AAC - 32 bit - file does not exist
			if (!File.Exists("bass_aac.dll") && is64BitTerraria == false)
			{
					ErrorLogger.Log("[Crit Sounds] bass_aac.dll for 32-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_aac.dll", "bass_aac.dll");	
			}
			//AAC - 64 bit - file does not exist
			if (!File.Exists("bass_aac.dll") && is64BitTerraria == true)
			{
					ErrorLogger.Log("bass_aac.dll for 64-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bass_aac.dll", "bass_aac.dll");		
			}
			
            //FLAC - 32 bit - file exists
            if (File.Exists("bassflac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
            {
				if (BytesToString(GetHashSha256("bassflac.dll")) == SHA256_BassFLAC32)
				{
					ErrorLogger.Log("[Crit Sounds] bassflac.dll hash code matches for a 32-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bassflac.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("bassflac.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bass_flac.dll", "bass_flac.dll");
				}
			}
			 //FLAC - 64 bit - file exists
            if (File.Exists("bassflac.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
            {
				if (BytesToString(GetHashSha256("bassflac.dll")) == SHA256_BassFLAC64)
				{
					ErrorLogger.Log("[Crit Sounds] bassflac.dll hash code matches for a 64-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bass_flac.dll for 64-bit process does not match hash, redownloading...");
					File.Delete("bassflac.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassflac.dll", "bassflac.dll");
				}
			}
			//FLAC - 32 bit - file does not exist
			if (!File.Exists("bassflac.dll") && is64BitTerraria == false)
			{
					ErrorLogger.Log("[Crit Sounds] bassflac.dll for 32-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassflac.dll", "bassflac.dll");	
			}
			//FLAC - 64 bit - file does not exist
			if (!File.Exists("bassflac.dll") && is64BitTerraria == true)
			{
					ErrorLogger.Log("bassflac.dll for 64-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassflac.dll", "bassflac.dll");		
			}
			
            //OPUS - 32 bit - file exists
            if (File.Exists("bassopus.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
            {
				if (BytesToString(GetHashSha256("bassopus.dll")) == SHA256_BassOPUS32)
				{
					ErrorLogger.Log("[Crit Sounds] bassopus.dll hash code matches for a 32-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bassopus.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("bassopus.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassopus.dll", "bassopus.dll");
				}
			}
			//OPUS - 64 bit - file exists
            if (File.Exists("bassopus.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
            {
				if (BytesToString(GetHashSha256("bassopus.dll")) == SHA256_BassOPUS64)
				{
					ErrorLogger.Log("[Crit Sounds] bassopus.dll hash code matches for a 64-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] bassopus.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("bassopus.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassopus.dll", "bassopus.dll");
				}
			}
			//OPUS - 32 bit - file does not exist
			if (!File.Exists("bassopus.dll") && is64BitTerraria == false)
			{
					ErrorLogger.Log("[Crit Sounds] bassopus.dll for 32-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/bassopus.dll", "bassopus.dll");	
			}
			//OPUS - 64 bit - file does not exist
			if (!File.Exists("bassopus.dll") && is64BitTerraria == true)
			{
					ErrorLogger.Log("bassopus.dll for 64-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/bassopus.dll", "bassopus.dll");		
			}
			
            //WMA - 32 bit - file exists
            if (File.Exists("basswma.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == false)
            {
				if (BytesToString(GetHashSha256("basswma.dll")) == SHA256_BassWMA32)
				{
					ErrorLogger.Log("[Crit Sounds] basswma.dll hash code matches for a 32-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] basswma.dll for 32-bit process does not match hash, redownloading...");
					File.Delete("basswma.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/basswma.dll", "basswma.dll");
				}
			}
			//WMA - 64 bit - file exists
            if (File.Exists("basswma.dll") && Config.BASSAddon_EnableAACAddon && is64BitTerraria == true)
            {
				if (BytesToString(GetHashSha256("basswma.dll")) == SHA256_BassWMA64)
				{
					ErrorLogger.Log("[Crit Sounds] basswma.dll hash code matches for a 64-bit process, initializing...");
					Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				}
				else
				{
					ErrorLogger.Log("[Crit Sounds] basswma.dll for 64-bit process does not match hash, redownloading...");
					File.Delete("basswma.dll");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/basswma.dll", "basswma.dll");
				}
			}
			//WMA - 32 bit - file does not exist
			if (!File.Exists("basswma.dll") && is64BitTerraria == false)
			{
					ErrorLogger.Log("[Crit Sounds] basswma.dll for 32-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x32/basswma.dll", "basswma.dll");	
			}
			//WMA - 64 bit - file does not exist
			if (!File.Exists("basswma.dll") && is64BitTerraria == true)
			{
					ErrorLogger.Log("basswma.dll for 64-bit process not found, downloading...");
					client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/x64/basswma.dll", "basswma.dll");		
			}
            AddonHandler.LoadAvailableAddons();
			}
        }
    }