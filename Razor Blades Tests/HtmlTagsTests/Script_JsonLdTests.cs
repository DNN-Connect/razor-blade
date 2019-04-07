using Connect.Razor.Blade.Html5;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class Script_JsonLdTests : TagTestBase
    {

        [TestMethod]
        public void JsonLdString()
        {
            Is("<script type='application/ld+json'>some text</script>",
                new ScriptJsonLd("some text"));
            Is("<script type='application/ld+json'>{\"key\":\"value\"}</script>",
                new ScriptJsonLd("{\"key\":\"value\"}"));
        }

        [TestMethod]
        public void JsonLdObject()
        {
            Is("<script type='application/ld+json'>{\"key\":\"value\"}</script>",
                new ScriptJsonLd(new { key = "value" }));
        }

    }
}
