using System.Web.UI;
using System.Web.UI.HtmlControls;
using Connect.Razor.Blade.HtmlTags;
using Connect.Razor.Internals;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage 
    {

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

        public void AddToHead(Tag tag) => AddToHead(tag.ToString());

        public void AddMeta(string name, string content) =>
            AddToHead(new Meta(name, content));

        public void AddOpenGraph(string property, string content) =>
            AddToHead(new MetaOg(property, content));

        public void AddJsonLd(string jsonString) 
            => AddToHead(new ScriptJsonLd(jsonString));

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