using System.Web.UI;
using System.Web.UI.HtmlControls;
using Connect.Razor.Blade;
using Connect.Razor.Blade.Html5;
using Connect.Razor.Internals;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage 
    {
        /// <summary>
        /// Add a string to the header
        /// </summary>
        /// <param name="tag"></param>
        public void AddToHead(string tag)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tag)) return;
                var control = new LiteralControl(tag);
                Page?.Header.Controls.Add(control);
            }
            catch {  /* ignore */ }
        }

        /// <summary>
        /// Add a tag to the header
        /// </summary>
        /// <param name="tag"></param>
        public void AddToHead(Tag tag) => AddToHead(tag?.ToString());

        /// <summary>
        /// Generate and add a meta-tag
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public void AddMeta(string name, string content) =>
            AddToHead(new Meta(name, content));

        /// <summary>
        /// Generate and add an open-graph header
        /// </summary>
        /// <param name="property"></param>
        /// <param name="content"></param>
        public void AddOpenGraph(string property, string content) =>
            AddToHead(new MetaOg(property, content));

        /// <summary>
        /// Generate and add a json-ld header
        /// </summary>
        /// <param name="jsonString"></param>
        public void AddJsonLd(string jsonString) 
            => AddToHead(new ScriptJsonLd(jsonString));

        /// <summary>
        /// Generate and add a json-ld header, by serializing an object
        /// </summary>
        /// <param name="jsonObject"></param>
        public void AddJsonLd(object jsonObject) 
            => AddToHead(new ScriptJsonLd(jsonObject));

        private void EnsureFieldVisibleAndSetValueAgain(string id, string value)
        {
            if (!(Page?.FindControl(id) is HtmlMeta metaTag)) return;
            metaTag.Visible = true;

            // this seems like a patch around some DNN bugs (probably specific versions)
            // I would leave it for now
            metaTag.Content = Html.Encode(value);
        }



    }
}