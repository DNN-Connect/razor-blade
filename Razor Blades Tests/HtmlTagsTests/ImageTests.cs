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

        }

        [TestMethod]
        public void ImgSizes()
        {
            Is("<img src='xyz' height='8' width='7'>", 
                new Img("xyz", 7, 8));

            Is("<img src='xyz' height='8' width='7'>",
                new Img("xyz").Height(8).Width(7));
        }

        [TestMethod]
        public void NoDuplicateAttributes()
        {
            Is("<img src='xyz' width='12'>", 
                new Img("xyz", 7).Width(12));

            Is("<img src='xyz' width='15'>",
                new Img("xyz").Width(14).Width("15"));
        }
    }
}
