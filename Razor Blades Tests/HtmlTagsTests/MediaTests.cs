using Connect.Razor.Blade;
using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class MediaTests: TagTestBase
    {
        //[TestMethod]
        //public void AudioBasic()
        //{
        //}

        [TestMethod]
        public void AudioRealLife()
        {
            const string expected = @"<audio controls><source src='horse.ogg' type='audio/ogg'><source src='horse.mp3' type='audio/mpeg'>Your browser does not support the audio tag.</audio>";
            var result = new Audio().Controls()
                .Add(new Source("horse.ogg", "audio/ogg"))
                .Add(new Source("horse.mp3", "audio/mpeg"))
                .Add("Your browser does not support the audio tag.");

            Is(expected, result);

        }

    }
}
