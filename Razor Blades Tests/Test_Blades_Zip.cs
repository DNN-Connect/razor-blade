using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect.Razor.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_Zip
    {

        [TestMethod]
        public void Test_Zip_Basic()
        {
            var message = "This is a   teaser for something";
            var expected = "This is a teaser for something";
            Assert.AreEqual(expected, Text.Zip(message), "multiple spaces must go");
        }
        
        [TestMethod]
        public void Test_Zip_NewLine()
        {
            var message = "This is a \n  teaser\n for something";
            var expected = "This is a teaser for something";
            Assert.AreEqual(expected, Text.Zip(message), "multiple spaces must go");
        }

    }
}
