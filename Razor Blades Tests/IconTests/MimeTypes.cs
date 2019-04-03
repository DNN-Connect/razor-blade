using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.IconTests
{
    [TestClass]
    public class MimeTypes
    {
        [TestMethod]
        public void BasicPaths()
        {
            Assert.AreEqual(Icon.MimeTypes["gif"], Icon.DetectImageMime("xyz\\abc\\def.gif"));
            Assert.AreEqual(Icon.MimeTypes["png"], Icon.DetectImageMime("xyz\\abc\\def.png"));
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz\\abc\\def.jpg"));
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz\\abc\\def.jpeg"));
        }

        [TestMethod]
        public void BasicUrls()
        {
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz/abc/def.jpg"));
        }

        [TestMethod]
        public void UrlsWithQuestionMark()
        {
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz/abc/def.jpg?w=200"));
        }

        [TestMethod]
        public void UrlsWithHash()
        {
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz/abc/def.jpg#w=200"));
        }

        [TestMethod]
        public void UrlsWithQmAndHash()
        {
            Assert.AreEqual(Icon.MimeTypes["jpg"], Icon.DetectImageMime("xyz/abc/def.jpg?w=200#awesome"));
        }

        [TestMethod]
        public void InvalidStuff()
        {
            Assert.AreEqual("", Icon.DetectImageMime(null));
            Assert.AreEqual("", Icon.DetectImageMime(""));
            Assert.AreEqual("", Icon.DetectImageMime(" "));
            Assert.AreEqual("", Icon.DetectImageMime("\n"));
            Assert.AreEqual("", Icon.DetectImageMime("some random text"));
        }


    }
}
