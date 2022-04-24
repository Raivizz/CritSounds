using ManagedBass;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Terraria.ModLoader;

namespace CritSounds
{
    internal class CritSounds : Mod
    {
        private readonly SHA256 Sha256 = SHA256.Create();

        //SHA256 hash
        private readonly string SHA256_Bass64 = "4bbb323f48fa7ea549abd59ecfc30e71b574d20f52e295b7e3ebf19f07f53efe";

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

        public CritSounds()
        {
            CritModdingDirectories CS = new();
            CS.CreateDirectories();
        }

        public override void Load()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new())
            {
                CritSoundsConfig csc = new();
                CritSFXHandler csh = new();

                csh.CheckDirectoriesForMods();

                //If bass.dll exists, checks for the file hash and re-downloads it if the hash check fails.
                if (File.Exists("bass.dll"))
                {
                    if (BytesToString(GetHashSha256("bass.dll")) == SHA256_Bass64)
                    {
                        Logger.Info("bass.dll hash code matches");
                        Bass.Init();
                    }
                    else
                    {
                        Logger.Info("bass.dll does not match hash, redownloading...");
                        File.Delete("bass.dll");
                        client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/1.4_port/Dependencies/bass.dll", "bass.dll");
                    }
                }

                //Downloads the BASS library if it doesn't exist
                if (!File.Exists("bass.dll"))
                {
                    Logger.Info("bass.dll not found, downloading...");
                    client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/1.4_port/Dependencies/bass.dll", "bass.dll");
                }
                //Downloads the Linux BASS library if it doesn't exist
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
                }
            }
            Bass.Init();
        }
    }
}
