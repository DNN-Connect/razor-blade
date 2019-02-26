using System.Web;
using Connect.Razor.Interfaces;
using Page = System.Web.UI.Page;

namespace Connect.Razor.Dnn
{
    public partial class DnnHtmlPage : IHtmlPage
    {
        public DnnHtmlPage()
        {
            // load the page from the context
            // will be null if not available
            Page = HttpContext.Current?.Handler as Page;
        }

        /// <summary>
        /// Get the current page object. Will return null if not available. 
        /// Important: will not throw an error if it can't find it, to prevent issues when the template
        /// is being run in a test environment or in indexing mode.         
        /// </summary>
        public Page Page { get; set; }


        protected string Attribute(string original) => HttpUtility.HtmlAttributeEncode(original);
    }
}