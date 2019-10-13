using Connect.Razor.Blade;
using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests.IconTests
{
    [TestClass]
    public class MimeTypes
    {
        [TestMethod]
        public void BasicPaths()
        {
            Assert.AreEqual(Mime.MimeTypes["gif"], Mime.DetectImageMime("xyz\\abc\\def.gif"));
            Assert.AreEqual(Mime.MimeTypes["png"], Mime.DetectImageMime("xyz\\abc\\def.png"));
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz\\abc\\def.jpg"));
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz\\abc\\def.jpeg"));
        }

        [TestMethod]
        public void BasicUrls()
        {
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz/abc/def.jpg"));
        }

        [TestMethod]
        public void UrlsWithQuestionMark()
        {
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz/abc/def.jpg?w=200"));
        }

        [TestMethod]
        public void UrlsWithHash()
        {
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz/abc/def.jpg#w=200"));
        }

        [TestMethod]
        public void UrlsWithQmAndHash()
        {
            Assert.AreEqual(Mime.MimeTypes["jpg"], Mime.DetectImageMime("xyz/abc/def.jpg?w=200#awesome"));
        }

        [TestMethod]
        public void InvalidStuff()
        {
            Assert.AreEqual("", Mime.DetectImageMime(null));
            Assert.AreEqual("", Mime.DetectImageMime(""));
            Assert.AreEqual("", Mime.DetectImageMime(" "));
            Assert.AreEqual("", Mime.DetectImageMime("\n"));
            Assert.AreEqual("", Mime.DetectImageMime("some random text"));
        }


    }
}
