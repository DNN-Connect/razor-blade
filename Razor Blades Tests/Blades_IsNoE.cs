using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Connect.Razor.Blades;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Blades_IsNoE
    {
        //[TestMethod]
        //public void Test_IsNoE()
        //{
        //    string x = null;
        //    Assert.IsTrue(IsNoE(x), "null should be empty");
        //    Assert.IsTrue(IsNoE(""), "empty string should be empty");
        //    Assert.IsFalse(IsNoE(" "), "space shouldn't be empty");
        //    Assert.IsFalse(IsNoE("xyz"), "text shouldn't be empty");

        //    // objects tests
        //    object z = null;
        //    Assert.IsTrue(IsNoE(z), "null object should be true");

        //    string y = null;
        //    object stringWithStrangeType = y;
        //    Assert.IsTrue(IsNoE(y), "null-string should work too");

        //}



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

        }
    }
}
