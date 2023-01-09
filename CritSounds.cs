using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using ManagedBass;
using Terraria.ModLoader;
using Terraria.ModLoader.Exceptions;
using System.Diagnostics;

namespace CritSounds;

// A HTTP Client Utils extension that simplifies file downloading.
// Taken from https://stackoverflow.com/a/66270371
public static class HttpClientUtils
{
    public static async Task DownloadFileTaskAsync(this HttpClient client, Uri uri, string FileName)
    {
        await using var s = await client.GetStreamAsync(uri);
        await using var fs = new FileStream(FileName, FileMode.CreateNew);
        await s.CopyToAsync(fs);
    }
}

internal class CritSounds : Mod
{
    //SHA256 hash
    private const string Sha256BassWin64 = "94ff6f6d935292b6664779b06ddd6a63db274c962dc15e18723f9a46c5529d4f";
    private const string BassPath = "dotnet/6.0.0/bass.dll";
    private readonly Uri bassWin64Uri = new("https://github.com/Raivizz/CritSounds/blob/1.4_port/lib_external/x64/bass.dll");
    private readonly Uri bassLinuxScriptUri = new("https://github.com/Raivizz/CritSounds/blob/1.4_port/lib_external/linux_fetch.sh");

    private readonly SHA256 _sha256 = SHA256.Create();

    protected CritSounds()
    {
        CritModdingDirectories cs = new();
        cs.CreateDirectories();
    }

    //Hash calculation stuff
    private IEnumerable<byte> GetHashSha256(string filename)
    {
        using var stream = File.OpenRead(filename);
        return _sha256.ComputeHash(stream);
    }

    private async void FetchFile(Uri uri, string fileName)
    {
        HttpClient client = new();
        try
        {
            await client.DownloadFileTaskAsync(uri, fileName);
        }
        catch (HttpRequestException e)
        {
            Logger.Error("Fetching DLL failed:" + e.Message);
        }
    }

    private static string BytesToString(IEnumerable<byte> bytes)
    {
        return bytes.Aggregate("", (current, b) => current + b.ToString("x2"));
    }

    public override void Load()
    {
        var TasksBASS = new List<Task>();

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        {
            StreamType.CritSfxHandler csh = new();

            csh.CheckDirectoriesForMods();

            //If bass.dll exists, checks for the file hash and re-downloads it if the hash check fails.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (File.Exists(BassPath))
                {
                    if (BytesToString(GetHashSha256(BassPath)) == Sha256BassWin64)
                    {
                        Logger.Info("bass.dll hash code matches");
                        Bass.Init();
                    }
                    else
                    {
                        Logger.Info("bass.dll does not match hash, re-downloading...");
                        File.Delete(BassPath);
                    }
                }
                //If bass.dll was not found, asynchronously downloads it and initializes it. Otherwise returns exception.
                else
                {
                    TasksBASS.Add(Task.Run(() => FetchFile(bassWin64Uri, BassPath)));

                    var t = Task.WhenAny(TasksBASS);
                    try
                    {
                        t.Wait();
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e);
                    }

                    switch (t.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            Logger.Info("BASS library has been downloaded succesfully.");

                            //Puts the thread to sleep for 1000 ms because for whatever reason it refuses to acknowledge the existence of the library file.
                            //Could be due to IO? Might have to investigate.
                            //Why this fixes it, I do not know. hashtag slav jank, amirite.
                            Thread.Sleep(1000);

                            Bass.Init();
                            break;
                        case TaskStatus.Faulted:
                            throw new Exception("BASS library has failed to download. Please check your Internet connection and try again.");
                    }
                }
            }
        }
            //Fetches a Bash script that downloads required BASS libraries.
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return;
            if (!File.Exists("/usr/lib/libbass.so"))
            {
                TasksBASS.Add(Task.Run(() => FetchFile(bassLinuxScriptUri, "script.sh")));

                var t = Task.WhenAny(TasksBASS);
                try
                {
                    t.Wait();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }

                switch (t.Status)
                {
                    case TaskStatus.RanToCompletion:
                        Process bassScript = new();
                        Logger.Info("BASS script has been downloaded succesfully. Running...");

                        bassScript.StartInfo.FileName = @"script.sh";
                        bassScript.Start();
                        bassScript.WaitForExit();

                        Bass.Init();
                        break;
                    case TaskStatus.Faulted:
                        throw new Exception(
                            "BASS script for Linux has failed to download. Please check your Internet connection and try again.");
                }
            }
            else Bass.Init();
    }

    public override void Unload()
    {
        Bass.Free();
    }
}