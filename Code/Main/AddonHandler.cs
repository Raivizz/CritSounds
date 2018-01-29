using System;
using System.Net;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Un4seen.Bass;

namespace CritSounds
{
    public static class AddonHandler
    {
        public static void LoadAvailableAddons()
        {
            CheckModSounds laa = new CheckModSounds();

            //AAC
            if ((File.Exists("bass_aac.dll")) & (Config.BASSAddon_EnableAACAddon))
            {
                laa.Addon_AAC = Bass.BASS_PluginLoad("bass_aac.dll");
            }

            //AC3
            if (File.Exists("bass_ac3.dll") & Config.BASSAddon_EnableAC3Addon)
            {
                laa.Addon_AC3 = Bass.BASS_PluginLoad("bass_ac3.dll");
            }

            //ADX
            if (File.Exists("bass_adx.dll") & Config.BASSAddon_EnableADXAddon)
            {
                laa.Addon_ADX = Bass.BASS_PluginLoad("bass_adx.dll");
            }

            //AIX
            if (File.Exists("bass_aix.dll") & Config.BASSAddon_EnableAIXAddon)
            {
                laa.Addon_AIX = Bass.BASS_PluginLoad("bass_aix.dll");
            }

            //APE
            if (File.Exists("bass_ape.dll") & Config.BASSAddon_EnableAPEAddon)
            {
                laa.Addon_APE = Bass.BASS_PluginLoad("bass_ape.dll");
            }

            //MPC
            if (File.Exists("bass_mpc.dll") & Config.BASSAddon_EnableMPCAddon)
            {
                laa.Addon_MPC = Bass.BASS_PluginLoad("bass_mpc.dll");
            }

            //SPX
            if (File.Exists("bass_spx.dll") & Config.BASSAddon_EnableSPXAddon)
            {
                laa.Addon_SPX = Bass.BASS_PluginLoad("bass_spx.dll");
            }

            //TTA
            if (File.Exists("bass_tta.dll") & Config.BASSAddon_EnableTTAAddon)
            {
                laa.Addon_TTA = Bass.BASS_PluginLoad("bass_tta.dll");
            }

            //FLAC
            if (File.Exists("bassflac.dll") & Config.BASSAddon_EnableFLACAddon)
            {
                laa.Addon_FLAC = Bass.BASS_PluginLoad("bassflac.dll");
            }

            //OPUS
            if (File.Exists("bassopus.dll") & Config.BASSAddon_EnableOPUSAddon)
            {
                laa.Addon_OPUS = Bass.BASS_PluginLoad("bassopus.dll");
            }

            //WMA
            if (File.Exists("basswma.dll") & Config.BASSAddon_EnableWMAAddon)
            {
                laa.Addon_WMA = Bass.BASS_PluginLoad("basswma.dll");
            }

            //WV
            if (File.Exists("basswv.dll") & Config.BASSAddon_EnableWVAddon)
            {
                laa.Addon_WV = Bass.BASS_PluginLoad("basswv.dll");
            }

            //ZXTune
            //if (File.Exists("basszxtune.dll") & Config.BASSAddon_EnableZXTuneAddon)
            //{
            //    laa.Addon_ZXTUNE = Bass.BASS_PluginLoad("basszxtune.dll");
            //}
        }

        public static void UnloadAddons()
        {
            CheckModSounds ua = new CheckModSounds();

            if (ua.Addon_AAC != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_AAC);
            }

            //AC3
            if (ua.Addon_AC3 != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_AC3);
            }

            //ADX
            if (ua.Addon_ADX != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_ADX);
            }

            //AIX
            if (ua.Addon_AIX != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_AIX);
            }

            //APE
            if (ua.Addon_APE != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_APE);
            }

            //MPC
            if (ua.Addon_MPC != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_MPC);
            }

            //SPX
            if (ua.Addon_SPX != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_SPX);
            }

            //TTA
            if (ua.Addon_TTA != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_TTA);
            }

            //FLAC
            if (ua.Addon_FLAC != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_FLAC);
            }

            //OPUS
            if (ua.Addon_OPUS != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_OPUS);
            }

            //WMA
            if (ua.Addon_WMA != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_WMA);
            }

            //WV
            if (ua.Addon_WV != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_WV);
            }

            //ZXTune
            //if (ua.Addon_ZXTUNE != 0)
            //{
            //    Bass.BASS_PluginFree(ua.Addon_ZXTUNE);
            //}
        }
    }
}