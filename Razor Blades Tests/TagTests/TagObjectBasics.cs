using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagObjectBasics
    {
        [TestMethod]
        public void VeryBasic()
        {
            Assert.AreEqual("<div></div>", new Tag("div").ToString());
            Assert.AreEqual("<strong></strong>", new Tag{TagName = "strong"}.ToString());
            Assert.AreEqual("<strong>...</strong>", new Tag { TagName = "strong", TagContents = "..."}.ToString());
        }
    }
}
