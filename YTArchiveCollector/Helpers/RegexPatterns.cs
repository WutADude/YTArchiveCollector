using System.Text.RegularExpressions;

namespace YTArchiveCollector.Helpers
{
    internal static class RegexPatterns
    {
        #region["URL validation patterns"]
        internal static Regex _YTLongURLRegex = new Regex("(https://www\\.youtube\\.com/watch\\?v=[a-zA-Z0-9-+_]{11})", RegexOptions.Compiled);
        internal static Regex _YTShortURLRegex = new Regex("(https://youtu\\.be/[a-zA-Z0-9-_+]{11})", RegexOptions.Compiled);
        #endregion

        #region["HTML document parsing patterns"]
        internal static Regex _YTScriptToJSONRegex = new Regex("ytInitialPlayerResponse.=.({[\\s\\S]+});", RegexOptions.Compiled); // Group 1
        #endregion
    }
}
