using YTArchiveCollector.Helpers;

namespace YTArchiveCollector.Modules
{
    internal class VideoParser : JsonManager
    {
        internal VideoParser(string VideoURL) => GetJsonFromDocument(RequestsManager.GetVideoHtmlDocument(VideoURL));

        internal string? OwnerChannelName { get => GetVideoOwner; }
        internal string? VideoTitle { get => GetVideoTitle; }
        internal string? VideoDescription { get => GetVideoDescription; }
        internal List<string>? VideoTags { get => GetVideoTags; }
        internal string? ThumbnailURL { get => GetThumbnailURL; }
        internal string? VideoDownloadURL { get => GetVideoDownloadURL; }
        internal string? VideoDownloadMaxQuality { get => GetVideoDownloadMaxQuality; }
        internal int? VideoDownloadFPS { get => GetVideoDownloadFPS; }
        internal string? VideoDownloadExtension { get => GetVideoDownloadExtension; }
        internal string? VideoViewsCount { get => GetViewsCount; }

    }
}
