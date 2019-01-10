using System.Collections.Generic;

namespace Connect.Razor.Blade
{
    internal static partial class Dic
    {

        public static string SafeGet<T1>(this IDictionary<T1, string> options, T1 original, string fallback = null)
        {
            return options.ContainsKey(original)
                ? options[original]
                : fallback;// ?? string.Empty;
        }
    }
}
