using Connect.Razor.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Connect.Razor.V1.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_String
    {

        [TestMethod]
        public void Test_Ellipsis()
        {
            var message = "This is a teaser for something";
            Assert.AreEqual(Ellipsis(message, 100), message, "message is short, shouldn't change");
            Assert.AreNotEqual(Ellipsis(message, 5), message, "message is longer, should be truncated");
            Assert.AreEqual(Ellipsis(message, 5, ""), "This ", "blank ellipsis char should just trunc");
            Assert.AreEqual(Ellipsis(message, 5).Length, 5 + BladeDefaults.HtmlEllipsisCharacter.Length, "should trunc and add ell");
        }
    }
}
