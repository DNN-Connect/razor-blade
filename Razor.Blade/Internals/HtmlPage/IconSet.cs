using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Blade.Html5;

namespace Connect.Razor.Internals.HtmlPage
{
    internal class IconSet
    {
        internal static readonly string[] IconSetDefaultRelationships = {
            Icon.Relationship,
            Icon.AppleRelationship,
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
                case bool favBool when favBool:
                    result.Add(new Icon(Icon.RootFavicon, Icon.ShortcutRelationship));
                    break;
                case string favString when !string.IsNullOrEmpty(favString):
                    result.Add(new Icon(favString, Icon.ShortcutRelationship));
                    break;
            }
            return result;
        }
        
    }
}
