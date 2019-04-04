using System;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class ManualTags
    {
        [TestMethod]
        public void RealTags()
        {
            var text = "<div>";
            Assert.AreEqual(text, new Tag(text).ToString());
            text = "<div id='7'>text</div>";
            Assert.AreEqual(text, new Tag(text).ToString());
        }

        [TestMethod]
        public void Comment()
        {
            var text = "<!-- comment -->";
            Assert.AreEqual(text, new Tag(text).ToString());
        }

        [TestMethod]
        public void Text()
        {
            var text = "div";
            Assert.AreEqual(text, Tag.Text(text).ToString());
        }
    }

}
