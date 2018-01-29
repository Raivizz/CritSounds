using System;
using System.Net;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Un4seen.Bass;

namespace CritSounds
{
    public class CheckModSounds : ModWorld
    {
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
        //public int Addon_ZXTUNE = 0;

        public override void Initialize()
        {
            WebClient client = new WebClient();
            CritSFXHandler csh = new CritSFXHandler();

            csh.CheckDirectoriesForMods();

            if (!File.Exists("bass.dll"))
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Dependencies/bass.dll", "bass.dll");
                ErrorLogger.Log("bass.dll not found, downloading...");
            }
            else
            {
                Bass.BASS_Init(-1, Config.BASSDeviceFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            }

            //Add-on support
            //AAC
            if (!File.Exists("bass_aac.dll") & Config.BASSAddon_EnableAACAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_aac.dll", "bass_aac.dll");
                ErrorLogger.Log("AAC add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //AC3
            if (!File.Exists("bass_ac3.dll") & Config.BASSAddon_EnableAC3Addon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_ac3.dll", "bass_ac3.dll");
                ErrorLogger.Log("AC3 add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //ADX
            if (!File.Exists("bass_adx.dll") & Config.BASSAddon_EnableADXAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_adx.dll", "bass_adx.dll");
                ErrorLogger.Log("ADX add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //AIX
            if (!File.Exists("bass_aix.dll") & Config.BASSAddon_EnableAIXAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_aix.dll", "bass_aix.dll");
                ErrorLogger.Log("AIX add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //APE
            if (!File.Exists("bass_ape.dll") & Config.BASSAddon_EnableAPEAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_ape.dll", "bass_ape.dll");
                ErrorLogger.Log("APE add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //MPC
            if (!File.Exists("bass_mpc.dll") & Config.BASSAddon_EnableMPCAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_mpc.dll", "bass_mpc.dll");
                ErrorLogger.Log("MPC add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //SPX
            if (!File.Exists("bass_spx.dll") & Config.BASSAddon_EnableSPXAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_spx.dll", "bass_spx.dll");
                ErrorLogger.Log("SPX add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //TTA
            if (!File.Exists("bass_tta.dll") & Config.BASSAddon_EnableTTAAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bass_tta.dll", "bass_tta.dll");
                ErrorLogger.Log("TTA add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //FLAC
            if (!File.Exists("bassflac.dll") & Config.BASSAddon_EnableFLACAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bassflac.dll", "bassflac.dll");
                ErrorLogger.Log("FLAC add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //OPUS
            if (!File.Exists("bassopus.dll") & Config.BASSAddon_EnableOPUSAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/bassopus.dll", "bassopus.dll");
                ErrorLogger.Log("OPUS add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //WMA
            if (!File.Exists("basswma.dll") & Config.BASSAddon_EnableWMAAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/basswma.dll", "basswma.dll");
                ErrorLogger.Log("WMA add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //WV
            if (!File.Exists("basswv.dll") & Config.BASSAddon_EnableWVAddon)
            {
                client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/basswv.dll", "basswv.dll");
                ErrorLogger.Log("WV add-on has been enabled, yet file not found in game directory. Downloading...");
            }
            //ZXTune
            //if (!File.Exists("basszxtune.dll") & Config.BASSAddon_EnableZXTuneAddon)
            //{
            //    client.DownloadFile("https://github.com/Raivizz/CritSounds/raw/master/Addons/BASS/basszxtune.dll", "basszxtune.dll");
            //    ErrorLogger.Log("ZXTune add-on has been enabled, yet file not found in game directory. Downloading...");
            //}

            AddonHandler.LoadAvailableAddons();
        }
    }
}