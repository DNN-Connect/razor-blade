using System.Collections.Generic;
using Connect.Razor.Json4Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Razor_Blades_Tests
{
    [TestClass]
    public class TestJson4Get
    {
        public static Dictionary<string, OneValue> SimpleValues = new Dictionary<string, OneValue>
        {
            {"('Val':'simple')", new OneValue("simple")},
            {"('Val':8)", new OneValue(8)},
            {"('Val':'single quote \\'')", new OneValue("single quote '")},
            {"('Val':'multi \\'single quote\\'')", new OneValue("multi 'single quote'")},
            {"('Val':'multi single \\'\\'')", new OneValue("multi single ''") },
            {"('Val':'double \\\"')", new OneValue("double \"") },
        };


        [TestMethod]
        public void SingleValues()
        {
            foreach (var test in SimpleValues)
            {
                var json = JsonConvert.SerializeObject(test.Value);
                var json4get = Json4Get.Encode(json);
                Assert.AreEqual(test.Key, json4get, $"trouble with:{test.Value.Val}");
            }
        }

        [TestMethod]
        public void EncodeBasic()
        {
            var test = new
            {
                Key = "something",
                Value = "something else",
                SomeArray = new[] {"a string", "another string"},
                IntArr = new[] {7, 8, 8}
            };
            var expected = "('Key':'something','Value':'something else','SomeArray':['a string','another string'],'IntArr':[7,8,8])";
            var json = JsonConvert.SerializeObject(test);
            var result = Json4Get.Encode(json);
            Assert.AreEqual(expected, result);
        }

        public class OneValue
        {
            public object Val;
            public OneValue(object value) => Val = value;
        }
    }
}
