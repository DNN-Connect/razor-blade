using System.Collections.Generic;
using Connect.Razor.Blade.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagBuilderTests
{
    [TestClass]
    public class TagBuilderTests
    {
        [TestMethod]
        public void BasicTags()
        {
            Assert.AreEqual("<p></p>", TagBuilder.Tag("p"));
            Assert.AreEqual("<em></em>", TagBuilder.Tag("em"));
            Assert.AreEqual("<EM></EM>", TagBuilder.Tag("EM"));
            Assert.AreEqual("<ng-template></ng-template>", TagBuilder.Tag("ng-template"));
        }


        [TestMethod]
        public void Content()
        {
            // ReSharper disable once RedundantArgumentDefaultValue
            Assert.AreEqual("<p></p>", TagBuilder.Tag("p", content: null));
            Assert.AreEqual("<em></em>", TagBuilder.Tag("em", content: ""));
            Assert.AreEqual("<p> </p>", TagBuilder.Tag("p", content: " "));
            Assert.AreEqual("<p>...</p>", TagBuilder.Tag("p", content: "..."));
            Assert.AreEqual("<p>many\nlines</p>", TagBuilder.Tag("p", content: "many\nlines"));
        }

        [TestMethod]
        public void ContentWithInvalidClosing()
        {
            Assert.AreEqual("<p>...</p>", TagBuilder.Tag("p", content: "...", 
                options: new TagOptions {SelfClose = true}));

            Assert.AreEqual("<p>...</p>", TagBuilder.Tag("p", content: "...", 
                options: new TagOptions {Close = false}));

            Assert.AreEqual("<p>...</p>", TagBuilder.Tag("p", content: "...", 
                options: new TagOptions {Close = false, SelfClose = true}));
        }


        [TestMethod]
        public void TagsWithIdAndClasses() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right'></p>", 
                TagBuilder.Tag("p", id: "myId", classes:"my-class float-right"));

        [TestMethod]
        public void TagsWithAttributeString() 
            => Assert.AreEqual("<p data='xyz'></p>", 
                TagBuilder.Tag("p", attributes: "data='xyz'"));

        [TestMethod]
        public void TagsWithAttributeList()
            => Assert.AreEqual("<p data='xyz' kitchen='black'></p>",
                TagBuilder.Tag("p", attributes: new Dictionary<string, string>
                {
                    {"data", "xyz"},
                    {"kitchen", "black"}
                }));

        [TestMethod]
        public void TagsWithClassIdAndAttributeString() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right' data='xyz'></p>", 
                TagBuilder.Tag("p", attributes: "data='xyz'", id: "myId", classes:"my-class float-right"));

        [TestMethod]
        public void TagsWithClassIdAndAttributeList() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right' data='xyz' kitchen='black'></p>", 
                TagBuilder.Tag("p", attributes: new Dictionary<string, string>
                {
                    {"data", "xyz"},
                    {"kitchen", "black"}
                }, id: "myId", classes:"my-class float-right"));

        [TestMethod]
        public void TagWithSelfClose()
            => Assert.AreEqual("<p/>", 
                TagBuilder.Tag("p", options: new TagOptions {SelfClose = true}));

        [TestMethod]
        public void TagsWithIdAndClassesSelfClose()
            => Assert.AreEqual("<p id='myId' class='my-class float-right'/>",
                TagBuilder.Tag("p", id: "myId", 
                    classes: "my-class float-right",
                    options: new TagOptions { SelfClose = true }));


        [TestMethod]
        public void TagsWithClassIdAndAttributeListOptionsQuote() 
            => Assert.AreEqual("<p id=\"myId\" class=\"my-class float-right\" data=\"xyz\" kitchen=\"black\"></p>", 
                TagBuilder.Tag("p", attributes: new Dictionary<string, string>
                {
                    {"data", "xyz"},
                    {"kitchen", "black"}
                }, id: "myId", classes:"my-class float-right", 
                    options: new TagOptions(new AttributeOptions {Quote = "\""}))
                );

    }
}
