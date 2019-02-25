using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Connect.Razor.Dnn
{
    public partial class DnnPage 
    {
        public void AddHeader(string tag)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tag)) return;
                var control = new LiteralControl(tag);
                Page?.Header.Controls.Add(control);
            }
            catch {  /* ignore */ }
        }

        public void AddMeta(string name, string content)
            => AddHeader($"<meta name=\'{name}\' content=\'{Attribute(content)}\' /> ");

        public void AddOpenGraph(string property, string content)
            => AddHeader($"<meta property=\'{property}\' content=\'{Attribute(content)}\' /> ");


        private void EnsureFieldVisibleAndSetValueAgain(string id, string value)
        {
            if (!(Page?.FindControl(id) is HtmlMeta metaTag)) return;
            metaTag.Visible = true;
            // todo: 2rm check why we are doing this - feels like we're setting things 2x
            metaTag.Content = Attribute(value);
        }

    }
}