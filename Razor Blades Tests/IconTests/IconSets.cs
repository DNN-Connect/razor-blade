using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            Assert.AreEqual(
                $"<link rel='{Icon.ShortcutRelationship}' type='{Icon.MimeTypes["ico"]}' href='/favicon.ico'>",
                set[2]);
        }

        [TestMethod]
        public void WithoutFav()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", false);
            Assert.AreEqual(2, set.Count, "expected 2 items in set");
        }

        private static readonly IEnumerable<string> Rels = new List<string> {"icon", "icon2", "icon3", "icon4"};
        private static readonly IEnumerable<int> Sizes = new int[] {
            100, 200, 250
        };

        [TestMethod]
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        public void CustomRels()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", false, Rels);
            Assert.AreEqual(4, set.Count, "expected 4 items in set");
            Assert.IsTrue(set[2].IndexOf("icon3")> 0);
            Assert.IsTrue(set[2].IndexOf("icon4") == -1);
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        public void CustomSizesWithoutFavicon()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", false, sizes:Sizes);
            Assert.AreEqual(6, set.Count, "expected 3 sizes for 2 default rels in set");
            Assert.AreEqual(2, set.Count(i => i.IndexOf("100x100") > 0));
            Assert.AreEqual(2, set.Count(i => i.IndexOf("200x200") > 0));
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        public void CustomSizesWithFavicon()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", sizes:Sizes);
            Assert.AreEqual(7, set.Count, "expected 3 sizes for 2 default rels + 1 fav in set");
            Assert.AreEqual(2, set.Count(i => i.IndexOf("100x100") > 0));
            Assert.AreEqual(2, set.Count(i => i.IndexOf("200x200") > 0));
        }


        [TestMethod]
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        public void CustomSizesOneRel()
        {
            var set = Icon.GenerateIconSet("/path/icon.png", false, rels: new []{"icon"}, sizes:Sizes);
            Assert.AreEqual(3, set.Count, "expected 3 sizes for 1 default rels in set");
            Assert.AreEqual(1, set.Count(i => i.IndexOf("100x100") > 0));
            Assert.AreEqual(1, set.Count(i => i.IndexOf("200x200") > 0));
        }

    }
}
