using System;
using System.Linq;
using System.Text;

namespace Connect.Razor.Json4Get
{
    public static class Json4Get
    {
        public static string Encode(string original)
        {
            #region First, do basic validity checking
            if (string.IsNullOrWhiteSpace(original)) return original;
            if (Array.IndexOf(Characters.JsonStartMarkers, original[0]) == -1)
            {
                var firstNonWsChar = original.ToCharArray().FirstOrDefault(c => !char.IsWhiteSpace(c));
                if(Array.IndexOf(Characters.JsonStartMarkers, firstNonWsChar) == -1 )
                    throw new Exception("Cannot encode json4get - first character does not seem to be a json starter");
            }
            #endregion

            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var prevChar = default(char);
            var wrapperCount = 0; // keep track of open/close cases, as in the end we should be back at zero
            foreach (var currentChar in original)
            {
                if (outsideOfQuotes)
                {
                    var index = Array.IndexOf(Characters.Specials, currentChar);
                    if (index == -1)
                        builder.Append(currentChar);
                    else
                    {
                        builder.Append(Characters.Replacements[index]);
                        wrapperCount += Characters.OpenCounters[index];
                        if (currentChar == Characters.QuoteOriginal)
                            outsideOfQuotes = false;
                    }
                }
                else
                {
                    if (currentChar == Characters.QuoteEncoded)
                        builder.Append(Characters.EscapePrefix).Append(currentChar);
                    else if (currentChar == Characters.QuoteOriginal && prevChar != Characters.EscapePrefix)
                    {
                        builder.Append(Characters.QuoteEncoded);
                        wrapperCount--;
                        outsideOfQuotes = true;
                    }
                    else
                        builder.Append(currentChar);
                }
                prevChar = currentChar;
            }

            if(wrapperCount != 0)
                throw new Exception($"Cannot convert json4get, total opening / closing brackets and quotes don't match, got {wrapperCount}");

            return builder.ToString();
        }



        /// <summary>
        /// Decode Json4Get to JSON
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string Decode(string original)
        {
            #region First, do basic validity checking
            if (string.IsNullOrWhiteSpace(original)) return original;
            if (Array.IndexOf(Characters.Json4GetStartMarkers, original[0]) == -1)
            {
                var firstNonWsChar = original.ToCharArray().FirstOrDefault(c => !char.IsWhiteSpace(c));
                if (Array.IndexOf(Characters.Json4GetStartMarkers, firstNonWsChar) == -1)
                    throw new Exception("Cannot encode json4get - first character does not seem to be a json starter");
            }
            #endregion

            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var prevChar = ' ';
            foreach (var currentChar in original)
            {
                if (outsideOfQuotes)
                {
                    var index = Array.IndexOf(Characters.Replacements, currentChar);
                    if (index == -1)
                        builder.Append(currentChar);
                    else
                    {
                        builder.Append(Characters.Specials[index]);
                        if (currentChar == Characters.QuoteEncoded)
                            outsideOfQuotes = false;
                    }
                }
                else
                {
                    if (currentChar != Characters.QuoteEncoded)
                        builder.Append(currentChar);
                    else if (prevChar == Characters.EscapePrefix)
                    {
                        builder.Length--; // remove the previous escaping char
                        builder.Append(currentChar);
                    }
                    else
                    {
                        builder.Append(Characters.QuoteOriginal);
                        outsideOfQuotes = true;
                    }
                }
                prevChar = currentChar;
            }
            return builder.ToString();
        }

    }
}
