using System.Collections.Generic;
using Connect.Razor.Internals.HtmlPage;

namespace Connect.Razor.Dnn
{
    // goal: add these headers easily and quickly
    //<link rel = 'icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'shortcut icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'apple-touch-icon' type='image/png' href='/[dein-assets-pfad]/favicon/favicon500.png'>
    //<link rel = 'icon' type='image/x-icon' href='/favicon.ico'>


    public partial class DnnHtmlPage
    {
        public void AddIcon(string path, string rel = null, int size = Icon.SizeUndefined, string type = null) 
            => AddToHead(Icon.Generate(path, rel, size, type));

        public void AddIconSet(string path, bool favicon = true, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            foreach (var s in Icon.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

    }
}