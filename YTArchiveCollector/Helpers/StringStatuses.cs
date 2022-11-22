namespace YTArchiveCollector.Helpers
{
    internal static class StringStatuses
    {
        internal const string IDLEStatus = "ожидаю задачи (～￣▽￣)～";
        internal const string InfoGetingStatus = "получаю информацию о видео ༼ つ ◕_◕ ༽つ";
        internal const string InfoShowStatus = "вывожу полученную информацию （￣︶￣）↗";
        internal const string SuccesVideoLoadStatus = "видео успешно загружено ( •̀ ω •́ )";
        internal static string VideoLoadStatus(int LoadPercentage) => $"загрузка видео {LoadPercentage}% (°ー°〃)";
    }
}
