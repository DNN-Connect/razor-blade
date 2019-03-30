using Connect.Razor.Internals.HtmlPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.IconTests
{
    [TestClass]
    public class IconSets
    {
        [TestMethod]
        public void DefaultSet()
        {
            var path = "/path/icon.png";
            var set = Icon.GenerateIconSet(path);
            Assert.AreEqual(3, set.Count, "expected 3 items in set");
            Assert.AreEqual($"<link rel='{Icon.DefaultRelationship}' type='{Icon.MimeTypes["png"]}' href='{path}'>", 
                set[0]);
            Assert.AreEqual($"<link rel='{Icon.AppleRelationship}' type='{Icon.MimeTypes["png"]}' href='{path}'>",
                set[1]);
            Assert.AreEqual($"<link rel='{Icon.ShortcutRelationship}' type='{Icon.MimeTypes["ico"]}' href='/favicon.ico'>", 
                set[2]);
        }

        [TestMethod]
        public void WithoutFav()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", false);
            Assert.AreEqual(2, set.Count, "expected 2 items in set");
        }

        //[TestMethod]
        //public void WithoutFav()
        //{
        //    var set = Icon.GenerateIconSet("/path/icon.png", false);
        //    Assert.AreEqual(3, set.Count, "expected 3 items in set");
        //}

    }
}
