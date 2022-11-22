using System.Diagnostics;
using YTArchiveCollector.Modules;

namespace YTArchiveCollector.Helpers
{
    internal static class FileManager
    {
        internal static string? _SaveFolder { get; set; }
        internal static string? LastVideoLoadURL { get; set; }
        internal static string? LastVideoLoadExtension { get; set; }

        internal static bool FirstRunInDir => Directory.Exists("Results");

        internal static void SaveData(VideoParser Video)
        {
            _SaveFolder = $"Results\\[{DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")}] Сборка";
            LastVideoLoadExtension = Video.VideoDownloadExtension;
            LastVideoLoadURL = Video.VideoDownloadURL;
            Directory.CreateDirectory(_SaveFolder);
            Directory.CreateDirectory($"{_SaveFolder}\\Preview");
            VideoLoader.DownloadPreview(Video.ThumbnailURL, $"{_SaveFolder}\\Preview");
            if (Video.VideoTags.Count > 0)
                File.WriteAllText($"{_SaveFolder}\\Tags.txt", string.Join(",", Video.VideoTags).TrimEnd(','));
            File.WriteAllText($"{_SaveFolder}\\Title.txt", Video.VideoTitle);
            File.WriteAllText($"{_SaveFolder}\\Description.txt", Video.VideoDescription);
            Process.Start("explorer.exe", _SaveFolder);
        }
    }
}
