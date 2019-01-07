namespace Seldino.CrossCutting.Web.Routings
{
    public class RegularExpressionConstants
    {
        public const string Numeric = @"\d+";

        public const string EnglishAlphabet = @"([a-zA-Z]+)";

        public const string PersianAlphanumeric = @"([\u0627-\u0648\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\s-]+)";

        public const string EnglishAndPersianAlphanumeric = @"([a-zA-Z0-9\u0627-\u0648\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\s-]+)";
    }

}
