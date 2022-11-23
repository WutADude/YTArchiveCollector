using System.Diagnostics;
using System.Net;
using YTArchiveCollector.Helpers;

namespace YTArchiveCollector.Modules
{
    internal static class VideoLoader
    {
        internal static MainForm _Form { get; set; }
        internal static void DownloadVideo(string DownloadURL, string SaveFolder, string Extension)
        {
            using (WebClient WC = new WebClient())
            {
                WC.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC.DownloadProgressChanged += WC_DownloadProgressChanged;
                WC.DownloadFileAsync(new Uri(DownloadURL), $"{SaveFolder}\\Video.{Extension}");
            }
        }

        private static void WC_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _Form.DownloadVideoButton.Text = "Видео загружено!";
            _Form.ChangeSoftStatusLabel(StringStatuses.SuccesVideoLoadStatus);
            Process.Start("explorer.exe", $"{FileManager._SaveFolder}\\Video");
        }

        private static void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => _Form.ChangeSoftStatusLabel(StringStatuses.VideoLoadStatus(e.ProgressPercentage));

        internal static void DownloadPreview(string DownloadURL, string SaveFolder) => new WebClient().DownloadFile(DownloadURL, $"{SaveFolder}\\Preview.jpg");
    }
}
