using System;
using System.Linq;
using System.Text;

namespace Connect.Razor.Json4Get
{
    /// <summary>
    /// Special converter which takes json and reformats it to better work in a 
    /// http-get call for the url. 
    /// Basically it converts very common characters like {, } and " into simpler characters
    /// ...and back.
    /// </summary>
    public static class Json4Get
    {
        /// <summary>
        /// Convert a JSON into a nicer GET capable format
        /// </summary>
        /// <param name="original"></param>
        /// <remarks>
        /// in will test for various bad inputs, but in general you should be sure to only throw real
        /// JSON at it.
        /// </remarks>
        /// <returns></returns>
        public static string Encode(string original)
        {
            #region First, do basic validity checking
            if (string.IsNullOrWhiteSpace(original)) return original;
            if (Characters.JsonStartMarkers.IndexOf(original[0]) == -1)
            {
                var firstNonWsChar = original.ToCharArray().FirstOrDefault(c => !char.IsWhiteSpace(c));
                if(Characters.JsonStartMarkers.IndexOf(firstNonWsChar) == -1 )
                    throw new Exception("Cannot encode json4get - first character does not seem to be a json starter");
            }
            #endregion

            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var previousCharacter = default(char);
            var openCloseCount = 0; // keep track of open/close cases, as in the end we should be back at zero
            foreach (var currentChar in original)
            {
                #region Case 1: We are not inside a value "value" yet, so check for {, } and "
                if (outsideOfQuotes)
                {
                    var index = Array.IndexOf(Characters.Specials, currentChar);
                    if (index == -1)
                        builder.Append(currentChar);
                    else
                    {
                        builder.Append(Characters.Replacements[index]);
                        openCloseCount += Characters.OpenCounters[index];
                        if (currentChar == Characters.QuoteOriginal)
                            outsideOfQuotes = false;
                    }
                }
                #endregion

                #region Case 2: we are inside a quoted "value", so don't replace {} but escape single '
                else
                {
                    if (currentChar == Characters.QuoteEncoded)
                        builder.Append(Characters.EscapePrefix).Append(currentChar);
                    else if (currentChar == Characters.QuoteOriginal && previousCharacter != Characters.EscapePrefix)
                    {
                        builder.Append(Characters.QuoteEncoded);
                        openCloseCount--;
                        outsideOfQuotes = true;
                    }
                    else
                        builder.Append(currentChar);
                }
                #endregion

                // remember this char, in case the next character-check needs to know it
                previousCharacter = currentChar;
            }

            #region final error-checking
            if(openCloseCount != 0)
                throw new Exception($"Cannot convert json4get, total opening / closing brackets and quotes don't match, got {openCloseCount}");
            #endregion

            return builder.ToString();
        }



        /// <summary>
        /// Decode Json4Get to JSON
        /// </summary>
        /// <param name="original"></param>
        /// <remarks>
        /// in will test for various bad inputs, but in general you should be sure to only throw real
        /// JSON4GET at it.
        /// </remarks>
        /// <returns></returns>
        public static string Decode(string original)
        {
            #region First, do basic validity checking
            if (string.IsNullOrWhiteSpace(original)) return original;
            if (Characters.Json4GetStartMarkers.IndexOf(original[0]) == -1)
            {
                var firstNonWsChar = original.ToCharArray().FirstOrDefault(c => !char.IsWhiteSpace(c));
                if (Characters.Json4GetStartMarkers.IndexOf(firstNonWsChar) == -1)
                    throw new Exception("Cannot encode json4get - first character does not seem to be a json starter");
            }
            #endregion

            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var previousCharacters = default(char);
            foreach (var currentChar in original)
            {
                #region Looking at chars outside a "value" so replace (, ) and '
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
                #endregion

                #region Looking at chars inside a "value" so leave () alone
                else
                {
                    if (currentChar != Characters.QuoteEncoded)
                        builder.Append(currentChar);
                    else if (previousCharacters == Characters.EscapePrefix)
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
                #endregion

                // remember the char for next checks...
                previousCharacters = currentChar;
            }
            return builder.ToString();
        }

    }
}
