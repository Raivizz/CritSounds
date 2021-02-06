using ManagedBass;
using System.IO;

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
                laa.Addon_AAC = Bass.PluginLoad("bass_aac.dll");
            }

            //FLAC
            if (File.Exists("bassflac.dll") & Config.BASSAddon_EnableFLACAddon)
            {
                laa.Addon_FLAC = Bass.PluginLoad("bassflac.dll");
            }

            //OPUS
            if (File.Exists("bassopus.dll") & Config.BASSAddon_EnableOPUSAddon)
            {
                laa.Addon_OPUS = Bass.PluginLoad("bassopus.dll");
            }

            //WMA
            if (File.Exists("basswma.dll") & Config.BASSAddon_EnableWMAAddon)
            {
                laa.Addon_WMA = Bass.PluginLoad("basswma.dll");
            }
        }

        public static void UnloadAddons()
        {
            CheckModSounds ua = new CheckModSounds();

            if (ua.Addon_AAC != 0)
            {
                Bass.PluginFree(ua.Addon_AAC);
            }

            //FLAC
            if (ua.Addon_FLAC != 0)
            {
                Bass.PluginFree(ua.Addon_FLAC);
            }

            //OPUS
            if (ua.Addon_OPUS != 0)
            {
                Bass.PluginFree(ua.Addon_OPUS);
            }

            //WMA
            if (ua.Addon_WMA != 0)
            {
                Bass.PluginFree(ua.Addon_WMA);
            }
        }
    }
}