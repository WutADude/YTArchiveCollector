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
        protected string? GetVideoOwner => _JsonToParse?.GetProperty("microformat").GetProperty("playerMicroformatRenderer").GetProperty("ownerChannelName").GetString();
        protected string? GetVideoTitle => _JsonToParse?.GetProperty("videoDetails").GetProperty("title").GetString();
        protected string? GetVideoDescription => _JsonToParse?.GetProperty("microformat").GetProperty("playerMicroformatRenderer").GetProperty("description").GetProperty("simpleText").GetString();
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

        #region["Video download data"]
        private JsonElement? VideoDownloadElement => _JsonToParse?.GetProperty("streamingData").GetProperty("formats").EnumerateArray().Last();
        protected string? GetVideoDownloadURL => VideoDownloadElement.Value.GetProperty("url").GetString();
        protected string? GetVideoDownloadMaxQuality => VideoDownloadElement.Value.GetProperty("qualityLabel").GetString();
        protected int? GetVideoDownloadFPS => VideoDownloadElement.Value.GetProperty("fps").GetInt32();
        protected string? GetVideoDownloadExtension => VideoDownloadElement.Value.GetProperty("mimeType").GetString()?.Split(";")[0].Replace("video/", "");
        #endregion
    }
}
