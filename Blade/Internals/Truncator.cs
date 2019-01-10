namespace Connect.Razor.Internals
{
    internal class Truncator
    {
        internal static string SafeTruncate(string value, int length, bool treatEntitiesAsOneChar = true)
        {
            if (length < 1) return "";

            value = value.Trim();

            if (value.Length <= length) return value;

            var realCharsToCount = treatEntitiesAsOneChar 
                ? FindCutPosition(value, length) 
                : length;

            // case 1: whole result fits
            if (realCharsToCount >= value.Length)
                return value;

            // case 2: we made it exactly to the end of a word
            var lastChar = value[realCharsToCount - 1].ToString();
            var nextChar = value[realCharsToCount].ToString();
            var shortened = value.Substring(0, realCharsToCount);
            if (!(string.IsNullOrWhiteSpace(lastChar) || string.IsNullOrWhiteSpace(nextChar)))
            {
                // case 3: we're in the middle of a word, go back a bit
                var prevSpace = shortened.LastIndexOf(' ');

                // if there was a space on the way back, cut off there
                if (prevSpace > 0)
                    shortened = shortened.Substring(0, prevSpace + 1);
            }

            // final trim
            return shortened.Trim();
        }


        internal static int FindCutPosition(string value, int maxChars)
        {
            var realCharsToCount = 0;
            var maxIndex = value.Length - 1;
            for (var i = 0; i < maxChars; i++)
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
