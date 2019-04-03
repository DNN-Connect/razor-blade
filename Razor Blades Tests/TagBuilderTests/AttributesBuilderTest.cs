using System.Collections.Generic;
using Connect.Razor.Blade.HtmlTags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.TagBuilderTests
{
    [TestClass]
    public class AttributesBuilderTest
    {
        [TestMethod]
        public void Basic()
        {
            var attributes = new Dictionary<string, string>
            {
                {"Name", "Daniel"},
                {"Age", "unknown"}
            };
            Assert.AreEqual("Name='Daniel' Age='unknown'",
                new AttributeListBase(attributes).ToString());
            Assert.AreEqual("Name=\"Daniel\" Age=\"unknown\"", 
                new AttributeListBase(attributes, new AttributeOptions { Quote = "\""}).ToString());
        }

        private Dictionary<string, object> AttributeObjects = new Dictionary<string, object>
            {
                {"Name", "Daniel" },
                {"Profile", new { Age = 17 } }
            };

        [TestMethod]
        public void ObjectsNormalQuote()
        {
             Assert.AreEqual("Name='Daniel' Profile='{\"Age\":17}'",
                new AttributeListBase(AttributeObjects).ToString());
       }

        [TestMethod]
        public void ObjectsDoubleQuote()
        {
             Assert.AreEqual("Name=\"Daniel\" Profile=\"{&quot;Age&quot;:17}\"",
                new AttributeListBase(AttributeObjects, new AttributeOptions { Quote = "\""}).ToString());
       }

        [TestMethod]
        public void AddSameAttribute()
        {
            var list = new AttributeListBase();
            list.Add("name", "value");
            list.Add("name", "value2");
            Assert.AreEqual("name='value value2'", list.ToString());
        }

        [TestMethod]
        public void AddSameAttributeComma()
        {
            var list = new AttributeListBase();
            list.Add("name", "value");
            list.Add("name", "value2", separator:",");
            Assert.AreEqual("name='value,value2'", list.ToString());
        }

        [TestMethod]
        public void AddSameAttributeReplace()
        {
            var list = new AttributeListBase();
            list.Add("name", "value");
            list.Add("name", "value2", true);
            Assert.AreEqual("name='value2'", list.ToString());
        }

    }
}
