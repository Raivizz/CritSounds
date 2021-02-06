using ManagedBass;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Terraria.ModLoader;

namespace CritSounds
{
    internal class CritSounds : Mod
    {
        //Bit shenanigans
        private readonly SHA256 Sha256 = SHA256.Create();
        internal bool is64BitTerraria = false;

        //SHA256 hashes
        private readonly string SHA256_Bass32 = "3cd00f456f51829eda119e0e133acc1e45a5930d61fc335a2e9aa688a836a24d";
        private readonly string SHA256_Bass64 = "c5d61ec9f9d16ebafd4403a270896226bb30bf28d3e9462e38ebb97b86c3f115";

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

        public CritSounds()
        {
            CritModdingFramework critDir = new CritModdingFramework();
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadSounds = true
            };

            critDir.CreateDirectories();
        }

        public override void Load()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new WebClient())
            {
                CritSoundsConfig csc = new CritSoundsConfig();
                CritSFXHandler csh = new CritSFXHandler();

                csh.CheckDirectoriesForMods();
                Is64Bit();

                //If bass.dll exists and Terraria process is 32-bit, checks for the file hash and re-downloads it if it's not the proper 32-bit library.
                if (File.Exists("bass.dll") && is64BitTerraria == false)
                {
                    if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass32)
                    {
                        Logger.Info("| bass.dll hash code matches for a 32-bit process");
                    }
                    else
                    {
                        Logger.Info("| bass.dll for 32-bit process does not match hash, redownloading...");
                        File.Delete("bass.dll");
                        client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");
                    }
                }

                //If bass.dll exists and Terraria process is 64-bit, checks for the file hash and re-downloads it if it's not the proper 64-bit library.
                if (File.Exists("bass.dll") && is64BitTerraria == true)
                {
                    if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass64)
                    {
                        Logger.Info("bass.dll hash code matches for a 64-bit process");
                        Bass.Init();
                    }
                    else
                    {
                        Logger.Info("bass.dll for 64-bit process does not match hash, redownloading...");
                        File.Delete("bass.dll");
                        client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
                    }
                }
                //Downloads the 32-bit BASS library if it doesn't exist
                if (!File.Exists("bass.dll") && is64BitTerraria == false)
                {
                    Logger.Info("bass.dll for 32-bit process not found, downloading...");
                    client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x32/bass.dll", "bass.dll");
                }

                //Downloads the 64-bit BASS library if it doesn't exist
                if (!File.Exists("bass.dll") && is64BitTerraria == true)
                {
                    Logger.Info("bass.dll for 64-bit process not found, downloading...");
                    client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
                }
            }
            Bass.Init();
        }
    }
}