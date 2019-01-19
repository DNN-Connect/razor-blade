﻿using System;
using System.Text;
using System.Text.RegularExpressions;

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
            VerifyStartingCharIsValid(ref original, Characters.JsonStartMarkers);
            #endregion

            original = original.RemoveUnquotedWhitespace().ShortenTrueFalseNull();
            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var previousCharacter = default(char);
            var openCloseCount = 0; // keep track of open/close cases, as in the end we should be back at zero
            foreach (var currentChar in original)
            {
                #region Case 1: We are not inside a value "value" yet, so check for {, } and "
                if (outsideOfQuotes)
                {
                    var index = Characters.Specials.IndexOf(currentChar);
                    if (index != -1)
                    {
                        builder.Append(Characters.Replacements[index]);
                        openCloseCount += Characters.OpenCounters[index];
                        if (currentChar == Characters.QuoteOriginal)
                            outsideOfQuotes = false;
                    }
                    else builder.Append(currentChar);
                }
                #endregion

                #region Case 2: we are inside a quoted "value", so don't replace {} but escape single '
                else
                {
                    if (currentChar == Characters.QuoteEncoded || currentChar == Characters.SpaceReplacement)
                        builder.Append(Characters.EscapePrefix).Append(currentChar);
                    else if (currentChar == Characters.Space)
                        builder.Append(Characters.SpaceReplacement);
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

        private static void VerifyStartingCharIsValid(ref string original, string allowedFirstChars)
        {
            foreach (var character in original)
            {
                // found allowed / expected character, ok
                if (allowedFirstChars.IndexOf(character) >= 0) return;
                
                // whitespace, keep testing
                if (char.IsWhiteSpace(character)) continue;

                // none of the above, throw
                throw new Exception("Cannot encode json4get - first character does not seem to be a json starter");
            }
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
            VerifyStartingCharIsValid(ref original, Characters.Json4GetStartMarkers);
            #endregion

            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var previousCharacters = default(char);
            foreach (var currentChar in original)
            {
                #region Looking at chars outside a "value" so replace (, ) and '

                if (outsideOfQuotes)
                {
                    var index = Characters.Replacements.IndexOf(currentChar);
                    if (index != -1)
                    {
                        builder.Append(Characters.Specials[index]);
                        if (currentChar == Characters.QuoteEncoded)
                            outsideOfQuotes = false;
                    }
                    else
                    {
                        var abbrIndex = Characters.StructureAbbreviations.IndexOf(currentChar);
                        if (abbrIndex != -1)
                            builder.Append(Characters.StructureToAbbreviate[abbrIndex]);
                        else
                            builder.Append(currentChar);
                    }
                }

                #endregion

                #region Looking at chars inside a "value" so leave () alone
                else switch (currentChar)
                    {
                        case Characters.SpaceReplacement:
                            if (previousCharacters == Characters.EscapePrefix)
                                builder.ReplaceLast(currentChar);
                            else
                                builder.Append(Characters.Space);
                            break;
                        case Characters.QuoteEncoded:
                            if (previousCharacters == Characters.EscapePrefix)
                                builder.ReplaceLast(currentChar);
                            else
                            {
                                builder.Append(Characters.QuoteOriginal);
                                outsideOfQuotes = true;
                            }
                            break;
                        default:
                            builder.Append(currentChar);
                            break;
                    }

                #endregion

                // remember the char for next checks...
                previousCharacters = currentChar;
            }
            return builder.ToString();
        }

    }

    public static class Helpers
    {
        #region Extension Methods for StringBuilder
        public static void ReplaceLast(this StringBuilder builder, char replacement)
        {
            builder.Length--;
            builder.Append(replacement);
        }
        #endregion

        #region Extension Methods for String

        private static readonly Regex WsOutsideOfQuotes = BuildOutsideOfWs("\\s+");
            //new Regex("\\s+(?=((\\\\[\\\\\"]|[^\\\\\"])*\"(\\\\[\\\\\"]|[^\\\\\"])*\")*(\\\\[\\\\\"]|[^\\\\\"])*$)", 
            //RegexOptions.Multiline);
        public static string RemoveUnquotedWhitespace(this string original) 
            => WsOutsideOfQuotes.Replace(original, "");

        public static string ShortenTrueFalseNull(this string original)
        {
            var result = TrueOutsideOfQuotes.Replace(original, "t");
            result = FalseOutsideOfQuotes.Replace(result, "f");
            result = NullOutsideOfQuotes.Replace(result, "n");
            return result;
        }

        // from https://stackoverflow.com/questions/9577930/regular-expression-to-select-all-whitespace-that-isnt-in-quotes
        private static readonly Regex TrueOutsideOfQuotes = BuildOutsideOfWs("true");
        private static readonly Regex FalseOutsideOfQuotes = BuildOutsideOfWs("false");
        private static readonly Regex NullOutsideOfQuotes = BuildOutsideOfWs("null");

        /// <summary>
        /// Build a regex that searches for something outside of quotes "..." and also ignoring inner quotes \"
        /// </summary>
        /// <remarks>
        /// inspiration https://stackoverflow.com/questions/9577930/regular-expression-to-select-all-whitespace-that-isnt-in-quotes
        /// </remarks>
        /// <param name="searching"></param>
        /// <returns></returns>
        private static Regex BuildOutsideOfWs(string searching)
        {
            return new Regex(searching + "(?=((\\\\[\\\\\"]|[^\\\\\"])*\"(\\\\[\\\\\"]|[^\\\\\"])*\")*(\\\\[\\\\\"]|[^\\\\\"])*$)",
                RegexOptions.Multiline);
        }
        #endregion
    }

}