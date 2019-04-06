using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class MetaTests: TagTestBase
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
                new MetaOg("something", "").Content("other"), "");
            Is("<meta property='something' content='other'/>",
                new MetaOg().Property("something").Content( "other"), "default order");
            Is("<meta content='other' property='something'/>",
                new MetaOg().Content("other").Property("something"), "modified order");
        }


        [TestMethod]
        public void MetaTagFluentWithBaseProperties()
        {
            Is("<meta id='x' name='something' content='other'/>",
                new Meta().Id("x").Name("something").Content("other"));
        }


    }
}
