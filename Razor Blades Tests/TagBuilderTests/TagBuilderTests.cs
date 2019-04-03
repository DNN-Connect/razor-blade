using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagBuilderTests
{
    [TestClass]
    public class TagBuilderTests
    {
        [TestMethod]
        public void BasicTags()
        {
            Assert.AreEqual("<p></p>", new Tag("p").ToString());
            Assert.AreEqual("<em></em>", new Tag("em").ToString());
            Assert.AreEqual("<EM></EM>", new Tag("EM").ToString());
            Assert.AreEqual("<ng-template></ng-template>", new Tag("ng-template").ToString());
        }


        [TestMethod]
        public void Content()
        {
            // ReSharper disable once RedundantArgumentDefaultValue
            Assert.AreEqual("<p></p>",
                new Tag("p") { Content = null }.ToString());
            Assert.AreEqual("<em></em>", 
                new Tag("em") { Content =  ""}.ToString());
            Assert.AreEqual("<p> </p>", 
                new Tag("p") { Content =  " "}.ToString());
            Assert.AreEqual("<p>...</p>",
                new Tag("p") { Content =  "..."}.ToString());
            Assert.AreEqual("<p>many\nlines</p>", 
                new Tag("p") { Content =  "many\nlines"}.ToString());
        }

        [TestMethod]
        public void ContentWithInvalidClosing()
        {
            Assert.AreEqual("<p>...</p>", 
                new Tag("p", new TagOptions {SelfClose = true}) { Content =  "..." }.ToString());

            Assert.AreEqual("<p>...</p>",
                new Tag("p", new TagOptions {Close = false})
                    {Content = "..."}.ToString());

            Assert.AreEqual("<p>...</p>", new Tag("p", new TagOptions {Close = false, SelfClose = true})
                {Content = "..."}.ToString());
        }


        [TestMethod]
        public void TagsWithIdAndClasses() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right'></p>", 
                new Tag("p").Id("myId").Class("my-class float-right").ToString());

        [TestMethod]
        public void TagsWithAttributeString() 
            => Assert.AreEqual("<p data='xyz'></p>", 
                new Tag("p").Attr("data='xyz'").ToString());

        [TestMethod]
        public void TagsWithAttributeList()
            => Assert.AreEqual("<p data='xyz' kitchen='black'></p>",
                new Tag("p")
                    .Attr("data", "xyz").Attr("kitchen", "black")
                    .ToString());

        [TestMethod]
        public void TagsWithClassIdAndAttributeString() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right' data='xyz'></p>", 
                new Tag("p").Id("myId").Class("my-class float-right")
                    .Attr("data='xyz'").ToString());

        [TestMethod]
        public void TagsWithClassIdAndAttributeList() 
            => Assert.AreEqual("<p id='myId' class='my-class float-right' data='xyz' kitchen='black'></p>", 
                new Tag("p")
                    .Id("myId").Class("my-class float-right")
                    .Attr("data", "xyz").Attr("kitchen", "black")
                    .ToString());

        [TestMethod]
        public void TagWithSelfClose()
            => Assert.AreEqual("<p/>", 
                new Tag("p", options: new TagOptions {SelfClose = true})
                    .ToString());

        [TestMethod]
        public void TagsWithIdAndClassesSelfClose()
            => Assert.AreEqual("<p id='myId' class='my-class float-right'/>",
                new Tag("p", new TagOptions { SelfClose = true }).Id("myId").Class("my-class float-right").ToString());


        [TestMethod]
        public void TagsWithClassIdAndAttributeListOptionsQuote() 
            => Assert.AreEqual("<p id=\"myId\" class=\"my-class float-right\" data=\"xyz\" kitchen=\"black\"></p>", 
                new Tag("p", options: new TagOptions(new AttributeOptions { Quote = "\"" }))
                    .Id("myId").Class("my-class float-right")
                    .Attr("data", "xyz")
                    .Attr("kitchen", "black")
                    .ToString()
                );

    }
}
