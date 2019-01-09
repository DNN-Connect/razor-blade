using Connect.Razor.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Connect.Razor.V1.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_HasText
    {

        [TestMethod]
        public void Test_HasText()
        {
            Assert.IsFalse(HasText(null), "null should be no text");
            Assert.IsFalse(HasText(""), "empty should be no text");
            Assert.IsFalse(HasText("   "), "spaces should be no text");
            Assert.IsFalse(HasText("			"), "tabs should be no text");
            Assert.IsTrue(HasText("xyz"), "text shouldn't be null or WS");
        }

        [TestMethod]
        public void Test_HasText_WithHtmlWhitespace()
        {
            Assert.IsFalse(HasText("&nbsp;"), "nbsp should be no text");
            Assert.IsFalse(HasText("&#160;"), "#160 should be no text");
            Assert.IsFalse(HasText("  &nbsp;&nbsp; "), "spaces with multiple whitespace should be no text");
            Assert.IsTrue(HasText("&nbsp;xyz"), "text shouldn't be null or WS");
        }

    }
}
