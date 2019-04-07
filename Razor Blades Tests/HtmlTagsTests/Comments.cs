using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class Comments: TagTestBase
    {
        [TestMethod]
        public void Empty()
        {
            Is("<!--  -->", new Comment());
        }

        [TestMethod]
        public void WithNote()
        {
            Is("<!-- note -->", new Comment("note"));
        }

    }
}
