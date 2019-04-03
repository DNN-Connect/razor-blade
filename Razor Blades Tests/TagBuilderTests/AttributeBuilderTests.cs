using Connect.Razor.Blade.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagBuilderTests
{
    [TestClass]
    public class AttributeBuilderTests
    {
        [TestMethod]
        public void BasicAttributes()
        {
            Assert.AreEqual("name='value'", new AttributeBase("name", "value").ToString());
            Assert.AreEqual("something='other'", new AttributeBase("something", "other").ToString());
        }

        [TestMethod]
        public void BasicAttributesQuote()
        {
            var options = new AttributeOptions {Quote = "\""};
            Assert.AreEqual("name=\"value\"", 
                new AttributeBase("name", "value", options).ToString());
            Assert.AreEqual("something=\"other\"",
                new AttributeBase("something", "other", options).ToString());
        }

        [TestMethod]
        public void UnEncodeQuote()
        {
            var options = new AttributeOptions { EncodeQuotes = true};
            Assert.AreEqual("name='{\"name\":\"daniel\"}'", 
                new AttributeBase("name", "{\"name\":\"daniel\"}").ToString());
            Assert.AreEqual("name='{&quot;name&quot;:&quot;daniel&quot;}'",
                new AttributeBase("name", "{\"name\":\"daniel\"}", options).ToString());

            options = new AttributeOptions {Quote = "\""};
            Assert.AreEqual("name=\"{&quot;name&quot;:&quot;daniel&quot;}\"",
                new AttributeBase("name", "{\"name\":\"daniel\"}", options).ToString(),
                "with a different quote and encodeQuotes false");

            options = new AttributeOptions {EncodeQuotes = true, Quote = "\""};
            Assert.AreEqual("name=\"{&quot;name&quot;:&quot;daniel&quot;}\"",
                new AttributeBase("name", "{\"name\":\"daniel\"}", options).ToString(),
                "with a different quote and encodeQuotes = true");

        }

        [TestMethod]
        public void UnEncodeApostropheInValue()
        {
            var options = new AttributeOptions { Quote = "\"" };
            Assert.AreEqual("name=\"isn't it ironic\"",
                new AttributeBase("name", "isn't it ironic", options).ToString(),
                "apostrophe with a different quote and encodeQuotes = false");

            options = new AttributeOptions { EncodeQuotes = true };
            Assert.AreEqual("name='isn&apos;t it ironic'",
                new AttributeBase("name", "isn't it ironic", options).ToString(),
                "apostrophe with a different quote and encodeQuotes = true");

            options = new AttributeOptions { EncodeQuotes = true, Quote = "\"" };
            Assert.AreEqual("name=\"isn&apos;t it ironic\"",
                new AttributeBase("name", "isn't it ironic", options).ToString(),
                "apostrophe with a different quote and encodeQuotes = true");

        }

        [TestMethod]
        public void BasicAttributesEmpty()
        {
            Assert.AreEqual("name=''", 
                new AttributeBase("name", "").ToString());
            Assert.AreEqual("name=''", 
                new AttributeBase("name", null).ToString());
            Assert.AreEqual("name=''", 
                new AttributeBase("name", null).ToString());

            var options = new AttributeOptions { KeepEmpty = false };
            Assert.AreEqual("", 
                new AttributeBase("name", "", options).ToString());
        }

        [TestMethod]
        public void ObjectValues()
        {
            //var options = new AttributeOptions { KeepEmpty = false };
            Assert.AreEqual("name='54'",
                new AttributeBase("name", 54).ToString());
            Assert.AreEqual("name='{\"Name\":\"Daniel\"}'",
                new AttributeBase("name", new { Name = "Daniel" }).ToString());
            Assert.AreEqual("name='Daniel'",
                new AttributeBase("name", "Daniel" as object).ToString());
        }

    }
}
