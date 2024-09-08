using System.Globalization;

namespace GTBubblerMod.Extensions
{
    internal static class StringEx
    {
        private static readonly TextInfo EnglishUS = new CultureInfo("en-US", false).TextInfo;

        public static string ToTitleCase(this string str)
        {
            return EnglishUS.ToTitleCase(str);
        }
    }
}
