using System.Text;
using System.Text.RegularExpressions;

namespace Seldino.Infrastructure.Helpers
{
    public static class UrlSlugHelper
    {
        public static string GenerateSlug(this string phrase, int maxLength = 100)
        {
            var str = phrase.RemoveAccent().ToLower().Replace("#", "sharp").Replace("+", "plus").Replace("&", "and");
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
