using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect.Razor.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_HasText
    {

        [TestMethod]
        public void Test_HasText()
        {
            Assert.IsFalse(Text.Has(null), "null should be no text");
            Assert.IsFalse(Text.Has(""), "empty should be no text");
            Assert.IsFalse(Text.Has("   "), "spaces should be no text");
            Assert.IsFalse(Text.Has("			"), "tabs should be no text");
            Assert.IsTrue(Text.Has("xyz"), "text shouldn't be null or WS");
        }

        [TestMethod]
        public void Test_HasText_WithHtmlWhitespace()
        {
            Assert.IsFalse(Text.Has("&nbsp;"), "nbsp should be no text");
            Assert.IsFalse(Text.Has("&#160;"), "#160 should be no text");
            Assert.IsFalse(Text.Has("  &nbsp;&nbsp; "), "spaces with multiple whitespace should be no text");
            Assert.IsTrue(Text.Has("&nbsp;xyz"), "text shouldn't be null or WS");
        }

    }
}
