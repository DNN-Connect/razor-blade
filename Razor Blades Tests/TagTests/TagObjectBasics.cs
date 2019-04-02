using Connect.Razor.Blade.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagObjectBasics
    {
        [TestMethod]
        public void VeryBasic()
        {
            Assert.AreEqual("<div></div>", new Tag().ToString());
            Assert.AreEqual("<strong></strong>", new Tag{Name = "strong"}.ToString());
            Assert.AreEqual("<strong>...</strong>", new Tag { Name = "strong", Content = "..."}.ToString());
        }
    }
}
