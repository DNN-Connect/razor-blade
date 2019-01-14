namespace Connect.Razor.Internals
{
    internal class Truncator
    {
        internal static string SafeTruncate(string value, int length, bool treatEntitiesAsOneChar = true)
        {
            if (length < 1) return "";

            value = value.Trim();

            // Case 0 - length is so big, we can return everything
            if (value.Length <= length) return value;

            var realCharsToCount = treatEntitiesAsOneChar 
                ? FindCutLength(value, length) 
                : length;

            // case 1: whole result fits
            if (realCharsToCount >= value.Length)
                return value;

            // case 2: we made it exactly to the end of a word
            var lastChar = value[realCharsToCount - 1];
            var nextChar = value[realCharsToCount];
            var shortened = value.Substring(0, realCharsToCount);
            // case 3: we're in the middle of a word, go back a bit
            if (!(IsWordSplit(lastChar) || IsWordSplit(nextChar)))
                shortened = TrimUnfinishedWordAtEnd(shortened);

            // final trim
            return TrimNonWordCharsAtEnd(shortened);
        }

        private static string TrimUnfinishedWordAtEnd(string shortened)
        {
            // find the first word-separator going backwards
            for (var backTrack = shortened.Length - 1; backTrack > 0; backTrack--)
                if (backTrack > 0 && IsWordSplit(shortened[backTrack]))
                    return shortened.Substring(0, backTrack);

            return shortened;
        }

        private const string WordSplitters = ",-_'\"/\\"; // important: never add & or ;, as these are used in html-entities
        internal static bool IsWordSplit(char value)
        {
            var valString = value.ToString();
            return string.IsNullOrWhiteSpace(valString) || WordSplitters.Contains(valString);
        }

        internal static string TrimNonWordCharsAtEnd(string value)
        {
            // go from end of text, as long as we have word-split-chars, keep going
            // once we found a normal character, remove the end which contained word-splits only
            for (var i = value.Length - 1; i > 0; i--)
            {
                var charToCheck = value[i];
                if (IsWordSplit(charToCheck)) continue;

                // now we found a non-split character, return remaining stuff
                return value.Substring(0, i + 1);
            }
            return value;
        }


        internal static int FindCutLength(string value, int maxLength)
        {
            var realCharsToCount = 0;
            var maxIndex = value.Length;
            for (var i = 0; i < maxLength; i++)
            {
                // check if we're at the beginning of an html entity
                if (value[realCharsToCount] == '&' && realCharsToCount < maxIndex)
                {
                    // only check a few characters, as html-entities are never very long
                    var lastEntityEnd = realCharsToCount + 10;
                    if (lastEntityEnd > maxIndex)
                        lastEntityEnd = maxIndex;
                    for (var e = realCharsToCount + 1; e < lastEntityEnd; e++)
                    {
                        var character = value[e];
                        if (character == ';')
                        {
                            realCharsToCount = e;
                            break;
                        }
                        if (character == '#' || (character >= '0' && character <= '9') ||
                            (character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z')) continue;

                        // otherwise it's not an allowed entity-character, so ignore this completely
                        break;
                    }
                }

                realCharsToCount++;
                if (realCharsToCount < maxIndex) continue;
                realCharsToCount = maxIndex;
                break;
            }
            return realCharsToCount;
        }
    }
}
