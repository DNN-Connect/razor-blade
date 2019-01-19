using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Connect.Razor.Json4Get
{
    /// <summary>
    /// Compress a JSON removing structural white-space and shrinking common values 
    /// like true, false, null
    /// </summary>
    internal class JsonCompressor
    {
        public static readonly string StructureAbbreviations = " tfn";
        public static readonly string[] StructureToAbbreviate = { "\\s+", "true", "false", "null" };

        private static readonly Tuple<Regex, string>[] Compressors = StructureToAbbreviate.Select((s, i) =>
                new Tuple<Regex, string>(BuildOutsideOfWs(s), StructureAbbreviations[i].ToString().Trim()))
            .ToArray();

        private static readonly Tuple<Regex, string>[] DeCompressors = StructureToAbbreviate.Select((s, i) =>
                new Tuple<Regex, string>(BuildOutsideOfWs(StructureAbbreviations[i].ToString()), s))
            .ToArray();


        /// <summary>
        /// Convert a JSON into compact form
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string Compress(string json) 
            => Compressors.Aggregate(json, (current, t) => t.Item1.Replace(current, t.Item2));

        /// <summary>
        /// Restore a compact character to the uncompressed value, or return a null if not found
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string RestoreOrNull(char code)
        {
            var index = StructureAbbreviations.IndexOf(code);
            return index == -1 ? null : StructureToAbbreviate[index];
        }

        public static string Decompress(string json)
            => DeCompressors.Aggregate(json, (current, t) => t.Item1.Replace(current, t.Item2));


        /// <summary>
        /// Build a regex that searches for something outside of quotes "..." and also ignoring inner quotes \"
        /// </summary>
        /// <remarks>
        /// inspiration https://stackoverflow.com/questions/9577930/regular-expression-to-select-all-whitespace-that-isnt-in-quotes
        /// </remarks>
        /// <param name="searching"></param>
        /// <returns></returns>
        private static Regex BuildOutsideOfWs(string searching) 
            => new Regex(searching + "(?=((\\\\[\\\\\"]|[^\\\\\"])*\"(\\\\[\\\\\"]|[^\\\\\"])*\")*(\\\\[\\\\\"]|[^\\\\\"])*$)",
            RegexOptions.Multiline);
    }
}
