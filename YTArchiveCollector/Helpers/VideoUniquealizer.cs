using System.Diagnostics;
using YTArchiveCollector.Modules;

namespace YTArchiveCollector.Helpers
{
    internal static class VideoUniquealizer
    {
        internal static bool IsUniqueiazingProcessHappening;
        internal static void MergeAudioAndVideo()
        {
            Loader._Form.ChangeSoftStatusLabel(StringStatuses.VideoUniqueizationStatus);
            IsUniqueiazingProcessHappening = true;
            string FolderPath = $"{FileManager._SaveFolder}\\Video";
            string Args = $"/C ffmpeg -i \"{FolderPath}\\VideoLine.{FileManager.LastParsedVideo.VideoDownloadExtension}\" -i \"{FolderPath}\\AudioLine.mp4\" -vf noise=alls=1:allf=t -vf colortemperature={AnyHelpers.GetTotalyRandomNumber(16000, 19500)} -vf vibrance=-0.7 -fflags +bitexact -flags:v +bitexact -flags:a +bitexact -pix_fmt yuv420p -shortest \"{FolderPath}\\UniqueVideo.mp4\"";
            Process.Start(new ProcessStartInfo()
            {
                CreateNoWindow = true,
                FileName = "cmd.exe",
                Arguments = Args,
            })?.WaitForExit();
            File.Delete($"{FolderPath}\\VideoLine.{FileManager.LastParsedVideo.VideoDownloadExtension}");
            File.Delete($"{FolderPath}\\AudioLine.mp4");
            IsUniqueiazingProcessHappening = false;
            Loader._Form.ChangeSoftStatusLabel(StringStatuses.VideoUniqueizationIsSuccessStatus);
            Process.Start("explorer.exe", $"{FileManager._SaveFolder}\\Video");
            Loader._Form.MainLabel.Enabled = true;
        }
    }
}
