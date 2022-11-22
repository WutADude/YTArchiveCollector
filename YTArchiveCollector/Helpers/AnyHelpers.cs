namespace YTArchiveCollector.Helpers
{
    internal static class AnyHelpers
    {
        internal static bool IsYTUrl(this string InputString) => RegexPatterns._YTLongURLRegex.IsMatch(InputString) || RegexPatterns._YTShortURLRegex.IsMatch(InputString);
    }
}
