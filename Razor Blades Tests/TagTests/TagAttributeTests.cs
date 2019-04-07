using Connect.Razor.Blade;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class TagAttributeTests: TagTestBase
    {
        #region Generic Attr calls
        [TestMethod]
        public void TagAttributeBasics()
        {
            Is("<div class='x'>", Tags.Tag("div").Attr("class", "x").Open);
        }

        [TestMethod]
        public void TagAttributeStandalone()
        {
            Is("<div data-fancybox>", Tags.Tag("div").Attr("data-fancybox").Open);
        }

        [TestMethod]
        public void TagAttributeMultiple()
        {
            Is("<div class='x' name='value'>", Tags.Tag("div")
                .Attr("class", "x")
                .Attr("name", "value")
                .Open
            );
        }

         [TestMethod]
        public void TagAttributeAppend()
        {
            Is("<div class='xyz'>", Tags.Tag("div")
                .Attr("class", "x", "")
                .Attr("class", "y", "")
                .Attr("class", "z", "")
                .Open
            );
        }

        [TestMethod]
        public void TagAttributeSeparator()
        {
            Is("<div class='x,y-z'>", Tags.Tag("div")
                .Attr("class", "x", " ")
                .Attr("class", "y", ",")
                .Attr("class", "z", "-")
                .Open
            );
        }

        [TestMethod]
        public void TagAttributeReplace()
        {
            Is("<div class='z'>", Tags.Tag("div")
                .Attr("class", "x", " ")
                .Attr("class", "y", ",")
                .Attr("class", "z", null)
                .Open
            );
        }
        #endregion

        #region Id, Class, Title, Style
        [TestMethod]
        public void TagId()
        {
            Is("<div id='z'>", Tags.Tag("div").Id("z").Open);
            Is("<div id='y'>", Tags.Tag("div").Id("z").Id("y").Open);
            Is("<div id>", Tags.Tag("div").Id(null).Open);
            Is("<div id>", Tags.Tag("div").Id("z").Id(null).Open);
            Is("<div id='x'>", Tags.Tag("div").Id("z").Id(null).Id("x").Open);
        }

        [TestMethod]
        public void TagClass()
        {
            Is("<div class='z'>", Tags.Tag("div").Class("z").Open);
            Is("<div class='z y'>", Tags.Tag("div").Class("z").Class("y").Open);
            Is("<div class>", Tags.Tag("div").Class(null).Open);
            Is("<div class>", Tags.Tag("div").Class("z").Class("y").Class(null).Open);
            Is("<div class='x'>", Tags.Tag("div").Class("z").Class("y").Class(null).Class("x").Open);
        }

        [TestMethod]
        public void TagStyle()
        {
            Is("<div style='z'>", Tags.Tag("div").Style("z").Open);
            Is("<div style='z;y'>", Tags.Tag("div").Style("z").Style("y").Open);
            Is("<div style>", Tags.Tag("div").Style("z").Style("y").Style(null).Open);
            Is("<div style='x'>", Tags.Tag("div").Style("z").Style("y").Style(null).Style("x").Open);
        }
        #endregion
    }
}
