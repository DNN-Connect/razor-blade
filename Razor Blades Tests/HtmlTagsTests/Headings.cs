using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class Headings : TagTestBase
    {
        [TestMethod]
        public void H1To6()
        {
            Is("<h1></h1>", new H1());
            Is("<h2></h2>", new H2());
            Is("<h3></h3>", new H3());
            Is("<h4></h4>", new H4());
            Is("<h5></h5>", new H5());
            Is("<h6></h6>", new H6());
        }

        [TestMethod]
        public void H1To6WithContent()
        {
            Is("<h1>title</h1>", new H1("title"));
            Is("<h2>title</h2>", new H2("title"));
            Is("<h3>title</h3>", new H3("title"));
            Is("<h4>title</h4>", new H4("title"));
            Is("<h5>title</h5>", new H5("title"));
            Is("<h6>title</h6>", new H6("title"));
        }
    }

}
