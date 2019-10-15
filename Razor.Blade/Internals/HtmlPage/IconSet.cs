using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade.Html5;

namespace Connect.Razor.Internals.HtmlPage
{
    internal class IconSet
    {
        internal static readonly string[] IconSetDefaultRelationships = {
            Icon.RelIcon,
            Icon.RelShortcut,
            Icon.RelApple,
        };

        internal static List<Icon> GenerateIconSet(string path, object favicon = null, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            // if no sizes given, just assume the default size only
            sizes = sizes ?? new[] { Icon.SizeUndefined };

            // if no rels are given, use default list
            var relList = (rels ?? IconSetDefaultRelationships).ToList();

            // generate the icons
            var result = relList.SelectMany(relationship => sizes,
                    (relationship, size) => new Icon(path, relationship, size))
                .ToList();

            // if we need a favicon, add it as well
            switch (favicon)
            {
                case null:
                    result.Add(new Icon(path, Icon.RelShortcut));
                    break;
                case bool favBool when favBool:
                    result.Add(new Icon(Icon.RootFavicon, Icon.RelShortcut));
                    break;
                case string favString when !string.IsNullOrEmpty(favString):
                    result.Add(new Icon(favString, Icon.RelShortcut));
                    break;
            }
            return result;
        }
        
    }
}
