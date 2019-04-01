using Connect.Razor.Blade;
using Connect.Razor.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagTests
{
    [TestClass]
    public class AttributeBuilderTests
    {
        [TestMethod]
        public void BasicAttributes()
        {
            Assert.AreEqual("name='value'", AttributeBuilder.Attribute("name", "value"));
            Assert.AreEqual("something='other'", AttributeBuilder.Attribute("something", "other"));
        }

        [TestMethod]
        public void BasicAttributesQuote()
        {
            var options = new AttributeOptions {Quote = "\""};
            Assert.AreEqual("name=\"value\"", 
                AttributeBuilder.Attribute("name", "value", options));
            Assert.AreEqual("something=\"other\"",
                AttributeBuilder.Attribute("something", "other", options));
        }

        [TestMethod]
        public void UnEncodeQuote()
        {
            var options = new AttributeOptions { EncodeQuotes = true};
            Assert.AreEqual("name='{\"name\":\"daniel\"}'", 
                AttributeBuilder.Attribute("name", "{\"name\":\"daniel\"}"));
            Assert.AreEqual("name='{&quot;name&quot;:&quot;daniel&quot;}'",
                AttributeBuilder.Attribute("name", "{\"name\":\"daniel\"}", options));

            options = new AttributeOptions {Quote = "\""};
            Assert.AreEqual("name=\"{&quot;name&quot;:&quot;daniel&quot;}\"",
                AttributeBuilder.Attribute("name", "{\"name\":\"daniel\"}", options),
                "with a different quote and encodeQuotes false");

            options = new AttributeOptions {EncodeQuotes = true, Quote = "\""};
            Assert.AreEqual("name=\"{&quot;name&quot;:&quot;daniel&quot;}\"",
                AttributeBuilder.Attribute("name", "{\"name\":\"daniel\"}", options),
                "with a different quote and encodeQuotes = true");

        }

        [TestMethod]
        public void UnEncodeApostropheInValue()
        {
            var options = new AttributeOptions { Quote = "\"" };
            Assert.AreEqual("name=\"isn't it ironic\"",
                AttributeBuilder.Attribute("name", "isn't it ironic", options),
                "apostrophe with a different quote and encodeQuotes = false");

            options = new AttributeOptions { EncodeQuotes = true };
            Assert.AreEqual("name='isn&apos;t it ironic'",
                AttributeBuilder.Attribute("name", "isn't it ironic", options),
                "apostrophe with a different quote and encodeQuotes = true");

            options = new AttributeOptions { EncodeQuotes = true, Quote = "\"" };
            Assert.AreEqual("name=\"isn&apos;t it ironic\"",
                AttributeBuilder.Attribute("name", "isn't it ironic", options),
                "apostrophe with a different quote and encodeQuotes = true");

        }

        [TestMethod]
        public void BasicAttributesEmpty()
        {
            var options = new AttributeOptions { KeepEmpty = false };
            Assert.AreEqual("name=''", 
                AttributeBuilder.Attribute("name", ""));
            Assert.AreEqual("name=''", 
                AttributeBuilder.Attribute("name", null));
            Assert.AreEqual("name=''", 
                AttributeBuilder.Attribute("name", null));
            Assert.AreEqual("", 
                AttributeBuilder.Attribute("name", "", options));
        }

        [TestMethod]
        public void ObjectValues()
        {
            //var options = new AttributeOptions { KeepEmpty = false };
            Assert.AreEqual("name='54'",
                AttributeBuilder.Attribute("name", 54));
            Assert.AreEqual("name='{\"Name\":\"Daniel\"}'",
                AttributeBuilder.Attribute("name", new { Name = "Daniel" }));
            Assert.AreEqual("name='Daniel'",
                AttributeBuilder.Attribute("name", "Daniel" as object));
        }

    }
}
