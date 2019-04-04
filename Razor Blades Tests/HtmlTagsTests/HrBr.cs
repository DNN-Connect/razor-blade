using System;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class HrBr: TagTestBase
    {
        [TestMethod]
        public void Hr()
        {
            Is("<hr>", new Hr());
        }

        [TestMethod]
        public void Br()
        {
            Is("<br>", new Br());
        }
    }
}
