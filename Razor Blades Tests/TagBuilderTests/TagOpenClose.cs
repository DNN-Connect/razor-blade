using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagBuilderTests
{
    [TestClass]
    public class TagOpenClose
    {
        [TestMethod]
        public void CloseSimpleTags()
        {
            Assert.AreEqual("</p>", new Tag("p").Close.ToString());
            Assert.AreEqual("</em>", new Tag("em").Close.ToString());
            Assert.AreEqual("</EM>", new Tag("EM").Close.ToString());
            Assert.AreEqual("</ng-template>", new Tag("ng-template").Close.ToString());
        }

        [TestMethod]
        public void OpenCloseEmptyTags()
        {
            Assert.AreEqual("", new Tag("").Close.ToString());
            Assert.AreEqual("", new Tag(" ").Close.ToString());
            Assert.AreEqual("", new Tag(null).Close.ToString());
            Assert.AreEqual("", new Tag("").Open.ToString());
            Assert.AreEqual("", new Tag(" ").Open.ToString());
            Assert.AreEqual("", new Tag(null).Open.ToString());
        }

        
    }
}
