using Connect.Razor.Blade;
using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class FrameTests: TagTestBase
    {
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void IFrames()
        {
            Is("<iframe>", 
                new Iframe());
            Is("<iframe src='https://azing.org'>", 
                new Iframe("https://azing.org"));
            Is("<iframe src='https://azing.org'>", 
                new Iframe().Src("https://azing.org"));

            Is("<iframe src='xyz' height='8' width='7'>", 
                new Iframe("xyz", 7, 8));
        }

    }
}
