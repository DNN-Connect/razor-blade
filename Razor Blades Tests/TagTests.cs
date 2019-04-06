using System.Web;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests
{
    public class TagTestBase

    {
        public void Is(string expected, Tag result, string message = null)
        {
            Assert.AreEqual(expected, result.ToString(), message);
        }

        public void Is(string expected, IHtmlString result, string message = null)
        {
            Assert.AreEqual(expected, result.ToString(), message);
        }
    }
}
