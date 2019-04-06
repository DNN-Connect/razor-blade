using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagObjectBasics: TagTestBase
    {
        [TestMethod]
        public void VeryBasic()
        {
            Is("<div></div>", new Tag("div"));
            Is("<strong></strong>", new Tag{TagName = "strong"});
            Is("<strong>...</strong>", new Tag { TagName = "strong", TagContents = "..."});
        }
    }
}
