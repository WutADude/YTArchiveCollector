using System.Diagnostics;
using System.IO.Compression;
using YTArchiveCollector.Modules;

namespace YTArchiveCollector.Helpers
{
    internal static class FileManager
    {
        internal static string? _SaveFolder { get; set; }
        internal static VideoParser? LastParsedVideo { get; set; }

        internal static bool FirstRunInDir => !Directory.Exists("Results");
        internal static bool FFMPEGisOK => File.Exists("ffmpeg.exe");
        internal static bool VideoSavePathContainsBothLines => File.Exists($"{_SaveFolder}\\Video\\VideoLine.{LastParsedVideo.VideoDownloadExtension}") && File.Exists($"{_SaveFolder}\\Video\\AudioLine.mp4");

        internal static void SaveData()
        {
            _SaveFolder = $"Results\\[{DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")}] Сборка";
            Directory.CreateDirectory(_SaveFolder);
            Directory.CreateDirectory($"{_SaveFolder}\\Preview");
            Loader.DownloadPreview(LastParsedVideo.ThumbnailURL);
            if (LastParsedVideo.VideoTags.Count > 0)
                File.WriteAllText($"{_SaveFolder}\\Tags.txt", string.Join(",", LastParsedVideo.VideoTags).TrimEnd(','));
            File.WriteAllText($"{_SaveFolder}\\Title.txt", LastParsedVideo.VideoTitle);
            File.WriteAllText($"{_SaveFolder}\\Description.txt", LastParsedVideo.VideoDescription);
            Process.Start("explorer.exe", _SaveFolder);
        }

        internal static void UnzipFFmpeg()
        {
            using (FileStream decompressedFileStream = File.Create("ffmpeg.exe"))
                using (GZipStream decompressionStream = new GZipStream(new MemoryStream(Properties.Resources.ffmpeg), CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedFileStream);
                }
        }
    }
}
