using System.Collections.Generic;
using Connect.Razor.Blade.Html5;
using Connect.Razor.Internals;
using Connect.Razor.Blade.HtmlTags;

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
        {
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);
            AddToHead(new Icon(path, rel, size, type));
        }

        /// <inheritdoc />
        public void AddIconSet(string path,
            string doNotRelyOnParameterOrder = EnforceNamedParameters.ProtectionKey,
            bool favicon = true, 
            IEnumerable<string> rels = null, 
            IEnumerable<int> sizes = null
            )
        {
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);
            foreach (var s in Internals.HtmlPage.IconSet.GenerateIconSet(path, favicon, rels, sizes))
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
            EnforceNamedParameters.VerifyProtectionKey(doNotRelyOnParameterOrder);
            foreach (var s in Internals.HtmlPage.IconSet.GenerateIconSet(path, favicon, rels, sizes))
                AddToHead(s);
        }

    }
}