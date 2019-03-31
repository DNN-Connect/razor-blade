using Connect.Razor.Blade;
using System.Collections.Generic;
using Connect.Razor.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagBuilder
    {
        private static readonly Dictionary<string, string> TestVals = new Dictionary<string, string>
        {
            {"hello", "hello"},
            {"that's", "that&apos;s" },
            {"he said: \"hello\"", "he said: &quot;hello&quot;" },
            {"this & that", "this &amp; that" }
        };

        [TestMethod]
        public void AttributeEncode()
        {
            foreach(var set in TestVals)
                Assert.AreEqual(set.Value, Html.EncodeString(set.Key), $"{set.Key}");
        }
    }
}
