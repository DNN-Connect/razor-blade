using Connect.Razor.Internals.HtmlPage;
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
            var result = Icon.Generate("/favicon.ico");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CustomType()
        {
            var someDummyType = "image/xyz";
            Assert.AreEqual($"<link rel='{Icon.DefaultRelationship}' type='{someDummyType}' href='/favicon.ico'>", 
                Icon.Generate("/favicon.ico", type:someDummyType));
        }

        [TestMethod]
        public void BasicPng()
        {
            Assert.AreEqual($"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>", 
                Icon.Generate("/path/icon.png"));
        }

        [TestMethod]
        public void CustomRel()
        {
            var customRel = "xyz";
            Assert.AreEqual($"<link rel='{customRel}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>",
                Icon.Generate("/path/icon.png", rel: customRel));
        }

    }
}
