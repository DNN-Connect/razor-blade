using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class ImageTests: TagTestBase
    {
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void Img()
        {
            Is("<img>", 
                new Img());
            Is("<img src='https://azing.org'>", 
                new Img("https://azing.org"));
            Is("<img src='https://azing.org'>", 
                new Img().Src("https://azing.org"));

            Is("<img src='xyz' height='8' width='7'>", 
                new Img("xyz", 7, 8));
        }

    }
}
