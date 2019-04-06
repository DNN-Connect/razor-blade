using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.Text
{
    [TestClass]
    public class Test_Blades_FirstText
    {
        protected string val1Ok = "value 1";
        protected string val1Null = null;
        protected string val1Empty = "";
        protected string val1spaces = "   ";
        protected string val1Nbsp = "&nbsp;";
        protected string fallback = "fallback!";

        [TestMethod]
        public void Test_FirstText2Params()
        {
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, fallback), val1Ok, "should be first");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, val1Null), val1Ok, "should be first");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, val1Nbsp), val1Ok, "should be first");

            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, fallback), fallback, "should be fallback");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Empty, fallback), fallback, "should be fallback");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1spaces, fallback), fallback, "should be fallback");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Nbsp, fallback), fallback, "should be fallback");
        }

        [TestMethod]
        public void Test_FirstText2ParamsHtmlWhitespace()
        {
            // html-whitespace checks
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Nbsp, fallback, true), fallback, "should be fallback");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Nbsp, fallback, false), val1Nbsp, "should be nbsp");
        }


        [TestMethod]
        public void Test_FirstText3Params()
        {
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, val1Null, fallback), val1Ok, "should be first");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Ok, val1Null), val1Ok, "should be second");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok), val1Ok, "should be third");

            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok, false), val1Nbsp, "should be nbsp");
        }

        [TestMethod]
        public void Test_FirstText4Params()
        {
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, val1Null, val1Null, fallback), val1Ok, "should be first");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Ok, val1Null, fallback), val1Ok, "should be second");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok, fallback), val1Ok, "should be third");

            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok, fallback, false), val1Nbsp, "should be nbsp");
        }

        [TestMethod]
        public void Test_FirstText5Params()
        {
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Ok, val1Null, val1Null, val1Null, fallback), val1Ok, "should be first");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Ok, val1Null, val1Null, fallback), val1Ok, "should be second");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok, val1Null, fallback), val1Ok, "should be third");
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Null, val1Null, fallback), fallback, "should be last");

            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Null, val1Nbsp, val1Ok, fallback, val1Ok, false), val1Nbsp, "should be nbsp");
        }

        [TestMethod]
        public void Test_FirstText()
        {
            Assert.AreEqual(Connect.Razor.Blade.Text.First(val1Empty, val1spaces, val1Null, fallback, val1Ok), fallback, "should be fallback");
        }

   }
}
