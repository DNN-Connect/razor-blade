using System;
using System.Text;

namespace Connect.Razor.Json4Get
{
    public static class Json4Get
    {
        public static char[] EncodeCharsOutside = {'{', '}', '"'};
        public static char[] EncodeReplacements = { '(', ')', '\'' };
        public const char EncodeCharInside = '\'';
        //public const string EncodeInsideReplacement = "\\'";
        public const char QuotesOriginal = '"';
        public const char QuotesEncoded = '\'';
        public const char EscapeChar = '\\';


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
                        if (currentChar == QuotesOriginal)
                            outsideOfQuotes = false;
                    }
                }
                else
                {
                    if (currentChar == EncodeCharInside)
                        builder.Append(EscapeChar).Append(currentChar);
                    else if (currentChar == QuotesOriginal && prevChar != EscapeChar)
                    {
                        builder.Append(QuotesEncoded);
                        outsideOfQuotes = true;
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
                        if (currentChar == QuotesEncoded)
                            outsideOfQuotes = false;
                    }
                }
                else
                {
                    if (currentChar != QuotesEncoded)
                        builder.Append(currentChar);
                    else if (prevChar == EscapeChar)
                    {
                        builder.Length--; // remove the previous escaping char
                        builder.Append(currentChar);
                    }
                    else
                    {
                        builder.Append(QuotesOriginal);
                        outsideOfQuotes = true;
                    }
                }
                prevChar = currentChar;
            }
            return builder.ToString();
        }
    }
}
