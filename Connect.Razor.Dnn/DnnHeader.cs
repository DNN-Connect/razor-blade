using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Connect.Razor.Interfaces;
using DotNetNuke.Framework;
using Page = System.Web.UI.Page;

namespace Connect.Razor.Dnn
{
    /// <summary>
    /// 
    /// </summary>
    // todo: object instantiate or what?
    public class DnnHeader :AbstractHeader, IPageHeader
    {
        public DnnHeader(DnnPage page)
        {
            Page = page.Page;
        }

        public void SetMetaAndTitle(string title, string titleFallback, string meta, string metaFallback)
        {
            var page = Page;
            if (page == null) return;
            meta = !string.IsNullOrEmpty(meta) ? meta : metaFallback;

            ((CDefault)page).Description = meta;
            var metaTag = (HtmlMeta)page.FindControl("metaDescription");
            metaTag.Visible = true;
            metaTag.Content = HttpUtility.HtmlAttributeEncode(meta);

            Title = !string.IsNullOrEmpty(title) ? title : titleFallback;
        }

        public override void AddHeader(string tag)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tag)) return;
                var control = new LiteralControl(tag);
                Page?.Header.Controls.Add(control);
            }
            catch {  /* ignore */ }
        }

        public override string Description
        {
            get => ((CDefault) Page)?.Description;
            set
            {
                if (Page is CDefault cdpage) cdpage.Description = value;
                EnsureFieldVisibleAndSetValueAgain("metaDescription", value);
            }
        }

        public override string Keywords
        {
            get => ((CDefault)Page)?.KeyWords;
            set
            {
                if (Page is CDefault cdpage) cdpage.Description = value;
                EnsureFieldVisibleAndSetValueAgain("metaKeywords", value);
            }
        }


        private void EnsureFieldVisibleAndSetValueAgain(string id, string value)
        {
            if (!(Page?.FindControl(id) is HtmlMeta metaTag)) return;
            metaTag.Visible = true;
            // todo: 2rm check why we are doing this - feels like we're setting things 2x
            metaTag.Content = AttributeEncode(value);
        }


        protected override string AttributeEncode(string original) => HttpUtility.HtmlAttributeEncode(original);

        internal readonly Page Page;

        public override string Title
        {
            get => Page?.Title;
            set
            {
                if (Page != null) Page.Title = value;
            }
        }
    }
}