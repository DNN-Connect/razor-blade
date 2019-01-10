using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Connect.Razor.Blade
{
    public static partial class Dic
    {

        public static string SafeGet<T1>(this IDictionary<T1, string> options, T1 original, string fallback = null)
        {
            return options.ContainsKey(original)
                ? options[original]
                : fallback;// ?? string.Empty;
        }
    }
}
