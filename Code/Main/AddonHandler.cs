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
        }

        public static void UnloadAddons()
        {
            CheckModSounds ua = new CheckModSounds();

            if (ua.Addon_AAC != 0)
            {
                Bass.BASS_PluginFree(ua.Addon_AAC);
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
        }
    }
}