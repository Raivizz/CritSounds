using ManagedBass;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Terraria.ModLoader;

namespace CritSounds
{
    internal class CritSounds : Mod
    {
        private readonly SHA256 _sha256 = SHA256.Create();

        //SHA256 hash
        private const string Sha256BassWin64 = "4bbb323f48fa7ea549abd59ecfc30e71b574d20f52e295b7e3ebf19f07f53efe";
//      private const string Sha256BassLinux = "5615970f4f76dd9bc6bee16d3a8f37d57762b13326f7ea921b146c8b659f0bdd";

        //Hash calculation stuff
        private byte[] GetHashSha256(string filename)
        {
            using FileStream stream = File.OpenRead(filename);
            return _sha256.ComputeHash(stream);
        }

        private static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (var b in bytes)
            {
                result += b.ToString("x2");
            }

            return result;
        }

        public CritSounds()
        {
            CritModdingDirectories cs = new();
            cs.CreateDirectories();
        }

        public override void Load()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new())
            {
                StreamType.CritSfxHandler csh = new();

                csh.CheckDirectoriesForMods();

                //If bass.dll exists, checks for the file hash and re-downloads it if the hash check fails.
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    if (File.Exists("bass.dll"))
                    {
                        if (BytesToString(GetHashSha256("bass.dll")) == Sha256BassWin64)
                        {
                            Logger.Info("bass.dll hash code matches");
                            Bass.Init();
                        }
                        else
                        {
                            Logger.Info("bass.dll does not match hash, re-downloading...");
                            File.Delete("bass.dll");
                            client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
                        }
                    }

                    //Downloads the BASS library if it doesn't exist
                    if (!File.Exists("bass.dll"))
                    {
                        Logger.Info("bass.dll not found, downloading...");
                        client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/x64/bass.dll", "bass.dll");
                    }
                }

                //Warns Linux users about requiring manual intervention for the BASS library file
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    if (!File.Exists("/usr/lib/libbass.so"))
                    {
                        throw new InvalidOperationException("/usr/lib/libbass.so not found. Linux users have to manually install the libbass library. Please see Crit Sounds' Workshop page for more info.");
                    }
                }
            }
            Bass.Init();
    }
}
}
