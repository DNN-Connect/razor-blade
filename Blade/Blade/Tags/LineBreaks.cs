using System.Text.RegularExpressions;

namespace Connect.Razor.Blade
{
    public static partial class Tags
    {

        /// <summary>
        /// Convert \n into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Nl2Br(string value) 
            => Text.Nl2X(value, "<br>");


        private static readonly Regex RelpacerBr = TagReplacer.Replacer("br");

        /// <summary>
        /// Convert <br> and <br/> into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Br2Nl(string value) 
            => RelpacerBr.Replace(value, "\n");

        /// <summary>
        /// Convert <br> and <br/> into line-breaks
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Br2Space(string value) 
            => RelpacerBr.Replace(value, " ");
    }
}
