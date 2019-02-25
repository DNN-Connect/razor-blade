using DotNetNuke.Framework;

namespace Connect.Razor.Dnn
{
    public partial class DnnPage 
    {
        public string Description
        {
            get => ((CDefault)Page)?.Description;
            set
            {
                if (Page is CDefault cdpage) cdpage.Description = value;
                EnsureFieldVisibleAndSetValueAgain("metaDescription", value);
            }
        }

        public string Keywords
        {
            get => ((CDefault)Page)?.KeyWords;
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