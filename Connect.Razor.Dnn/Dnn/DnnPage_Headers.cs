using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Connect.Razor.Blade;
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

        public void AddMeta(string name, string content) =>
            AddToHead(TagBuilder.Tag("meta", attributes: new Dictionary<string, string>
            {
                {"name", name},
                {"content", content}
            }, options: new TagOptions {SelfClose = true}));

        // wip: convert to tagbuilder and test
        public void AddOpenGraph(string property, string content) =>
            AddToHead(TagBuilder.Tag("meta", attributes: new Dictionary<string, string>
            {
                {"property", property},
                {"content", content}
            }, options: new TagOptions { SelfClose = true }));

        //=> AddToHead($"<meta property='{property}' content='{Tags.Encode(content)}' /> ");

        public void AddJsonLd(string jsonString) =>
            AddToHead(TagBuilder.Tag("script", attributes: new Dictionary<string, string>
            {
                {"type", "application/ld+json"},
            }, content: jsonString));

        //=> AddToHead($"<script type='application/ld+json'>{jsonString}</script>");

        public void AddJsonLd(object jsonObject) 
            => AddJsonLd(Html.ToJsonOrErrorMessage(jsonObject));

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