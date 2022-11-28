using System.Text.Json;

namespace YTArchiveCollector.Helpers
{
    internal class JsonManager
    {
        private static JsonElement? _JsonToParse { get; set; }

        protected void GetJsonFromDocument(string Document)
        {
            HtmlAgilityPack.HtmlDocument DocToParse = new HtmlAgilityPack.HtmlDocument();
            DocToParse.LoadHtml(Document);
            _JsonToParse = JsonDocument.Parse(RegexPatterns._YTScriptToJSONRegex.Match(DocToParse.DocumentNode.SelectSingleNode("/html/body/script[1]").InnerText).Groups[1].Value).RootElement;
        }

        #region["Video data"]
        protected bool? GetVideoIsStream
        {
            get
            {
                JsonElement IsLiveProperty;
                return (bool)_JsonToParse.Value.GetProperty("videoDetails").TryGetProperty("isLive", out IsLiveProperty);
            }
        }
        protected string? GetVideoOwner => _JsonToParse?.GetProperty("microformat").GetProperty("playerMicroformatRenderer").GetProperty("ownerChannelName").GetString();
        protected string? GetVideoTitle => _JsonToParse?.GetProperty("videoDetails").GetProperty("title").GetString();
        protected string? GetVideoDescription
        {
            get
            {
                JsonElement VideoDescriptionKey;
                if (!(bool)_JsonToParse?.GetProperty("microformat").GetProperty("playerMicroformatRenderer").TryGetProperty("description", out VideoDescriptionKey))
                    return string.Empty;
                return _JsonToParse?.GetProperty("microformat").GetProperty("playerMicroformatRenderer").GetProperty("description").GetProperty("simpleText").GetString();
            }
        }
        protected string? GetViewsCount => _JsonToParse?.GetProperty("videoDetails").GetProperty("viewCount").GetString();
        protected string? GetThumbnailURL => _JsonToParse?.GetProperty("videoDetails").GetProperty("thumbnail").GetProperty("thumbnails").EnumerateArray().Last().GetProperty("url").GetString();
        protected List<string>? GetVideoTags
        {
            get
            {
                JsonElement TagsProperty;
                if (!(bool)_JsonToParse?.GetProperty("videoDetails").TryGetProperty("keywords", out TagsProperty)) // Проверяю наличие ключа в JSON
                    return new List<string>();
                List<string> Tags = new List<string>();
                _JsonToParse?.GetProperty("videoDetails").GetProperty("keywords").EnumerateArray().ToList().ForEach(e => Tags.Add(e.GetString()));
                return Tags;
            }
        }
        #endregion

        #region["Formats data"]
        private JsonElement.ArrayEnumerator? VideoFormatsElement
        {
            get
            {
                JsonElement StreamingDataElement;
                if (!(bool)_JsonToParse.Value.TryGetProperty("streamingData", out StreamingDataElement))
                    return null;
                return StreamingDataElement.GetProperty("adaptiveFormats").EnumerateArray();
            }
        }
        #endregion

        #region["Video download data"]
        private JsonElement? VideoToLoadElement => VideoFormatsElement.Value.First();
        protected string? GetVideoDownloadURL
        {
            get
            {
                JsonElement VideoDownloadURLKey;
                if (VideoFormatsElement == null || !(bool)VideoToLoadElement.Value.TryGetProperty("url", out VideoDownloadURLKey))
                    return string.Empty;
                return VideoDownloadURLKey.GetString();
            }
        }
        protected string? GetVideoDownloadMaxQuality => VideoFormatsElement != null ? VideoToLoadElement.Value.GetProperty("qualityLabel").GetString() : String.Empty;
        protected int? GetVideoDownloadFPS => VideoFormatsElement != null ? VideoToLoadElement.Value.GetProperty("fps").GetInt32() : 0;
        protected string? GetVideoDownloadExtension => VideoFormatsElement != null ? VideoToLoadElement.Value.GetProperty("mimeType").GetString()?.Split(";")[0].Replace("video/", "") : String.Empty;
        #endregion

        #region["Audio download data"]
        private JsonElement? AudioToLoadElement => VideoFormatsElement.Value.First(e => e.GetProperty("mimeType").GetString().Contains("audio/mp4"));
        protected string? GetAudioDownloadURL
        {
            get
            {
                JsonElement AudioDownloadURLKey;
                if (AudioToLoadElement == null || !(bool)AudioToLoadElement.Value.TryGetProperty("url", out AudioDownloadURLKey))
                    return string.Empty;
                return AudioDownloadURLKey.GetString();
            }
        }
        protected string? GetAudioDownloadQuality => AudioToLoadElement != null ? AudioToLoadElement.Value.GetProperty("quality").GetString() : string.Empty;
        #endregion
    }
}
