using System.Text.RegularExpressions;

namespace Connect.Razor.Blade
{
    public static partial class Tags
    {
        public static Regex Replacer(string names, bool open = true, bool close = true)
        {
            if (names.IndexOf(',') > -1)
                names = "[" + names.Replace(',', '|') + "]";
            const string closeOptional = "[/]?";
            const string closeRequired = "/";
            var closer = open ? (close ? closeOptional : "") : (close ? closeRequired : "");
            return new Regex("<" + closer + names + "[^>]*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }

        /// <summary>
        /// Convert \n into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Nl2Br(string value) 
            => Text.Nl2X(value, "<br>");


        private static readonly Regex Br = Replacer("br");

        /// <summary>
        /// Convert <br> and <br/> into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Br2Nl(string value) 
            => Br.Replace(value, "\n");

        /// <summary>
        /// Convert <br> and <br/> into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Br2Space(string value) 
            => Br.Replace(value, " ");
    }
}
