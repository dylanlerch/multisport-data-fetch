using System.Text.RegularExpressions;

namespace MultisportDataFetch
{
    public static class Extensions {
        private static readonly Regex nonSpaceWhitespace = new(@"([^\S ]|&nbsp;)+", RegexOptions.Compiled);
        public static string CleanWhitespace(this string input) 
        {
            return nonSpaceWhitespace.Replace(input, "");
        }
    }
}
