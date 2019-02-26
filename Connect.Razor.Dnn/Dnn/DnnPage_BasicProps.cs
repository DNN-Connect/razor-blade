using DotNetNuke.Framework;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage 
    {
        public string Description
        {
            get => (Page as CDefault)?.Description;
            set
            {
                if (Page is CDefault cdpage) cdpage.Description = value;
                EnsureFieldVisibleAndSetValueAgain("metaDescription", value);
            }
        }

        public string Keywords
        {
            get => (Page as CDefault)?.KeyWords;
            set
            {
                if (Page is CDefault cdpage) cdpage.Description = value;
                EnsureFieldVisibleAndSetValueAgain("metaKeywords", value);
            }
        }

        public string Title
        {
            get => Page?.Title;
            set
            {
                if (Page != null) Page.Title = value;
            }
        }
    }
}