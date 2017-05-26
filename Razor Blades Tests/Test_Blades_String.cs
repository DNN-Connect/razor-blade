using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Connect.Razor.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_String
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
        public void Test_Fallback()
        {
            var val1Ok = "value 1";
            string val1Null = null;
            string val1Empty = "";
            string val1spaces = "   ";
            string fallback = "fallback!";

            Assert.AreEqual(Fallback(val1Ok, fallback), val1Ok, "should be same");
            Assert.AreEqual(Fallback(val1Null, fallback), fallback, "should be fallback");
            Assert.AreEqual(Fallback(val1Empty, fallback), fallback, "should be fallback");
            Assert.AreEqual(Fallback(val1spaces, fallback), fallback, "should be fallback");

            Assert.AreEqual(Fallback(val1Empty, val1spaces, val1Null, fallback, val1Ok), fallback, "should be fallback");
        }

        [TestMethod]
        public void Test_Ellipsis()
        {
            var message = "This is a teaser for something";
            Assert.AreEqual(Ellipsis(message, 100), message, "message is short, shouldn't change");
            Assert.AreNotEqual(Ellipsis(message, 5), message, "message is longer, should be truncated");
            Assert.AreEqual(Ellipsis(message, 5, ""), "This ", "blank ellipsis char should just trunc");
            Assert.AreEqual(Ellipsis(message, 5).Length, 5 + Connect.Razor.BladeDefaults.EllipsisChar.Length, "should trunc and add ell");
        }
    }
}
