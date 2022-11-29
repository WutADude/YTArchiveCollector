using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using YTArchiveCollector.Helpers;

namespace YTArchiveCollector.Modules
{
    internal static class Loader
    {
        internal static MainForm _Form { get; set; } // Form reference for controls access

        private static int VideoLoadPercentage, AudioLoadPercentage; // Counters for statuses

        internal static void StartDownloading()
        {
            _Form.MainLabel.Enabled = false;
            VideoLoadPercentage = 0;
            AudioLoadPercentage = 0;
            Parallel.Invoke(
                () => DownloadVideo(),
                () => DownloadAudio());
        }

        #region["Download methods"]
        private static void DownloadVideo()
        {
            using (WebClient VideoLoader = new WebClient())
            {
                VideoLoader.DownloadFileCompleted += VideoLoader_DownloadFileCompleted;
                VideoLoader.DownloadProgressChanged += VideoLoader_DownloadProgressChanged;
                VideoLoader.DownloadFileAsync(new Uri(FileManager.LastParsedVideo.VideoDownloadURL), $"{FileManager._SaveFolder}\\Video\\VideoLine.{FileManager.LastParsedVideo.VideoDownloadExtension}");
            }
        }

        private static void DownloadAudio()
        {
            using (WebClient AudioLoader = new WebClient())
            {
                AudioLoader.DownloadFileCompleted += AudioLoader_DownloadFileCompleted;
                AudioLoader.DownloadProgressChanged += AudioLoader_DownloadProgessChanged;
                AudioLoader.DownloadFileAsync(new Uri(FileManager.LastParsedVideo.AudioDownloadURL), $"{FileManager._SaveFolder}\\Video\\AudioLine.mp4");
            }
        }

        internal static void DownloadPreview(string DownloadURL) => ImageUniquealizer.UniquealizePreviewAndSave(new WebClient().DownloadData(DownloadURL));
        #endregion

        #region["Download progress"]
        private static void AudioLoader_DownloadProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            AudioLoadPercentage = e.ProgressPercentage;
            if (VideoLoadPercentage != 100)
                _Form.ChangeSoftStatusLabel(StringStatuses.VideoAndAudioLoadStatus(VideoLoadPercentage, AudioLoadPercentage));
            else
                _Form.ChangeSoftStatusLabel(StringStatuses.AudioLoadStatusWhenVideoDone(AudioLoadPercentage));
        }

        private static void VideoLoader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            VideoLoadPercentage = e.ProgressPercentage;
            if (AudioLoadPercentage != 100)
                _Form.ChangeSoftStatusLabel(StringStatuses.VideoAndAudioLoadStatus(VideoLoadPercentage, AudioLoadPercentage));
            else
                _Form.ChangeSoftStatusLabel(StringStatuses.VideoLoadStatusWhenAudioDone(VideoLoadPercentage));
        }
        #endregion

        #region["Download completed"]
        private static void AudioLoader_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            if (VideoLoadPercentage == 100)
                AllLoadedEvents();
        }

        private static void VideoLoader_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (AudioLoadPercentage == 100)
                AllLoadedEvents();
        }

        private static void AllLoadedEvents() // Event when all downloaded successfuly 
        {
            _Form.DownloadVideoButton.Text = "Видео загружено!";
            _Form.ChangeSoftStatusLabel(StringStatuses.SuccesVideoAndAudioLoadStatus);
            if (FileManager.FFMPEGisOK)
                new Task(delegate () { VideoUniquealizer.MergeAudioAndVideoAndUniqueize(); }).Start();
            else
                _Form.ChangeSoftStatusLabel(StringStatuses.SomethingWrongWithFFMPEG);
        }
        #endregion


    }
}
