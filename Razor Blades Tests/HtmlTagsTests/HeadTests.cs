using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class HeadTests
    {
        [TestMethod]
        public void MetaTag()
        {
            Assert.AreEqual("<meta name='something' content='other'/>", new Meta("something", "other").ToString());
            Assert.AreEqual("<meta property='something' content='other'/>", new MetaOg("something", "other").ToString());
        }

        [TestMethod]
        public void JsonLdString()
        {
            Assert.AreEqual("<script type='application/ld+json'>some text</script>",
                new ScriptJsonLd("some text").ToString());
            Assert.AreEqual("<script type='application/ld+json'>{\"key\":\"value\"}</script>",
                new ScriptJsonLd("{\"key\":\"value\"}").ToString());
        }

        [TestMethod]
        public void JsonLdObject()
        {
            Assert.AreEqual("<script type='application/ld+json'>{\"key\":\"value\"}</script>",
                new ScriptJsonLd(new { key = "value" }).ToString());
        }

    }
}
