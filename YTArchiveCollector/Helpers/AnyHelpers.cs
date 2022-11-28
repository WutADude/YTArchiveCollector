namespace YTArchiveCollector.Helpers
{
    internal static class AnyHelpers
    {
        internal static bool IsYTUrl(this string InputString) => RegexPatterns._YTLongURLRegex.IsMatch(InputString) || RegexPatterns._YTShortURLRegex.IsMatch(InputString);
        internal static int GetTotalyRandomNumber(int min, int max)
        {
            Thread.Sleep(1); // Без этого у всех Random будет один seed, что приведёт к одному результату.
            return new Random().Next(min, max);
        }
        internal static Color GetRandomColor => Color.FromArgb(GetTotalyRandomNumber(0, 255), GetTotalyRandomNumber(0, 255), GetTotalyRandomNumber(0, 255));
    }
}
