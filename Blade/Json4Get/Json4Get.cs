using System;
using System.Text;

namespace Connect.Razor.Json4Get
{
    public static class Json4Get
    {
        public static char[] EncodeCharsOutside = {'{', '}', '"'};
        public static char[] EncodeReplacements = { '(', ')', '\'' };
        public const char EncodeCharInside = '\'';
        public const string EncodeInsideReplacement = "''";
        public const char EncodingSwitchModes = '"';
        public const char EncodingSwitchBack = '\'';
        public const char EncodingEscapeChar = '\\';


        public static string Encode(string original)
        {
            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var prevChar = ' ';
            foreach (var currentChar in original)
            {
                if (outsideOfQuotes)
                {
                    var index = Array.IndexOf(EncodeCharsOutside, currentChar);
                    if (index == -1)
                        builder.Append(currentChar);
                    else
                    {
                        builder.Append(EncodeReplacements[index]);
                        if (currentChar == EncodingSwitchModes)
                            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                            outsideOfQuotes = !outsideOfQuotes;
                    }
                }
                else
                {
                    if (currentChar == EncodeCharInside)
                        builder.Append(EncodeInsideReplacement);
                    else if (currentChar == EncodingSwitchModes && prevChar != EncodingEscapeChar)
                    {
                        builder.Append(EncodingSwitchBack);
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        outsideOfQuotes = !outsideOfQuotes;
                    }
                    else
                        builder.Append(currentChar);
                }
                prevChar = currentChar;
            }
            return builder.ToString();
        }

        public static string Decode(string original)
        {
            var builder = new StringBuilder();
            var outsideOfQuotes = true;
            var prevChar = ' ';
            foreach (var currentChar in original)
            {
                if (outsideOfQuotes)
                {
                    var index = Array.IndexOf(EncodeReplacements, currentChar);
                    if (index == -1)
                        builder.Append(currentChar);
                    else
                    {
                        builder.Append(EncodeCharsOutside[index]);
                        if (currentChar == EncodingSwitchBack)
                            outsideOfQuotes = !outsideOfQuotes;
                    }
                }
                else
                {
                    
                }
                prevChar = currentChar;
            }
            return builder.ToString();
        }
    }
}
