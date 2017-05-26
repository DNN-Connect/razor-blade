using System.Collections.Generic;

namespace Connect.Razor
{
    public static partial class Blade
    {

        public static string If(bool condition, string result, string otherwise = null)
        {
            return condition ? result : otherwise ?? string.Empty;
        }


        public static string Switch<T>(T original, IDictionary<T, string> options, string fallback = null)
        {
            return options.ContainsKey(original)
                ? options[original]
                : fallback ?? string.Empty;
        }
    }
}
