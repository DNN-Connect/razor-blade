using System.Collections.Generic;
using Connect.Razor.Json4Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Razor_Blades_Tests
{
    [TestClass]
    public class Json4Get_Tests
    {
        public static Dictionary<string, OneValue> SimpleValues = new Dictionary<string, OneValue>
        {
            //{"('Val'!'...')", new OneValue("...") },
            {"('Val'!'simple')", new OneValue("simple")},
            {"('Val'!8)", new OneValue(8)},
            {"('Val'!'single_quote_\\'')", new OneValue("single quote '")},
            {"('Val'!'multi_\\'single_quote\\'')", new OneValue("multi 'single quote'")},
            {"('Val'!'multi_single_\\'\\'')", new OneValue("multi single ''") },
            {"('Val'!'double_\\\"')", new OneValue("double \"") },
            {"('Val'!'text_with_{curly}_and_(normal)_brackets')", new OneValue("text with {curly} and (normal) brackets") },
            {"('Val'!'mixed_\\\"_\\'_quotes_\\\"_\\'')", new OneValue("mixed \" ' quotes \" '") },
            {"('Val'!'containing_square_[_brackets_]')", new OneValue("containing square [ brackets ]") },
            {"('Val'!L1*2*3*-4*-22J)", new OneValue(new [] {1,2,3,-4,-22}) },
            {"('Val'!n)", new OneValue(null) },
            {"('Val'!t)", new OneValue(true) },
            {"('Val'!f)", new OneValue(false) },
        };

        public static Dictionary<string, string> Compactify = new Dictionary<string, string>
        {
            {"('Val'!'simple')", "{\"Val\" : \"simple\"}"},
            {"('Val'!'simple-containing-quote\\\"')", "{\"Val\" : \"simple-containing-quote\\\"\"}"},
            {"('Val'!'simple2')", "   {\"Val\" : \"simple2\"}"},
            {"('Val'!'simple3')", "   {  \"Val\" : \"simple3\"}"},
            {"('Val'!'simple4')", "   {  \"Val\" \n\n: \"simple4\"}"},
            //{"('Val'!)", "{\"Val\"}"},
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
                var decoded = Json4Get.Decode(asGet);
                Assert.AreEqual(json, decoded, $"should be like the original `{test.Value.Val}`");
            }
        }

        [TestMethod]
        public void CompactifyEncode()
        {
            foreach (var test in Compactify)
            {
                var asGet = Json4Get.Encode(test.Value);
                Assert.AreEqual(test.Key, asGet, $"trouble with:{test.Value}");
            }
        }


        [TestMethod]
        public void EncodeRecodeObject()
        {
            var test = new
            {
                Key = "something",
                Value = "something else",
                SomeArray = new[] {"a string", "another string"},
                IntArr = new[] {7, 8, 8},
                Is = true,
                Isnt = false,
                Null = null as string
            };
            var expectedJson4Get = "('Key'!'something'*'Value'!'something_else'*" 
                + "'SomeArray'!L'a_string'*'another_string'J*"
                +"'IntArr'!L7*8*8J*" 
                + "'Is'!t*'Isnt'!f*'Null'!n)";
            var json = JsonConvert.SerializeObject(test);
            var result = Json4Get.Encode(json);
            Assert.AreEqual(expectedJson4Get, result);
            var back = Json4Get.Decode(result);
            Assert.AreEqual(json, back, "convert back should work");
        }

        public class OneValue
        {
            public object Val;
            public OneValue(object value) => Val = value;
        }

    }
}
