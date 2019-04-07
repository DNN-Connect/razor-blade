using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests.IconTests
{
    [TestClass]
    public class Icons: TagTestBase
    {
        [TestMethod]
        public void BasicIco()
        {
            var expected =
                $"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["ico"]}' href='/favicon.ico'>";
            var result = new Icon("/favicon.ico");
            Is(expected, result);
        }


        [TestMethod]
        public void CustomType()
        {
            var someDummyType = "image/xyz";
            Is($"<link rel='{Icon.DefaultRelationship}' type='{someDummyType}' href='/favicon.ico'>", 
                new Icon("/favicon.ico", type:someDummyType));
        }

        [TestMethod]
        public void CustomTypeFluent()
        {
            var someDummyType = "image/xyz";
            Is($"<link rel='{Icon.DefaultRelationship}' type='{someDummyType}' href='/favicon.ico'>", 
                new Icon("/favicon.ico").Type(someDummyType));
        }

        [TestMethod]
        public void BasicPng()
        {
            Is($"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>", 
               new Icon("/path/icon.png"));
        }

        [TestMethod]
        public void CustomRel()
        {
            var customRel = "xyz";
            Is($"<link rel='{customRel}' type='{Icon.MimeTypes["png"]}' href='/path/icon.png'>",
                new Icon("/path/icon.png", rel: customRel));
        }

    }
}
