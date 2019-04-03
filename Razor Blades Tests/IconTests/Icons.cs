using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.IconTests
{
    [TestClass]
    public class Icons
    {
        [TestMethod]
        public void BasicIco()
        {
            var expected =
                $"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["ico"]}' href='/favicon.ico'>";
            var result = new Icon("/favicon.ico").ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CustomType()
        {
            var someDummyType = "image/xyz";
            Assert.AreEqual($"<link rel='{Icon.DefaultRelationship}' type='{someDummyType}' href='/favicon.ico'>", 
                new Icon("/favicon.ico", type:someDummyType).ToString());
        }

        [TestMethod]
        public void BasicPng()
        {
            Assert.AreEqual($"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>", 
               new Icon("/path/icon.png").ToString());
        }

        [TestMethod]
        public void CustomRel()
        {
            var customRel = "xyz";
            Assert.AreEqual($"<link rel='{customRel}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>",
                new Icon("/path/icon.png", rel: customRel).ToString());
        }

    }
}
