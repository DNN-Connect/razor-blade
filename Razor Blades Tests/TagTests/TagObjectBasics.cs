using Connect.Razor.Blade;
using Connect.Razor.Blade.Tag;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagObjectBasics
    {
        [TestMethod]
        public void VeryBasic()
        {
            Assert.AreEqual("<div></div>", new Generic().ToString());
            Assert.AreEqual("<strong></strong>", new Generic{Name = "strong"}.ToString());
            Assert.AreEqual("<strong>...</strong>", new Generic { Name = "strong", Content = "..."}.ToString());
        }
    }
}
