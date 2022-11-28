namespace YTArchiveCollector.Helpers
{
    internal static class StringStatuses
    {
        internal const string SomethingWrongWithFFMPEG = "что-то не так с FFMPEG, где же он? ＼(〇_ｏ)／";
        internal const string IDLEStatus = "ожидаю задачи (～￣▽￣)～";
        internal const string InfoGetingStatus = "получаю информацию о видео ༼ つ ◕_◕ ༽つ";
        internal const string VideoIsStreamStatus = "обрабатывать стримы я не собираюсь (눈_눈)";
        internal const string InfoShowStatus = "вывожу полученную информацию （￣︶￣）↗";
        internal const string SuccesVideoAndAudioLoadStatus = "видео и аудио успешно загружены ( •̀ ω •́ )";
        internal const string VideoUniqueizationStatus = "склеиваю дорожки и уникализирую видео (〃＞＿＜;〃)";
        internal const string VideoUniqueizationIsSuccessStatus = "видео успешно склеено с аудиодорожкой и уникализированно ＼(￣▽￣)／";
        internal static string VideoAndAudioLoadStatus(int VideoLoadPercentage, int AudioLoadPercentage) => $"загрузка видео {VideoLoadPercentage}% (°ー°〃) | загрузка аудио {AudioLoadPercentage}% (°ー°〃)";
        internal static string VideoLoadStatusWhenAudioDone(int VideoLoadPercentage) => $"загрузка видео {VideoLoadPercentage}% (°ー°〃) | <(^_^<) аудио успешно загружено";
        internal static string AudioLoadStatusWhenVideoDone(int AudioLoadPercentage) => $"видео успешно загружено (>^_^)> | загрузка видео {AudioLoadPercentage}% (°ー°〃)";
    }
}
