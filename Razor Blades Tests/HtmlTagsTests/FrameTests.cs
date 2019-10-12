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
                new IFrame());
            Is("<iframe src='https://azing.org'>", 
                new IFrame("https://azing.org"));
            Is("<iframe src='https://azing.org'>", 
                new IFrame().Src("https://azing.org"));

            Is("<iframe src='xyz' height='8' width='7'>", 
                new IFrame("xyz", 7, 8));
        }

    }
}
