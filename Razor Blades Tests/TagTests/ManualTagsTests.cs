using Connect.Razor.Blade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class ManualTagsTests: TagTestBase
    {
        [TestMethod]
        public void RealTags()
        {
            var text = "<div>";
            Is(text, new Tag(text));
            text = "<div id='7'>text</div>";
            Is(text, new Tag(text));
        }

        [TestMethod]
        public void Comment()
        {
            var text = "<!-- comment -->";
            Is(text, new Tag(text));
        }

        [TestMethod]
        public void Text()
        {
            var text = "div";
            Is(text, Tag.Text(text));
        }
    }

}
