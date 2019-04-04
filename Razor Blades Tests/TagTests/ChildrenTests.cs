using System;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable MustUseReturnValue

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class ChildrenTests
    {
        [TestMethod]
        public void TextChildren()
        {
            var tag = new Div();
            tag.Add("razor");
            Assert.AreEqual("<div>razor</div>", tag.ToString());
            tag.Add("blade");
            Assert.AreEqual("<div>razorblade</div>", tag.ToString());
        }

        [TestMethod]
        public void TagChildren()
        {
            var tag = new Div();
            tag.Add(new Span());
            Assert.AreEqual("<div><span></span></div>", tag.ToString());
            tag.Add(new Div());
            Assert.AreEqual("<div><span></span><div></div></div>", tag.ToString());
        }

        [TestMethod]
        public void MixedChildren()
        {
            var tag = new Div();
            tag.Add(new Span());
            Assert.AreEqual("<div><span></span></div>", tag.ToString());
            tag.Add("razor-blade");
            Assert.AreEqual("<div><span></span>razor-blade</div>", tag.ToString());
        }

        [TestMethod]
        public void Wrap()
        {
            var tag = new Div();
            tag.Add(new Span());
            Assert.AreEqual("<div><span></span></div>", tag.ToString());
            tag.Wrap("razor-blade");
            Assert.AreEqual("<div>razor-blade</div>", tag.ToString());
        }

        [TestMethod]
        public void SetContent()
        {
            var tag = new Div();
            tag.Add(new Span());
            Assert.AreEqual("<div><span></span></div>", tag.ToString());
            tag.Content = "razor-blade";
            Assert.AreEqual("<div>razor-blade</div>", tag.ToString());
        }


        [TestMethod]
        public void SubChildren()
        {
            var tag = new Div();
            var span = new Span().Add(new Div());
            tag.Add(span);
            Assert.AreEqual("<div><span><div></div></span></div>", tag.ToString());
            tag.Add(span);
            Assert.AreEqual("<div><span><div></div></span><span><div></div></span></div>", tag.ToString());
        }

        [TestMethod]
        public void SubChildrenAndText()
        {
            var tag = new Div();
            var span = new Span().Add(new Div());
            tag.Add(span);
            Assert.AreEqual("<div><span><div></div></span></div>", tag.ToString());
            tag.Add("razor-blade");
            Assert.AreEqual("<div><span><div></div></span>razor-blade</div>", tag.ToString());
        }

        [TestMethod]
        public void SubChildrenPreserveOptions()
        {
            var tag = new Div().Id("27");
            tag.Options = new TagOptions(new AttributeOptions {Quote = "\""});
            var span = new Span().Id("spn").Add(new Div());
            tag.Add(span);
            Assert.AreEqual("<div id=\"27\"><span id=\"spn\"><div></div></span></div>", tag.ToString());
        }

        [TestMethod]
        public void SubChildrenPreserveOptionsUnlessOverridden()
        {
            var tag = new Div().Id("27");
            tag.Options = new TagOptions(new AttributeOptions { Quote = "\"" });
            var span = new Span().Id("spn").Add(new Div());
            span.Options = new TagOptions();
            tag.Add(span);
            Assert.AreEqual("<div id=\"27\"><span id='spn'><div></div></span></div>", tag.ToString());
        }

    }
}
