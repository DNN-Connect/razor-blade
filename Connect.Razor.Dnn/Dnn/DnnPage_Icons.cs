using System.Collections.Generic;
using Connect.Razor.Internals.HtmlPage;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage
    {
        /// <summary>
        /// Add an icon tag to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="rel"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public void AddIcon(string path, string rel = null, int size = Icon.SizeUndefined, string type = null) 
            => AddToHead(Icon.Generate(path, rel, size, type));

        /// <summary>
        /// Add a set of icons to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="favicon">Auto-generate a default favicon tag, which always points to the root. </param>
        /// <param name="rels"></param>
        /// <param name="sizes"></param>
        public void AddIconSet(string path, bool favicon = true, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            foreach (var s in Icon.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

        /// <summary>
        /// Add a set of icons to the page
        /// </summary>
        /// <param name="path">Path to the image/icon file</param>
        /// <param name="favicon">Auto-generate a default favicon tag, which always points to the root. </param>
        /// <param name="rels"></param>
        /// <param name="sizes"></param>
        public void AddIconSet(string path, string favicon = null, IEnumerable<string> rels = null, IEnumerable<int> sizes = null)
        {
            foreach (var s in Icon.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

    }
}