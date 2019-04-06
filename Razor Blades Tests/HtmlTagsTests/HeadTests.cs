using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class HeadTests: TagTestBase
    {
        [TestMethod]
        public void MetaTag()
        {
            Is("<meta name='something' content='other'/>", 
                new Meta("something", "other"));
            Is("<meta name='something' content='other'/>", 
                new Meta("something").Content("other"));
            Is("<meta name='something' content='other'/>", 
                new Meta().Name("something").Content("other"));
        }

        [TestMethod]
        public void MetaOgTag()
        {
            Is("<meta property='something' content='other'/>", 
                new MetaOg("something", "other"), "basic");
            Is("<meta property='something' content='other'/>",
                new MetaOg("something", "").Content("other"), "content as fluent call");
            Is("<meta property='something' content='other'/>",
                new MetaOg().Property("something").Content( "other"), "default order");
            Is("<meta content='other' property='something'/>",
                new MetaOg().Content("other").Property("something"), "modified order");
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
