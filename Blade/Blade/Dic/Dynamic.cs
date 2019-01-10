using System.Collections.Generic;
using System.Dynamic;

namespace Connect.Razor.Blade
{
    public static partial class Dic
    {
        // helper method
        public static dynamic ToDynamic(IDictionary<string, object> dict)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in dict)
                expando.Add(item);
            return expando;
        }


    }
}
