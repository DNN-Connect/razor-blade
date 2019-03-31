using System.Collections.Generic;
using Connect.Razor.Internals;
using Connect.Razor.Internals.HtmlPage;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage
    {
        /// <inheritdoc />
        public void AddIcon(string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string rel = null, 
            int size = Icon.SizeUndefined, 
            string type = null) 
            => AddToHead(Icon.Generate(path, rel, size, type));

        /// <inheritdoc />
        public void AddIconSet(string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            bool favicon = true, 
            IEnumerable<string> rels = null, 
            IEnumerable<int> sizes = null
            )
        {
            foreach (var s in Icon.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

        /// <inheritdoc />
        public void AddIconSet(string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            string favicon = null, 
            IEnumerable<string> rels = null, 
            IEnumerable<int> sizes = null
            )
        {
            foreach (var s in Icon.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

    }
}