using Connect.Razor.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagBuilderCloseTests
    {
        [TestMethod]
        public void CloseSimpleTags()
        {
            Assert.AreEqual("</p>", TagBuilder.Close("p"));
            Assert.AreEqual("</em>", TagBuilder.Close("em"));
            Assert.AreEqual("</EM>", TagBuilder.Close("EM"));
            Assert.AreEqual("</ng-template>", TagBuilder.Close("ng-template"));
        }

        [TestMethod]
        public void OpenCloseEmptyTags()
        {
            Assert.AreEqual("", TagBuilder.Close(""));
            Assert.AreEqual("", TagBuilder.Close(" "));
            Assert.AreEqual("", TagBuilder.Close(null));
            Assert.AreEqual("", TagBuilder.Open(""));
            Assert.AreEqual("", TagBuilder.Open(" "));
            Assert.AreEqual("", TagBuilder.Open(null));
        }

        
    }
}
