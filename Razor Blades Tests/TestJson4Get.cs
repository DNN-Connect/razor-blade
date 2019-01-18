using System;
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
            //{"('Val':'...')", new OneValue("...") },
            {"('Val':'simple')", new OneValue("simple")},
            {"('Val':8)", new OneValue(8)},
            {"('Val':'single quote \\'')", new OneValue("single quote '")},
            {"('Val':'multi \\'single quote\\'')", new OneValue("multi 'single quote'")},
            {"('Val':'multi single \\'\\'')", new OneValue("multi single ''") },
            {"('Val':'double \\\"')", new OneValue("double \"") },
            {"('Val':'text with {curly} and (normal) brackets')", new OneValue("text with {curly} and (normal) brackets") },
            {"('Val':'mixed \\\" \\' quotes \\\" \\'')", new OneValue("mixed \" ' quotes \" '") },
            {"('Val':'containing square [ brackets ]')", new OneValue("containing square [ brackets ]") },
            //{"('Val':'...')", new OneValue("...") },
            //{"('Val':'...')", new OneValue("...") },
            //{"('Val':'...')", new OneValue("...") },
        };


        [TestMethod]
        public void SingleValuesEncode()
        {
            foreach (var test in SimpleValues)
            {
                var json = JsonConvert.SerializeObject(test.Value);
                var asGet = Json4Get.Encode(json);
                Assert.AreEqual(test.Key, asGet, $"trouble with:{test.Value.Val}");
            }
        }

        [TestMethod]
        public void SingleValuesRecode()
        {
            foreach (var test in SimpleValues)
            {
                var json = JsonConvert.SerializeObject(test.Value);
                var asGet = Json4Get.Encode(json);
                var origVal = test.Value.Val;
                Assert.AreEqual(test.Key, asGet, $"trouble with:{origVal}");
                var decoded = Json4Get.Decode(asGet);
                Assert.AreEqual(json, decoded, $"should be like the original `{origVal}`");
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
